using AuthenticationSample.BackEnd.Web.DAL.Repositories.Interfaces;
using AuthenticationSample.BackEnd.Web.Entities;
using AuthenticationSample.BackEnd.Web.ViewModels;

namespace AuthenticationSample.BackEnd.Web.Factories
{
    public  class OwnerFactory
    {
        private readonly IOwnerMasterRepository _ownerMasterRepository;
        private readonly IOwnerLoginRepository _ownerLoginRepository;

        public OwnerFactory(IOwnerMasterRepository ownerMasterRepository, IOwnerLoginRepository ownerLoginRepository)
        {
            _ownerMasterRepository = ownerMasterRepository;
            _ownerLoginRepository = ownerLoginRepository;
        }

        public OwnerMaster CreateOwner(OwnerRegistrationVm ownerRegistrationVm)
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

            return ownerMaster;
        }
    }
}