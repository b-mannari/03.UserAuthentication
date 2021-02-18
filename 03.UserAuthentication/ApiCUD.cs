using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserAuthenticationService.ClassObjects;

namespace UserAuthenticationService
{
    class ApiCUD
    {
        public async Task<List<UserModel>> GetAll(string apiUrl)
        {
            //"https://localhost:44324/api/Reservation"
            List<UserModel> userList = new List<UserModel>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userList = JsonConvert.DeserializeObject<List<UserModel>>(apiResponse);
                }
            }
            return userList;
        }

        public async Task<UserModel> GetUserByName(string apiUrl, string Username)
        {
            //"https://localhost:44324/api/Reservation/"
            UserModel user = new UserModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl + Username))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        user = JsonConvert.DeserializeObject<UserModel>(apiResponse);
                    }
                    //else
                    //ViewBag.StatusCode = response.StatusCode;
                }
            }
            return user;
        }

        public async Task<UserModel> AddUser(string apiUrl, UserModel model)
        {
            UserModel userModel = new UserModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(apiUrl, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userModel = JsonConvert.DeserializeObject<UserModel>(apiResponse);
                }
            }
            return userModel;
        }

        public async Task<UserModel> UpdateUser(int id)
        {
            UserModel reservation = new UserModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44324/api/Reservation/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservation = JsonConvert.DeserializeObject<UserModel>(apiResponse);
                }
            }
            return reservation;
        }


        public async Task<UserModel> UpdateUser(UserModel model)
        {
            UserModel receivedReservation = new UserModel();
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(model.UserId.ToString()), "UesrId");
                content.Add(new StringContent(model.Username), "Username");
                content.Add(new StringContent(model.Password), "Password");

                using (var response = await httpClient.PutAsync("https://localhost:44324/api/Reservation", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //ViewBag.Result = "Success";
                    receivedReservation = JsonConvert.DeserializeObject<UserModel>(apiResponse);
                }
            }
            return receivedReservation;
        }


        public async Task<UserModel> DeleteUser(string Username)
        {
            UserModel receivedReservation = new UserModel();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44324/api/Reservation/" + Username))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return receivedReservation;
        }
    }
}
