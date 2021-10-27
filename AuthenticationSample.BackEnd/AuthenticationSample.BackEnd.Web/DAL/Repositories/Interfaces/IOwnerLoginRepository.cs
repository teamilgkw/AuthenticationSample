using AuthenticationSample.BackEnd.Web.DAL.Repositories.Services;
using AuthenticationSample.BackEnd.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthenticationSample.BackEnd.Web.DAL.Repositories.Interfaces
{
    public interface IOwnerLoginRepository
    {
        Task<OwnerLogin> SelectById(int id);
        Task<IEnumerable<OwnerLogin>> SelectAll();
        Task UpdateById(OwnerLogin entity);
        Task Insert(OwnerLogin entity);
        Task DeleteById(string Id);
        Task SaveOwnerLogin(OwnerLogin entity);
    }
}
