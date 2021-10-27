using AuthenticationSample.BackEnd.Web.DAL.Repositories;
using AuthenticationSample.BackEnd.Web.Models;
using AuthenticationSample.BackEnd.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthenticationSample.BackEnd.Web.DAL.Repositories.Interfaces
{
    public interface IOwnerMasterRepository
    {
        Task<OwnerMaster> SelectById(string id);
        Task<IEnumerable<OwnerMaster>> SelectAll();
        Task UpdateById( OwnerMaster entity);
        Task Insert(OwnerMaster entity);
        Task DeleteById(string Id);
        Task SaveOwnerMaster(OwnerMaster entity);
        Task<OwnerMaster> SelectByCriteriaAsync(OwnerMasterSearchViewModel OwnerMasterSearchViewModel);
    }
}
