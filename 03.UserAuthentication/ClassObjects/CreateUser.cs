using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UserAuthenticationService;
using UserAuthenticationService.ClassObjects;

namespace UserAuthentication.ClassObjects
{
    public class CreateUser
    {
        UserService userService = new UserService();

        public bool ValidateUserName(string userName)
        {
            if (Regex.Match(userName, @"^[a-zA-Z]*$").Success)
            {
                return true;
            }
            return false;
        }

        public bool ValidatePassword(string password)
        {
            if (Regex.Match(password, @"^.*(?=.{6,6})(?=.*\d)(?=.*[a-zA-Z]).*$").Success)
            {
                return true;
            }
            return false;
        }

        public string AddNewUser(string username, string password)
        {
            string Message = "Unable to create user";
            bool validUserName = ValidateUserName(username);
            bool validPassword = ValidatePassword(password);

            if (validUserName && validPassword)
            {
                UserModel model = new UserModel { Username = username, Password = password };
                if (isUserExists(model.Username))
                {
                    Message = "User already exists";
                }
                else
                {
                    if (isUserCreated(model))
                    {
                        Message = "User added successfully.";
                    }
                }
            }
            else
            {
                Message = "Unable to create user";
            }

            return Message;
        }

        public bool isUserExists(string Username)
        {
            bool isUserPresent = false;
            Task.Run(async () => { isUserPresent = await userService.UserExists(Username); }).Wait();
            return isUserPresent;
        }

        public bool isUserCreated(UserModel model)
        {
            bool isUserSaved = false;
            Task.Run(async () => { isUserSaved = await userService.AddUser(model); }).Wait();
            return isUserSaved;
        }

        public string AddNewUser_Old(string username, string password, UserAccount userAccount)
        {
            bool validUserName = ValidateUserName(username);
            bool validPassword = ValidatePassword(password);

            if (validUserName && validPassword)
            {
                if (userAccount.GetUserInfo.ContainsKey(username))
                {
                    Console.WriteLine("This username is already exists.");
                }
                else
                {
                    userAccount.AddUserInfo();
                }
                return "User created Successfully";
            }
            else
            {
                return "Unable to create user";
            }
        }
    }
}
