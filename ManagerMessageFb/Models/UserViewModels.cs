using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerMessageFb.Models
{
    public class UserViewModels
    {
        public string userMessage { get; set; }
    }
    public class UserProfileViewModel
    {
        public string name { get; set; }
        public string id { get; set; }
    }
    public class MessageViewModel
    {
        public string id { get; set; }
        public string userIdTo { get; set; }
        public string userIdFrom { get; set; }
        public string message1 { get; set; }
        public DateTime createdon { get; set; }
    }
}