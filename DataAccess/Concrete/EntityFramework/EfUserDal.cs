using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityReposioryBase<User, Context>, IUserDal
    {
        public List<UserDetailsDto> GetAllUserDetails()
        {
            using (var context = new Context())
            {
                var result = from u in context.Users
                             join w in context.Wallets
                             on u.UserAddress equals w.UserAddress
                             select new UserDetailsDto
                             {
                                 UserId = u.UserId,
                                 UserAddress = u.UserAddress,
                                 UserName = u.FirstName + " " + u.LastName,
                                 Email = u.Email,
                                 Balance = w.Balance
                             };

                return result.ToList();

            }
        }

        public UserDetailsDto GetUserDetails(int userId)
        {
            using (var context = new Context())
            {
                var result = from u in context.Users
                             join w in context.Wallets
                             on u.UserAddress equals w.UserAddress
                             where u.UserId == userId
                             select new UserDetailsDto
                             {
                                 UserId = u.UserId,
                                 UserName = u.FirstName + " " + u.LastName,
                                 Email = u.Email,
                                 Balance = w.Balance
                             };

                return result.FirstOrDefault();
            }
        }
    }
}
