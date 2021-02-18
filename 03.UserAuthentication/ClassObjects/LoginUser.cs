using System;
using System.Threading.Tasks;
using UserAuthenticationService;
using UserAuthenticationService.ClassObjects;

namespace UserAuthentication.ClassObjects
{
    public class LoginUser
    {
        UserService userService = new UserService();
        public string Login(string username, string password )
        {
            string message = "";
            UserModel model = new UserModel { Username = username, Password = password };
            try
            {
                if (isUserPasswordExists(model.Username, model.Password))
                {
                    message = "Login Success";
                }
                else
                {
                    message = "Login failure";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return message;
        }

        public bool isUserPasswordExists(string Username, string Password)
        {
            bool isUserPresent = false;
            UserModel model = new UserModel { Username = Username, Password = Password };
            Task.Run(async () => { isUserPresent = await userService.Login(model); }).Wait();
            return isUserPresent;
        }

        public string Login_old(string username, string password, UserAccount userAccount)
        {
            string message = "";
            try
            {
                if (userAccount.GetUserInfo.ContainsKey(username) && userAccount.GetUserInfo.ContainsValue(password))
                {
                    message = "Login Success";
                }
                else
                {
                    message = "Login failure";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return message;
        }
    }
}