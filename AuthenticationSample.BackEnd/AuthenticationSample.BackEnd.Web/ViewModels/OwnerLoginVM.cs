using System.ComponentModel.DataAnnotations;

namespace AuthenticationSample.BackEnd.Web.ViewModels
{
    public class OwnerLoginVm
    {
        [Required]
        public string EmailOrMobileNumber { get; set; }  
        [Required]
        public string Password { get; set; }  
    }
}