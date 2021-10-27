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
            OwnerLogin ownerLogin = _ownerLoginRepository.SelectAll().Result.FirstOrDefault(ol => ol.EmailOrMobileNumber == password);
            if (ownerLogin == null)
            {
                return false;
            }
            return true;
        }
    }
}