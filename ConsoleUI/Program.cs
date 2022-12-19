// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using System.Text;


UserManager userManager = new UserManager(new EfUserDal());

var authManager = new AuthManager(userManager);

TestUserAdd(authManager);

static void TestUserAdd(AuthManager authManager)
{
    var userForRegister = new UserForRegisterDto
    {
        FirstName = "Kemal",
        LastName = "Yoğurt",
        Email = "onthsky@gmail.com",
        Password = "123456"
    };
    var result = authManager.Register(userForRegister, "123456");
    if (result.Success)
        Console.WriteLine(result.Message);
    else
        Console.WriteLine(result.Message);
}

//TestGetUserByEmail(authManager);

static void TestGetUserByEmail(AuthManager authManager)
{
    var result = authManager.UserExists("onthsky@gmail.com");
    if (result.Success)
        Console.WriteLine("İşlem başarılı");
    else
        Console.WriteLine(result.Message);
}

























//TestUserAdd(userManager);
//TestGetUserByEmail(userManager);

//static void TestUserAdd(UserManager userManager)
//{
//    var result = userManager.Add(new User
//    {
//        FirstName = "Kemal",
//        LastName = "Yoğurt",
//        Email = "onthsky@gmail.com",
//    });

//    if (result.Success)
//    {
//        Console.WriteLine("İşlem Başarılı");
//    }
//    else
//        Console.WriteLine(result.Message);
//}

//static void TestGetUserByEmail(UserManager userManager)
//{
//    var result = userManager.GetByEmail("onthsky@gmail.com");
//    if (result.Success)
//    {
//        Console.WriteLine("İşlem Başarılı");
//        Console.WriteLine(result.Data.UserAddress);

//    }
//    else
//        Console.WriteLine(result.Message);
//}