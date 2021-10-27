using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationSample.BackEnd.Web.Models
{
    [Table("OwnerLogin")]
    public class OwnerLogin
    {
        public int ID { get; set; }
        public OwnerMaster OwnerMaster { get; set; }
        public LoginType LoginType { get; set; }
        public string EmailOrMobileNumber { get; set; }
        public string Password { get; set; }
        public bool IsVerified { get; set; }
        public bool IsEnabled { get; set; }

    }
}