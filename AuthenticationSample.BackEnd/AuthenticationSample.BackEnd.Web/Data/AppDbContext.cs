using AuthenticationSample.BackEnd.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationSample.BackEnd.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<OwnerMaster> OwnerMasters { get; set; }
        /*
        public DbSet<LoginType> LoginTypes { get; set; }
        */
        public DbSet<OwnerLogin> OwnerLogins  { get; set; }
    }
}