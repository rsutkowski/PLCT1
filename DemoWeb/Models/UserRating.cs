using System.ComponentModel.DataAnnotations;

namespace DemoWeb.Models
{
    public class UserRating
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public int MessageId { get; set; }
    }
}