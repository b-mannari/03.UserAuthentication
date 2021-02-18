using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAccountsController : Controller
    {
        string contentRootPath = ""; string FilePath = "";
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<UserAccountsController> _logger;

        public UserAccountsController(ILogger<UserAccountsController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;

            //string webRootPath = _hostingEnvironment.WebRootPath;
            contentRootPath = _hostingEnvironment.ContentRootPath;
            FilePath = Path.Combine(contentRootPath + "\\JSON", "userDB.json");
        }

        [HttpGet("/api/users/GetAll")]
        public List<UserModel> GetAll()
        {
            string strResponseContent;
            using (StreamReader reader = new StreamReader(FilePath))
            {
                strResponseContent = reader.ReadToEnd();
            }

            List<UserModel> userList = JsonConvert.DeserializeObject<List<UserModel>>(strResponseContent);

            return userList;
        }

        [HttpGet("/api/users/GetByName")]
        // GET: UserAccountsController/Details/5
        public UserModel GetByName(string Username)
        {
            string strResponseContent;
            using (StreamReader reader = new StreamReader(FilePath))
            {
                strResponseContent = reader.ReadToEnd();
            }

            List<UserModel> userList = JsonConvert.DeserializeObject<List<UserModel>>(strResponseContent);
            return userList.Where(x => x.Username == Username).FirstOrDefault();
        }

        [HttpGet("/api/users/Exists")]
        // GET: UserAccountsController/Details/5
        public bool Exists(string Username)
        {
            string strResponseContent;
            using (StreamReader reader = new StreamReader(FilePath))
            {
                strResponseContent = reader.ReadToEnd();
            }

            List<UserModel> userList = JsonConvert.DeserializeObject<List<UserModel>>(strResponseContent);
            userList.Where(x => x.Username == Username).FirstOrDefault();
            //int cnt = userList.Where(x => x.Username == Username).Count();
            //int cnt = userList.Count();
            return userList.Count() > 0;
            //return cnt > 0 ? true : false;
        }

        [HttpGet("/api/users/UserPasswordExists")]
        // GET: UserAccountsController/Details/5
        public bool UserPasswordExists(string Username, string password)
        {
            string strResponseContent;
            using (StreamReader reader = new StreamReader(FilePath))
            {
                strResponseContent = reader.ReadToEnd();
            }

            List<UserModel> userList = JsonConvert.DeserializeObject<List<UserModel>>(strResponseContent);
            userList.Where(x => x.Username == Username && x.Password == password).FirstOrDefault();
            //int cnt = userList.Count();
            return userList.Count() > 0;
            //return cnt > 0 ? true : false;
        }

        [HttpPost("/api/users/Create")]
        // GET: UserAccountsController/Create
        public bool Create(UserModel model)
        {
            bool UserCreated = false;
            var json = System.IO.File.ReadAllText(FilePath);
            var userList = JsonConvert.DeserializeObject<List<UserModel>>(json);

            if (model == null) { model.UserId = 1; }
            else { model.UserId = userList.Count + 1; }

            userList.Add(model);

            System.IO.File.WriteAllText(FilePath, JsonConvert.SerializeObject(userList, Formatting.Indented));

            return UserCreated;
        }

        //[HttpPost("/api/users/Edit")]
        //// GET: UserAccountsController/Edit/5
        //public string Edit(UserModel model)
        //{
        //    string json = System.IO.File.ReadAllText(FilePath);

        //    var userList = JsonConvert.DeserializeObject<List<UserModel>>(json);
        //    var users = userList.Where(a => a.Username == model.Username).ToList();
        //    foreach (var user in users)
        //    {
        //        userList.Remove(user);
        //    }
        //    System.IO.File.WriteAllText(FilePath, JsonConvert.SerializeObject(userList, Formatting.Indented));
        //    json = System.IO.File.ReadAllText(FilePath);
        //    var allUsers = JsonConvert.DeserializeObject<List<UserModel>>(json);
        //    allUsers.Add(model);
        //    System.IO.File.WriteAllText(FilePath, JsonConvert.SerializeObject(allUsers, Formatting.Indented));
        //    return "User updated successfully.";
        //}

        //[HttpPost("/api/users/Delete")]
        //// GET: UserAccountsController/Delete/5
        //public string Delete(UserModel model)
        //{
        //    string json = System.IO.File.ReadAllText(FilePath);

        //    var userList = JsonConvert.DeserializeObject<List<UserModel>>(json);
        //    var users = userList.Where(a => a.Username == model.Username).ToList();
        //    foreach (var user in users)
        //    {
        //        userList.Remove(user);
        //    }
        //    System.IO.File.WriteAllText(FilePath, JsonConvert.SerializeObject(userList, Formatting.Indented));
        //    json = System.IO.File.ReadAllText(FilePath);

        //    return "User deleted successfully.";
        //}


        //// GET: UserAccountsController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// POST: UserAccountsController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}


        //// POST: UserAccountsController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: UserAccountsController
        //public ActionResult Index()
        //{

        //    return View();
        //}

        //public async Task EditAgileSquadAsync(UserModel model)
        //{
        //    try
        //    {
        //        string contentRootPath = _hostingEnvironment.ContentRootPath;
        //        string pathToTheFile = Path.Combine(contentRootPath, "~/JSON", "userDB.json");
        //        string json = System.IO.File.ReadAllText(pathToTheFile);

        //        var userList = JsonConvert.DeserializeObject<List<UserModel>>(json);
        //        var users = userList.Where(a => a.Username == model.Username).ToList();
        //        foreach (var user in users)
        //        {
        //            userList.Remove(user);
        //        }
        //        System.IO.File.WriteAllText(pathToTheFile, JsonConvert.SerializeObject(userList, Formatting.Indented));
        //        json = System.IO.File.ReadAllText(pathToTheFile);
        //        var allUsers = JsonConvert.DeserializeObject<List<UserModel>>(json);
        //        allUsers.Add(model);
        //        System.IO.File.WriteAllText(pathToTheFile, JsonConvert.SerializeObject(allUsers, Formatting.Indented));

        //    }
        //    catch (Exception ex)
        //    {
        //        //log.Error("Exception thrown by " + System.Reflection.MethodBase.GetCurrentMethod(), ex);
        //    }
        //}

        //// GET: UserAccountsController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: UserAccountsController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
