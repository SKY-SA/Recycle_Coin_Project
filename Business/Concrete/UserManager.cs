using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IWalletService _walletService;

        public UserManager(IUserDal userDal, IWalletService walletService)
        {
            _userDal = userDal;
            _walletService = walletService;
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public IResult AddBalance(string userAddress, int amount)
        {
            _walletService.BalanceAdd(userAddress, amount);
            return new SuccessResult();
        }

        public IDataResult<Wallet> DisplayBalance(string userAddress)
        {
            var result = _walletService.GetByUserAddress(userAddress);
            if (result == null)
                return new ErrorDataResult<Wallet>(Messages.WalletNotFound);
            return new SuccessDataResult<Wallet>(result);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IResult GetByUserAddress(string userAddress)
        {
            var result = _userDal.Get(u=> u.UserAddress == userAddress);
            if (result == null)
                return new ErrorResult(Messages.UserNotFound);
            return new SuccessResult();
        }
        public IResult SendBalance(string senderUserAddress, string receiverUserAddress, int amount)
        {
            var result = _walletService.BalanceReduction(senderUserAddress, amount);
            if (result.Success)
            {
                _walletService.BalanceAdd(receiverUserAddress, amount);
                return new SuccessResult();
            }
            return new ErrorResult(result.Message);
                
        }

    }
}