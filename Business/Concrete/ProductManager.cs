using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<Product> GetProductById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId == id));
        }

        public IDataResult<ProductDetailsDto> GetProductDetails(int productId)
        {
            var result = _productDal.GetProductDetails(productId);
            if (result == null)
                return new ErrorDataResult<ProductDetailsDto>(Messages.ProductNotFound);
            return new SuccessDataResult<ProductDetailsDto>(result, Messages.ProductFound);
        }
    }
}
