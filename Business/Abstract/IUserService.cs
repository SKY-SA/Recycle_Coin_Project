using Azure.Core;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        User GetByMail(string email);

        IResult GetByUserAddress(string userAddress);
        IResult AddBalance(string userAddress, int amount);
        IDataResult<Wallet> DisplayBalance(string userAddress);
        IResult SendBalance(string senderUserAddress,string receiverUserAddress, int amount);
    }

}
