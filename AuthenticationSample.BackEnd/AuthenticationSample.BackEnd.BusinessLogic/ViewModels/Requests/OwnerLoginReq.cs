using System.ComponentModel.DataAnnotations;

namespace AuthenticationSample.BackEnd.BusinessLogic.ViewModels
{
    public class OwnerLoginReq
    {
        [Required]
        public string EmailOrMobileNumber { get; set; }
        [Required]
        public string Password { get; set; }
    }
}