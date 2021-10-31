using System;
using System.Collections.Generic;
using System.Linq;

using AuthenticationSample.BackEnd.BusinessLogic.Abstraction.Repositories;
using AuthenticationSample.BackEnd.BusinessLogic.Models;
using AuthenticationSample.BackEnd.BusinessLogic.ViewModels;
using AuthenticationSample.BackEnd.Web.DAL.Repositories.Interfaces;


namespace AuthenticationSample.BackEnd.Web.Services
{
    public class OwnerService
    {
        #region Dependency Iinjection
        private readonly IOwnerMasterRepository _ownerMasterRepository;
        private readonly IOwnerLoginRepository _ownerLoginRepository;

        public OwnerService(IOwnerMasterRepository ownerMasterRepository, IOwnerLoginRepository ownerLoginRepository)
        {
            _ownerMasterRepository = ownerMasterRepository;
            _ownerLoginRepository = ownerLoginRepository;
        }
        #endregion

        #region Register

        public OwnerMaster Register(OwnerRegistrationVM oOwnerRegistrationVM)
        {
            OwnerMaster oOwnerMaster = oOwnerMasterCreate(oOwnerRegistrationVM);

            _ownerMasterRepository.Insert(oOwnerMaster);

            return oOwnerMaster;
        }

        private OwnerMaster oOwnerMasterCreate(OwnerRegistrationVM oOwnerRegistrationVM)
        {
            OwnerMaster oOwnerMaster = new OwnerMaster();

            oOwnerMaster.FullName = oOwnerRegistrationVM.FullName;
            oOwnerMaster.MobileNumber = oOwnerRegistrationVM.MobileNumber;
            oOwnerMaster.Email = oOwnerRegistrationVM.Email;
            oOwnerMaster.BirthDate = null;
            oOwnerMaster.IsEnabled = true;
            oOwnerMaster.OwnerLogins = lOwnerLoginsCreate(oOwnerRegistrationVM);

            return oOwnerMaster;
        }

        private List<OwnerLogin> lOwnerLoginsCreate(OwnerRegistrationVM oOwnerRegistrationVM)
        {
            List<OwnerLogin> lOwnerLogins = new List<OwnerLogin>();

            OwnerLogin oOwnerLogin = oOwnerLoginCreate(oOwnerRegistrationVM.MobileNumber, oOwnerRegistrationVM.Password, LoginType.MobileNumber);
            lOwnerLogins.Add(oOwnerLogin);


            oOwnerLogin = oOwnerLoginCreate(oOwnerRegistrationVM.Email, oOwnerRegistrationVM.Password, LoginType.Email);
            lOwnerLogins.Add(oOwnerLogin);

            return lOwnerLogins;

        }

        private OwnerLogin oOwnerLoginCreate(string sLoginIdentifier, string sPassword, LoginType oMobileNumber)
        {
            OwnerLogin oOwnerLogin = new OwnerLogin();
            
            oOwnerLogin.LoginIdentifier = sLoginIdentifier;
            oOwnerLogin.Password = sPassword;
            oOwnerLogin.LoginType = oMobileNumber;
            oOwnerLogin.IsEnabled = true;
            oOwnerLogin.IsVerified = true;

            return oOwnerLogin;
        }


        private bool bOwnerMasterValidate(OwnerMaster oOwnerMaster) 
        {
            return false;
        }


        #endregion






        public bool Login(OwnerLoginReq oOwnerLoginReq)
        {
            if (!IsEmailOrMobileNumberPasswordValid(oOwnerLoginReq.EmailOrMobileNumber, oOwnerLoginReq.Password))
            {
                throw new Exception("login failed");
            }
            return true;
        }



        private bool IsEmailOrMobileNumberExists(string emailOrMobileNumber)
        {
            OwnerLogin ownerLogin = _ownerLoginRepository.SelectAll().Result.FirstOrDefault(ol => ol.LoginIdentifier == emailOrMobileNumber);
            if (ownerLogin == null)
            {
                return false;
            }
            return true;
        }

        private bool IsEmailOrMobileNumberPasswordValid(string emailOrMobileNumber, string password)
        {
            OwnerLogin ownerLogin = _ownerLoginRepository.SelectAll().Result.FirstOrDefault(ol => ol.LoginIdentifier == password);
            if (ownerLogin == null)
            {
                return false;
            }
            return true;
        }



        #region old



        #endregion
    }
}