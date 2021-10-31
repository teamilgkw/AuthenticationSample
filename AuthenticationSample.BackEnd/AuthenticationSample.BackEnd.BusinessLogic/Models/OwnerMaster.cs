using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationSample.BackEnd.BusinessLogic.Models
{
    [Table("OwnerMaster")]
    public class OwnerMaster
    {
        [Key]
        public string ID { get; set; }

        public string FullName { get; set; }
        public string MobileNumberCountryCode { get; set; }

        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsEnabled { get; set; }

        public List<OwnerLogin> OwnerLogins { get; set; }
    }
}