using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IWalletService
    {
        IDataResult<List<Wallet>> GetAll();
        Wallet GetByUserAddress(string userAddress);

        IResult Add(Wallet wallet);
        IResult Update(Wallet wallet);

        IResult BalanceAdd(string userAddress, double amount);
        IResult BalanceReduction(string userAddress, double amount);
    }
}
 