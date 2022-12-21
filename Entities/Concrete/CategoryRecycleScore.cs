using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class CategoryRecycleScore: IEntity
    {
        public int Id { get; set; }
        public double Score { get; set; }
    }
}
