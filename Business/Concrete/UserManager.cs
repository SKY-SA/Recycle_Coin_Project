using Business.Abstract;
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
            var walletToUpdate = _walletService.GetByUserAddress(userAddress);
            walletToUpdate.Balance += amount;
            _walletService.Update(walletToUpdate);
            return new SuccessResult();
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}