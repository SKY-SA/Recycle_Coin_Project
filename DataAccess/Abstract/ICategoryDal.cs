﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
       // List<CategoryDetailsDto> DisplayCategoryScore(int categoryId);
    }
}
