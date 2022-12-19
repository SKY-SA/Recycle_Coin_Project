using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class Wallet : IEntity
    {
        public int WalletId { get; set; }
        public string UserAddress { get; set; }
        public int Balance { get; set; }
    }
}
