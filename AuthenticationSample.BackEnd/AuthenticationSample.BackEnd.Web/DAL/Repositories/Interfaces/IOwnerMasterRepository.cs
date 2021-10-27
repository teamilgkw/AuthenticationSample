using AuthenticationSample.BackEnd.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthenticationSample.BackEnd.Web.DAL.Repositories.Interfaces
{
    public interface IOwnerMasterRepository
    {
        Task<OwnerMaster> GetById(string id);
        Task<IEnumerable<OwnerMaster>> GetAll();
        Task<IEnumerable<OwnerMaster>> Find(Expression<Func<OwnerMaster, bool>> expression);
        Task Add(OwnerMaster entity);
        Task AddRange(IEnumerable<OwnerMaster> entities);
        Task Remove(OwnerMaster entity);
        Task RemoveRange(IEnumerable<OwnerMaster> entities);
        Task SaveOwnerMaster(OwnerMaster entity);
    }
}
