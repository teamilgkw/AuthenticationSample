using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationSample.BackEnd.Web.DAL.Repositories.Interfaces;
using AuthenticationSample.BackEnd.Web.Entities;
using AuthenticationSample.BackEnd.Web.Factories;
using AuthenticationSample.BackEnd.Web.ViewModels;

namespace AuthenticationSample.BackEnd.Web.Services
{
    public class RegistrationService
    {
        private readonly IOwnerMasterRepository _ownerMasterRepository;
        private readonly IOwnerLoginRepository _ownerLoginRepository;

        public RegistrationService(IOwnerMasterRepository ownerMasterRepository, IOwnerLoginRepository ownerLoginRepository)
        {
            _ownerMasterRepository = ownerMasterRepository;
            _ownerLoginRepository = ownerLoginRepository;
        }
        public OwnerMaster Register(OwnerRegistrationVm ownerRegistrationVm)
        {
            OwnerFactory ownerFactory = new OwnerFactory(_ownerMasterRepository, _ownerLoginRepository);
            OwnerMaster ownerMaster = ownerFactory.CreateOwner(ownerRegistrationVm);
            
            return ownerMaster;

        }

        public bool Login(OwnerLoginVm ownerLoginVm)
        {
            if (!IsEmailOrMobileNumberPasswordValid(ownerLoginVm.EmailOrMobileNumber, ownerLoginVm.Password))
            {
                throw new Exception("login failed");
            }
            return true;
        }

        public int OtpToRecoverPassword(string emailOrMobileNumber)
        {
            if (!IsEmailOrMobileNumberExists(emailOrMobileNumber))
            {
                throw new Exception("InValid Email Or Mobile Number");
            }
            Random random = new Random();
            int otp  = random.Next(11111, 99999);
            return otp;
        }

        public void ChangePassword(string ownerMasterId, string newPassword)
        {
            if (_ownerMasterRepository.SelectById(ownerMasterId).Result == null)
            {
                throw new Exception("user not exists");
            }
            
            List<OwnerLogin> ownerLogins = _ownerLoginRepository.SelectAll().Result.Where(ol => ol.OwnerMaster.ID == ownerMasterId).ToList();
            
            foreach (OwnerLogin ownerLogin in ownerLogins)
            {
                ownerLogin.Password = newPassword;
            }
        }

        private bool IsEmailOrMobileNumberExists(string emailOrMobileNumber)
        {
            OwnerLogin ownerLogin =  _ownerLoginRepository.SelectAll().Result.FirstOrDefault(ol => ol.EmailOrMobileNumber == emailOrMobileNumber);
            if (ownerLogin == null)
            {
                return false;
            }
            return true;
        }

        private bool IsEmailOrMobileNumberPasswordValid(string emailOrMobileNumber, string password)
        {
            OwnerLogin ownerLogin = _ownerLoginRepository.SelectAll().Result.
                FirstOrDefault(ol => ol.EmailOrMobileNumber == emailOrMobileNumber && ol.Password == password);
            if (ownerLogin == null)
            {
                return false;
            }
            return true;
        }
        
        
    }
}