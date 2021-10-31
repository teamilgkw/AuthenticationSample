using AuthenticationSample.BackEnd.BusinessLogic.Models;
using AuthenticationSample.BackEnd.BusinessLogic.ViewModels;
using AuthenticationSample.BackEnd.Web.DAL.Repositories.Interfaces;


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

    
    }
}