using AuthenticationSample.BackEnd.BusinessLogic.Models;
using AuthenticationSample.BackEnd.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthenticationSample.BackEnd.BusinessLogic.Abstraction.Repositories
{
    public interface IOwnerMasterRepository
    {
        Task<OwnerMaster> SelectById(string id);
        Task<IEnumerable<OwnerMaster>> SelectAll();
        Task Update(OwnerMaster entity);
        Task Insert(OwnerMaster entity);
        Task DeleteById(string Id);
        Task SaveOwnerMaster(OwnerMaster entity);
        Task<OwnerMaster> SelectByCriteriaAsync(OwnerMasterSearchVM OwnerMasterSearchViewModel);
    }
}
