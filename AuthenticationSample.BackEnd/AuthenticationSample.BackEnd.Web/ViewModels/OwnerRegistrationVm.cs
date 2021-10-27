using System.ComponentModel.DataAnnotations;

namespace AuthenticationSample.BackEnd.Web.ViewModels
{
    public class OwnerRegistrationVm
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string MobileNumber { get; set; }  
        [Required]
        public string Email { get; set; }  
        [Required]
        public string Password { get; set; }  
        [Required]
        public string ConfirmPassword { get; set; }  
    }
}