// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using System.Text;

Console.WriteLine("------------- Program has starting -------------");


TestCase();


Console.WriteLine("\n------------- THE END ---------------");







// Local Method
static void TestUserAdd(AuthManager authManager, UserForRegisterDto userForRegister, string password)
{
    //var userForRegister = new UserForRegisterDto
    //{
    //    FirstName = "Dila",
    //    LastName = "Yoğurt",
    //    Email = "dila@gmail.com",
    //    Password = "123456"
    //};
    var result = authManager.Register(userForRegister, "123456");
    if (result.Success)
        Console.WriteLine(result.Message);
    else
        Console.WriteLine(result.Message);
}

static void TestDisplayUserBalance(UserManager userManager, string userEmail)
{
    var user = userManager.GetByMail(userEmail);
    if (user != null)
    {
        var result = userManager.DisplayBalance(user.UserAddress);
        if (result.Success)
        {
            Console.WriteLine($"User Address: {result.Data.UserAddress}\n\t Balance: {result.Data.Balance}");
        }
    }
}

static void TestGetUserByEmail(AuthManager authManager)
{
    var result = authManager.UserExistsWithEmail("onthsky@gmail.com");
    if (result.Success)
        Console.WriteLine("İşlem başarılı");
    else
        Console.WriteLine(result.Message);
}

static void TestSendBalance(UserManager userManager, string senderUserAddress, string receiverUserAddress, int amount)
{
    //var senderUser = userManager.GetByMail("onthsky@gmail.com");
    //var receiverUser = userManager.GetByMail("dila@gmail.com");

    var result = userManager.SendBalance(senderUserAddress, receiverUserAddress, amount);
    if (!result.Success)
        Console.WriteLine(result.Message);
    else
        Console.WriteLine("\tProcessing has done Successfully");
}

static void TestDoRecycle(CartManager cartManager, UserManager userManager, string userEmail, int productId, double quantity)
{
    var user = userManager.GetByMail(userEmail);
    if (user == null)
        Console.WriteLine("User Not Found !");
    cartManager.DoRecycle(productId, quantity, user.UserAddress);
}








static void TestCase()
{
    var productManager = new ProductManager(new EfProductDal());
    var walletManager = new WalletManager(new EfWalletDal());
    UserManager userManager = new UserManager(new EfUserDal(), walletManager);
    var authManager = new AuthManager(userManager, walletManager);
    var cartManager = new CartManager(new EfCartDal(), walletManager, productManager);

    var userForRegister = new UserForRegisterDto()
    {
        Email = "bayrak@gmail.com",
        FirstName = "Ayşe",
        LastName = "Bayrak",
        Password = "123456"
    };

    Console.WriteLine("\n->TEST of user registration has starting");
    TestUserAdd(authManager, userForRegister, "123456");
    Console.WriteLine("-->REGISTRATION TEST HAS DONE !!!");

    Thread.Sleep(2000);
    Console.WriteLine("\n->TEST of getting user's balance has starting");
    TestDisplayUserBalance(userManager, userForRegister.Email);
    Console.WriteLine("-->Display balance TEST has DONE !!!");

    Thread.Sleep(2000);
    Console.WriteLine("\n->TEST of Doing Recycle has starting");
    TestDoRecycle(cartManager, userManager, userForRegister.Email, 1, 4);
    Console.WriteLine("-->Do Recycle Test Has DONE !!!");

    Thread.Sleep(2000);
    Console.WriteLine("\n\N->After Doing Recycle, TEST of getting user's balance has starting");
    TestDisplayUserBalance(userManager, userForRegister.Email);
    Console.WriteLine("-->Display balance TEST has DONE !!!");

    var senderUser = userManager.GetByMail(userForRegister.Email);
    var receiverUser = userManager.GetByMail("onthsky@gmail.com");

    if (receiverUser != null && senderUser != null)
    {
        Thread.Sleep(2000);
        Console.WriteLine("\n->BEFORE Transfer, TEST of getting user's balance has starting\nRECEIVER");
        TestDisplayUserBalance(userManager, receiverUser.Email);
        Console.WriteLine("-->Display balance TEST has DONE !!!");

        Thread.Sleep(2000);
        Console.WriteLine("\n->TEST of sending balance betwen users has starting");
        TestSendBalance(userManager, senderUser.UserAddress, receiverUser.UserAddress, 10);
        Console.WriteLine("-->Balance Sending TEST has DONE !!!");

        Thread.Sleep(2000);
        Console.WriteLine("\n->After Transfer, TEST of getting user's balance has starting\nSENDER");
        TestDisplayUserBalance(userManager, senderUser.Email);
        Console.WriteLine("-->Display balance TEST has DONE !!!");

        Thread.Sleep(2000);
        Console.WriteLine("\n->After Transfer, TEST of getting user's balance has starting\nRECEIVER");
        TestDisplayUserBalance(userManager, receiverUser.Email);
        Console.WriteLine("-->Display balance TEST has DONE !!!");
    }

    
}









