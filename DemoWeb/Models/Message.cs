using System;
using System.ComponentModel.DataAnnotations;

namespace DemoWeb.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public DateTime Created { get; set; }

        [StringLength(100)]
        public string Body { get; set; }

        public bool Favorited { get; set; }
    }
}