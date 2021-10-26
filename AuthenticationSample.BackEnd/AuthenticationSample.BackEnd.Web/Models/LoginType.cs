using System.ComponentModel.DataAnnotations;

namespace AuthenticationSample.BackEnd.Web.Models
{
    public class LoginType
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
    }
}