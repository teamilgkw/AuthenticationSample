
using AuthenticationSample.BackEnd.BusinessLogic.Models;
using AuthenticationSample.BackEnd.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ILG_CRUD_Sample.BusinessLogic.Abstraction.Services
{
    public interface IOwnerMasterService
    {

        #region public functions
        Task<OwnerMasterRes> SelectByIdAsync(int nID);
        Task<IEnumerable<OwnerMasterRes>> SelectAllAsync();
        Task<IEnumerable<OwnerMasterRes>> SelectByCriteriaAsync(OwnerMasterSearchVM oOwnerMasterSearchVM);
        Task<bool> Insert(OwnerMasterRes oEntity);
        Task<bool> Update(OwnerMasterRes oEntity);
        Task<bool> DeleteByID(int nEntityID);
        #endregion

        #region data conversion
        List<OwnerMasterRes> lConvertToVMs(IEnumerable<OwnerMaster> lOwnerMasters);
        OwnerMasterRes oConvertToVM(OwnerMaster oOwnerMaster);
        OwnerMaster oConvertToDataModel(OwnerMasterRes oOwnerMasterVM);
        #endregion

    }
}
