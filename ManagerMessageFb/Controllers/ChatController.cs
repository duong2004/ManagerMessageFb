using ManagerMessageFb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ManagerMessageFb.Controllers
{
    public class ChatController : Controller
    {
        [HttpGet]
        // GET: Chat
        public ActionResult Index()
        {
            List<UserViewModels> users = null;
            List<UserProfileViewModel> profiles = new List<UserProfileViewModel>();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://chat.profile-working.com/api/message/getmessageby/");
                var response = Task.Run(() => httpClient.GetAsync("" + "2"));
                response.Wait();
                var responseContent = Task.Run(() => response.Result.Content.ReadAsStringAsync());
                responseContent.Wait();
                users = JsonConvert.DeserializeObject<List<UserViewModels>>(responseContent.Result.ToString());
            }
            foreach (var user in users)
            {
                UserProfileViewModel profile = null;
                var url = $"https://graph.facebook.com/{user.userMessage}?fields=name,id&access_token=EAALkiGIZAE5IBAG5H99RKPXn9oQ3RMe2yn24Iazcjy5wowXPOdZAf1XIOTpwfWvfx4GDqw47YOZBERGY28ZAdv8zwGbYv8Eok5lU05TLdiAw38aqIJNJzI3RKETiZAvZAimMZCZBZAK0CcZC3UtMrYhK4YwgEDwRthVYRfLIMRhIeeEOhe139UKOqC";
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(url);
                    var response = Task.Run(() => httpClient.GetAsync(""));
                    response.Wait();
                    if (response.Result.StatusCode != System.Net.HttpStatusCode.BadRequest)
                    {
                        var responseContent = Task.Run(() => response.Result.Content.ReadAsStringAsync());
                        responseContent.Wait();
                        profile = JsonConvert.DeserializeObject<UserProfileViewModel>(responseContent.Result.ToString());
                    }
                    else
                    {
                        profile = new UserProfileViewModel()
                        {
                            id = user.userMessage,
                            name = user.userMessage
                        };
                    }
                }
                profiles.Add(profile);
            }
            ChatViewModels model = new ChatViewModels()
            {
                id = "2",
                userViews = profiles
            };
            return View(model);
        }
        [HttpGet]
        public ActionResult IndexB()
        {
            List<UserViewModels> users = null;
            List<UserProfileViewModel> profiles = new List<UserProfileViewModel>();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://chat.profile-working.com/api/message/getmessageby/");
                var response = Task.Run(() => httpClient.GetAsync("" + "1"));
                response.Wait();
                var responseContent = Task.Run(() => response.Result.Content.ReadAsStringAsync());
                responseContent.Wait();
                users = JsonConvert.DeserializeObject<List<UserViewModels>>(responseContent.Result.ToString());
            }
            foreach (var user in users)
            {
                UserProfileViewModel profile = null;
                var url = $"https://graph.facebook.com/{user.userMessage}?fields=name,id&access_token=EAALkiGIZAE5IBAG5H99RKPXn9oQ3RMe2yn24Iazcjy5wowXPOdZAf1XIOTpwfWvfx4GDqw47YOZBERGY28ZAdv8zwGbYv8Eok5lU05TLdiAw38aqIJNJzI3RKETiZAvZAimMZCZBZAK0CcZC3UtMrYhK4YwgEDwRthVYRfLIMRhIeeEOhe139UKOqC";
                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(url);
                    var response = Task.Run(() => httpClient.GetAsync(""));
                    response.Wait();
                    if (response.Result.StatusCode != System.Net.HttpStatusCode.BadRequest)
                    {
                        var responseContent = Task.Run(() => response.Result.Content.ReadAsStringAsync());
                        responseContent.Wait();
                        profile = JsonConvert.DeserializeObject<UserProfileViewModel>(responseContent.Result.ToString());
                    }
                    else
                    {
                        profile = new UserProfileViewModel()
                        {
                            id = user.userMessage,
                            name = user.userMessage
                        };
                    }
                }
                profiles.Add(profile);
            }
            ChatViewModels model = new ChatViewModels()
            {
                id = "1",
                userViews = profiles
            };
            return View(model);
        }
        [HttpGet]
        public ActionResult GetMessage(string a, string b)
        {
            List<MessageViewModel> messages = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://chat.profile-working.com/api/message/getmessage");
                var response = Task.Run(() => httpClient.GetAsync("getmessage?a=" + a + "&b=" + b));
                response.Wait();
                var responseContent = Task.Run(() => response.Result.Content.ReadAsStringAsync());
                responseContent.Wait();
                messages = JsonConvert.DeserializeObject<List<MessageViewModel>>(responseContent.Result.ToString());
            }
            MessageViewModels model = new MessageViewModels()
            {
                recipientId = a,
                messageViews = messages
            };
            return View(model);
        }
        [HttpPost]
        public JsonResult Send(string recipientId, string message)
        {
            string result = "Gui thanh cong";
            bool success = true;
            var body = new
            {
                messaging_type = "RESPONSE",
                recipient = new
                {
                    id = recipientId
                },
                message = new
                {
                    text = message
                }
            };
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://graph.facebook.com/v12.0/me/messages?access_token=EAALkiGIZAE5IBAG5H99RKPXn9oQ3RMe2yn24Iazcjy5wowXPOdZAf1XIOTpwfWvfx4GDqw47YOZBERGY28ZAdv8zwGbYv8Eok5lU05TLdiAw38aqIJNJzI3RKETiZAvZAimMZCZBZAK0CcZC3UtMrYhK4YwgEDwRthVYRfLIMRhIeeEOhe139UKOqC");
                var response = Task.Run(() => httpClient.PostAsync("", content));
                response.Wait();
                var responseContent = Task.Run(() => response.Result.Content.ReadAsStringAsync());
                responseContent.Wait();
                if (response.Result.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    result = "Không gửi được, vui lòng gửi lại sau!";
                    success = false;
                }
            }
            return Json(new
            {
                message = result,
                success = success
            }, JsonRequestBehavior.AllowGet);
        }
    }
}