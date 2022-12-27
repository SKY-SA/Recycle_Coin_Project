using Azure.Core;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private IWalletService _walletService;
        public AuthManager(IUserService userService, IWalletService walletService)
        {
            _userService = userService;
            _walletService = walletService;     
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            var userAddress = HashingHelper.CreateUserAddress(userForRegisterDto.FirstName, userForRegisterDto.LastName, userForRegisterDto.Email);
            bool passwordStatus = string.Equals(userForRegisterDto.Password, password, StringComparison.OrdinalIgnoreCase);
            if (!passwordStatus)
                return new ErrorDataResult<User>(Messages.PasswordNotMatch);
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
           
            var user = new User
            {
                UserAddress = userAddress,
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            _userService.Add(user);
            var result = _walletService.GetByUserAddress(userAddress);
            if (result == null)
            {
                var result2 = _walletService.Add(new Wallet
                {
                    UserAddress = userAddress,
                    Balance = 0
                });
                if (!result2.Success)
                    return new ErrorDataResult<User>(Messages.WalletCreatingError);
            }
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExistsWithEmail(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IResult UserExistWithUserAddress(string userAddress)
        {
            var result = _userService.GetByUserAddress(userAddress);
            if (!result.Success)
                return new ErrorResult(result.Message);
            return new SuccessResult();
        }
        //public IDataResult<AccessToken> CreateAccessToken(User user)
        //{
        //    var claims = _userService.GetClaims(user);
        //    var accessToken = _tokenHelper.CreateToken(user, claims);
        //    return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        //}
    }
}
