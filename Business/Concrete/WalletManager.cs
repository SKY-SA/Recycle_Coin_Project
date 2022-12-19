using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WalletManager : IWalletService
    {
        IWalletDal _walletDal;

        public WalletManager(IWalletDal walletDal)
        {
            _walletDal = walletDal;
        }

        public IResult Add(Wallet wallet)
        {
            _walletDal.Add(wallet);
            return new SuccessResult();
        }

        public IDataResult<List<Wallet>> GetAll()
        {
            return new SuccessDataResult<List<Wallet>>(_walletDal.GetAll()); 
        }

        public Wallet GetByUserAddress(string userAddress)
        {
            return _walletDal.Get(u=>u.UserAddress == userAddress);
        }

        public IResult Update(Wallet wallet)
        {
            _walletDal.Update(wallet);
            return new SuccessResult();
        }
    }
}
