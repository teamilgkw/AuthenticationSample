using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationSample.BackEnd.Web.Entities
{
    [Table("OwnerMaster")]
    public class OwnerMaster
    {
        [Key]
        public string ID { get; set; }
        public HashSet<OwnerLogin> OwnerLogins { get; set; } = new HashSet<OwnerLogin>();
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsEnabled { get; set; }
    }
}