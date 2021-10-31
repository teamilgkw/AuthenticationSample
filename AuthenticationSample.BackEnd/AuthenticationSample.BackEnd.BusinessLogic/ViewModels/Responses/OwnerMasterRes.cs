using System.ComponentModel.DataAnnotations;

namespace AuthenticationSample.BackEnd.BusinessLogic.ViewModels
{
    public class OwnerMasterRes
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string CountryCode { get; set; }
        public bool IsEnabled { get; set; }
    }
}