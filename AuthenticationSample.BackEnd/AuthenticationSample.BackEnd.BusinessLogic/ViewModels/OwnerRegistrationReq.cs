using System.ComponentModel.DataAnnotations;

namespace AuthenticationSample.BackEnd.BusinessLogic.ViewModels
{
    public class OwnerRegistrationVM
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string MobileCountryCode { get; set; }
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