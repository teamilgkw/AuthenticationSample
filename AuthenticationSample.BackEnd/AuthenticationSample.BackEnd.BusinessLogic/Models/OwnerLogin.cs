using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationSample.BackEnd.BusinessLogic.Models
{
    [Table("OwnerLogin")]
    public class OwnerLogin
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("OwnerMasterID")]
        public int OwnerMasterID { get; set; }
        public OwnerMaster OwnerMaster { get; set; }
        public LoginType LoginType { get; set; }
        public string LoginIdentifier { get; set; }
        public string Password { get; set; }
        public bool IsVerified { get; set; }
        public bool IsEnabled { get; set; }

    }
}