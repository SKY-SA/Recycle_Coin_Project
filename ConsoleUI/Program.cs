// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using System.Text;

Console.WriteLine("Program has starting ...");

var productManager = new ProductManager(new EfProductDal());
var walletManager = new WalletManager(new EfWalletDal());
UserManager userManager = new UserManager(new EfUserDal(), walletManager);
var authManager = new AuthManager(userManager, walletManager);
var cartManager = new CartManager(new EfCartDal(), walletManager, productManager);

var user = userManager.GetByMail("onthsky@gmail.com");
if (user == null)
    Console.WriteLine("Kullanıcı bulunamadı");


cartManager.DoRecycle(1, 5, user.UserAddress);

// Local Method
//static void TestUserAdd(AuthManager authManager)
//{
//    var userForRegister = new UserForRegisterDto
//    {
//        FirstName = "Dila",
//        LastName = "Yoğurt",
//        Email = "dila@gmail.com",
//        Password = "123456"
//    };
//    var result = authManager.Register(userForRegister, "123456");
//    if (result.Success)
//        Console.WriteLine(result.Message);
//    else
//        Console.WriteLine(result.Message);
//}

//static void TestDisplayUserBalance(UserManager userManager)
//{
//    var user = userManager.GetByMail("onthsky@gmail.com");
//    if (user != null)
//    {
//        var result = userManager.DisplayBalance(user.UserAddress);
//        if (result.Success)
//        {
//            Console.WriteLine($"Balance: {result.Data.Balance}");
//        }
//    }   
//}

//static void TestGetUserByEmail(AuthManager authManager)
//{
//    var result = authManager.UserExists("onthsky@gmail.com");
//    if (result.Success)
//        Console.WriteLine("İşlem başarılı");
//    else
//        Console.WriteLine(result.Message);
//}

//static void TestSendBalance(UserManager userManager)
//{
//    var senderUser = userManager.GetByMail("onthsky@gmail.com");
//    var receiverUser = userManager.GetByMail("dila@gmail.com");
//    var result = userManager.SendBalance(senderUser.UserAddress, receiverUser.UserAddress, 1000);
//    if (!result.Success)
//        Console.WriteLine(result.Message);
//    else
//        Console.WriteLine("Processing has done Successfully");
//}























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