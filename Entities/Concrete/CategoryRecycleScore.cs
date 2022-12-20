using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class CategoryRecycleScore: IEntity
    {
        public int Id { get; set; }
        public int Score { get; set; }
    }
}
