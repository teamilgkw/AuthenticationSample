using System;

namespace AuthenticationSample.BackEnd.Web.Services
{
    public class OtpService
    {
        private readonly EmailService _emailService;

        public OtpService(EmailService emailService)
        {
            _emailService = emailService;
        }
        public int OtpGenerator()
        {
            Random random = new Random();
            int otp  = random.Next(11111, 99999);
            return otp;
        }
        public bool SendEmailOtp(string email, int otp)
        {
            string mailBody = $"The OTP is {otp}";
            
            return _emailService.SendMail(email, "ILG OTP", mailBody);
        }
        public bool SendMobileOtp(string phone, int otp)
        {
            return true;
        }
    }
}