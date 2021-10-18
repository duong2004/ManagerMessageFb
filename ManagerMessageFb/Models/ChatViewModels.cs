using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerMessageFb.Models
{
    public class ChatViewModels
    {
        public string id { get; set; }
        public List<UserViewModels> userViews { get; set; }
    }
    public class MessageViewModels
    {
        public string recipientId { get; set; }
        public List<MessageViewModel> messageViews { get; set; }
    }
}