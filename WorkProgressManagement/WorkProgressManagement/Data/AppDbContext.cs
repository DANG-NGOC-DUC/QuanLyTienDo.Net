using System.Data.Entity;

namespace WorkProgressManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("name=WorkProgressDb")
        {
        }
    }
}