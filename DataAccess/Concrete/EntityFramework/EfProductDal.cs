using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityReposioryBase<Product, Context>, IProductDal
    {
        public ProductDetailsDto GetProductDetails(int productId)
        {
            using (var context = new Context())
            {
                var result = from p in context.Products
                             join c in context.Categories on p.CategoryId equals c.CategoryId
                             join s in context.CategoryRecycleScores on c.RecycleScoreId equals s.Id
                             select new ProductDetailsDto
                             {
                                 ProductId= productId,
                                 Score = s.Score
                             };
                return result.SingleOrDefault();
                             
            }
        }
    }
}
