using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        ICartDal _cartDal;
        IWalletService _walletService;
        IProductService _productService;

        public CartManager(ICartDal cartDal, IWalletService walletService,IProductService productService)
        {
            _cartDal = cartDal;
            _walletService = walletService;
            _productService = productService;

        }
        public IResult DoRecycle(int productId, double quantity, string userAddress)
        {
            var productToRecycle = _productService.GetProductDetails(productId);
            if (!productToRecycle.Success)
                return new ErrorResult(productToRecycle.Message);
            var totalBalanceToAdd = 0D;
            totalBalanceToAdd = productToRecycle.Data.Score * quantity;
            var result = _walletService.BalanceAdd(userAddress, totalBalanceToAdd);
            if (!result.Success)
                return new ErrorResult(result.Message);
            return new SuccessResult(Messages.RecycleIsSuccess);
        }
    }
}
