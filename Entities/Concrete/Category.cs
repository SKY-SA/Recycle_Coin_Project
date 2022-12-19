using Core.Entities.Abstract;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public int RecycleScoreId { get; set; }
        public string? CategoryName { get; set; }
    }
}
