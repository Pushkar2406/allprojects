using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using dotnetmvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;



namespace Dotnetmvcpgm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;



        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            List<User> UserList = new List<User>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:57313/api/user"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    UserList = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                }
            }
            return View(UserList);
        }
        public ViewResult GetBook()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetBook(int UserId)
        {
            User user = new User();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:57313/api/user" + UserId))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        user = JsonConvert.DeserializeObject<User>(apiResponse);
                    }
                    else
                        ViewBag.StatusCode = response.StatusCode;
                }
            }
            return View(user);
        }
        public ViewResult AddUser()
        {





            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            User muser = new User();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:57313/api/user", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return View(muser);
        }
        public async Task<IActionResult> UpdateBook(int id)
        {
            User user = new User();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:57313/api/user" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(apiResponse);
                }





            }
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(User user)
        {
            User receivedBook = new User();
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(user.UserId.ToString()), "UserId");
                content.Add(new StringContent(user.UserName), "UserName");
                content.Add(new StringContent(user.Useremail), "Useremail");



                using (var response = await httpClient.PostAsync("http://localhost:57313/api/user", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedBook = JsonConvert.DeserializeObject<User>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }





        [HttpPost]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:57313/api/user" + Id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }





            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}