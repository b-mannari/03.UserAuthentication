using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserAuthenticationService.ClassObjects;

namespace UserAuthenticationService
{
    public class UserService : IUserInterface
    {
        private readonly string baseApi = "https://localhost:44315/api/users/";
        public async Task<List<UserModel>> GetAllUsers()
        {
            List<UserModel> userList = new List<UserModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(baseApi + "GetAll").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        userList = JsonConvert.DeserializeObject<List<UserModel>>(apiResponse);
                    }
                }
            }
            return userList;
        }

        public async Task<bool> UserExists(string Username)
        {
            bool userExists = false;
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(baseApi + "Exists?Username=" + Username).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        userExists = true;
                    }
                }
            }
            return userExists;
        }

        public async Task<UserModel> GetUserByName(string Username)
        {
            UserModel user = new UserModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(baseApi + "GetByName").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        user = JsonConvert.DeserializeObject<UserModel>(apiResponse);
                    }
                }
            }
            return user;
        }

        public async Task<bool> AddUser(UserModel model)
        {
            bool UserCreated = false;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(baseApi + "Create", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        //apiResponse = await response.Content.ReadAsStringAsync();
                        UserCreated = true;
                    }
                }
            }
            return UserCreated;
        }


        public async Task<bool> Login(UserModel model)
        {
            bool userExists = false;
            using (var httpClient = new HttpClient())
            {
                using (var response = httpClient.GetAsync(baseApi + "UserPasswordExists?Username=" + model.Username + "?Password=" + model.Password).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        userExists = true;
                    }
                }
            }
            return userExists;
        }
    }
}






//public async Task<string> UpdateUser(UserModel model)
//{
//    string apiResponse = "";
//    using (var httpClient = new HttpClient())
//    {
//        StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

//        using (var response = await httpClient.PostAsync(baseApi + "Edit", content))
//        {
//            if (response.IsSuccessStatusCode)
//            {
//                apiResponse = await response.Content.ReadAsStringAsync();
//            }
//        }
//    }
//    return apiResponse;
//}

//public async Task<string> DeleteUser(UserModel model)
//{
//    string apiResponse = "";
//    using (var httpClient = new HttpClient())
//    {
//        StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

//        using (var response = await httpClient.PostAsync(baseApi + "Delete", content))
//        {
//            if (response.IsSuccessStatusCode)
//            {
//                apiResponse = await response.Content.ReadAsStringAsync();
//            }
//        }
//    }
//    return apiResponse;
//}