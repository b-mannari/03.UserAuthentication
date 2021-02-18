using System;

namespace UserAuthentication.ClassObjects
{
    public class LoginUser
    {
        public string Login(string username, string password, UserAccount userAccount)
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