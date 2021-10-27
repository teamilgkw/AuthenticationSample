using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationSample.BackEnd.Web.DAL.Repositories.Interfaces;
using AuthenticationSample.BackEnd.Web.Entities;
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
        public void Register(OwnerRegistrationVm ownerRegistrationVm)
        {
            OwnerMaster ownerMaster = new OwnerMaster()
            {
                FullName = ownerRegistrationVm.FullName,
                IsEnabled = true,
            };
            _ownerMasterRepository.Insert(ownerMaster);

            OwnerLogin ownerLogin = new OwnerLogin()
            {
                Password = ownerRegistrationVm.Password,
                EmailOrMobileNumber = ownerRegistrationVm.MobileNumber,
                OwnerMaster = ownerMaster,
                IsEnabled = true,
                IsVerified = true,
                LoginType = LoginType.MobileNumber
            };
            _ownerLoginRepository.Insert(ownerLogin);
            
            ownerMaster.OwnerLogins.Add(ownerLogin);
            _ownerMasterRepository.Update(ownerMaster);
            
        }

        public OwnerMaster Login(OwnerLoginVm ownerLoginVm)
        {
            OwnerLogin ownerLogin = _ownerLoginRepository.SelectAll().Result.FirstOrDefault(ol => ol.EmailOrMobileNumber == ownerLoginVm.EmailOrMobileNumber);
            if (ownerLogin == null)
            {
                throw new Exception("login failed");
            }
            return ownerLogin.OwnerMaster;
        }
    }
}