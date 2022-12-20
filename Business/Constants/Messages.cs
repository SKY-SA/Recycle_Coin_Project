using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserAlreadyExists = "User already exist !";

        public static string SuccessfulLogin = "Login has done Successfully ";

        public static string PasswordError = "Password is Wrong";

        public static string UserNotFound = "User Not Found !";

        public static string UserRegistered = "User has registered Successfully";

        public static string WalletCreatingError = "Wallet has can not created !";

        public static string WalletNotFound = "Wallet Not Found !";

        public static string InsufficientBalance = "You do not have enough money";

        public static string ProductFound = "Product has found Successfully";

        public static string ProductNotFound = "Product Not Found";

        public static string RecycleIsSuccess = "Recycle has done successfully";
    }
}
