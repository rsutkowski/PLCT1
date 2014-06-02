using System.Collections.Generic;
using DemoWeb.Models;

namespace DemoWeb.ViewModels
{
    public class MessagesViewModel
    {
        public ICollection<Message> Messages { get; set; }
    }
}