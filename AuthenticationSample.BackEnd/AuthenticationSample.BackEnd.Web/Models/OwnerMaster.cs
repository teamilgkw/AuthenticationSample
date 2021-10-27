using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationSample.BackEnd.Web.Models
{
    [Table("OwnerMaster")]
    public class OwnerMaster
    {
        public string Id { get; set; }
        public HashSet<LoginType> LoginTypes { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsEnabled { get; set; }
    }
}