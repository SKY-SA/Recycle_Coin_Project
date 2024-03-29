﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetProductById(int id);
        IDataResult<ProductDetailsDto> GetProductDetails(int productId);
        IDataResult<List<Product>> GetAll();
    }
}
