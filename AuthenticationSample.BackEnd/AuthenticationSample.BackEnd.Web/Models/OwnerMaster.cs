using System;

namespace AuthenticationSample.BackEnd.Web.Models
{
    public class OwnerMaster
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsEnabled { get; set; }
    }
}