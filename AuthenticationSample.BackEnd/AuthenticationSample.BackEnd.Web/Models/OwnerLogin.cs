namespace AuthenticationSample.BackEnd.Web.Models
{
    public class OwnerLogin
    {
        public int Id { get; set; }
        public OwnerMaster OwnerMaster { get; set; }
        public LoginType LoginType { get; set; }
        public string EmailOrMobile { get; set; }
        public string Password { get; set; }
        public bool IsVerified { get; set; }
        public bool IsEnabled { get; set; }

    }
}