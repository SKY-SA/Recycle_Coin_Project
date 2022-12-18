using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class Wallet : IEntity
    {
        public int WalletId { get; set; }
        public byte[] UserId { get; set; }
        public int Amount { get; set; }
    }
}
