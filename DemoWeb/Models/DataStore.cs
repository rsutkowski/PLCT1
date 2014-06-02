using System.Data.Entity;

namespace DemoWeb.Models
{
    public class DataStore : DbContext
    {
        public DataStore()
            : base("DefaultConnection")
        {
        }

        public DbSet<Message> Messages { get; set; }
    }
}