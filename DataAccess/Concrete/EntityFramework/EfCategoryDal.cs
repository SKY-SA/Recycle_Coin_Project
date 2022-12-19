using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityReposioryBase<Category, Context>, ICategoryDal
    {
        //public List<CategoryDetailsDto> DisplayCategoryScore(int categoryId)
        //{
        //    using (var context = new Context())
        //    {
        //        var result = from c in context.Categories
        //                     join s in context.CategoryRecycleScores
        //                     on c.RecycleScoreId equals s.RecycleScoreId
        //                     where c.CategoryId == categoryId
        //                     select new CategoryDetailsDto
        //                     {
        //                         CategoryId = c.CategoryId,
        //                         CategoryName = c.CategoryName,
        //                         Score = s.Score
        //                     };
        //        return result.ToList();
        //    }
            
        //}
    }
}
