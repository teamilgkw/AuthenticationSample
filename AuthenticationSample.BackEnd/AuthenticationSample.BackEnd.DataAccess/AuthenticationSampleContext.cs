using AuthenticationSample.BackEnd.BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationSample.BackEnd.DataAccess
{
    public class AuthenticationSampleContext : DbContext
    {
        public AuthenticationSampleContext(DbContextOptions<AuthenticationSampleContext> options) : base(options)
        {
            //OwnerMaster oOwnerMaster = new OwnerMaster();
            //oOwnerMaster.ID = 0;
            //oOwnerMaster.FullName = 0;
            //oOwnerMaster.ema = 0;
            //oOwnerMaster.ID = 0;
            //oOwnerMaster.ID = 0;
            //oOwnerMaster.ID = 0;
            //oOwnerMaster.ID = 0;

        }

        public DbSet<OwnerMaster> OwnerMasters { get; set; }
        /*
        public DbSet<LoginType> LoginTypes { get; set; }
        */
        public DbSet<OwnerLogin> OwnerLogins { get; set; }
    }
}