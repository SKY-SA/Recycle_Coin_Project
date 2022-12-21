using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class Wallet : IEntity
    {
        public int WalletId { get; set; }
        public string UserAddress { get; set; }
        public double Balance { get; set; }
        private double _carbonBalance;
        
        public double GetCarbonBalance()
        {
            _carbonBalance = Balance * 100;
            return _carbonBalance;
        }

    }
}
