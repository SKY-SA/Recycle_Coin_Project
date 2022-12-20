using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExistsWithEmail(string email);
        IResult UserExistWithUserAddress(string userAddress);
        //<AccessToken> CreateAccessToken(User user);
    }
    //IDataResult<List<User>> GetAll();
    //IDataResult<User> GetByEmail(string email);

    //IResult Add(User user);
    //IResult Update(User user);
    //IResult Delete(User user);
}
