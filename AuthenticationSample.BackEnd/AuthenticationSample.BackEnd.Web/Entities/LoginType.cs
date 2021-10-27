using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationSample.BackEnd.Web.Entities
{
    [Table("LoginType")]
    public class LoginType
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}