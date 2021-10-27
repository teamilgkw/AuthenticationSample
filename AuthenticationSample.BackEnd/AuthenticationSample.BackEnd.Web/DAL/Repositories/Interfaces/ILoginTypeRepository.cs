using AuthenticationSample.BackEnd.Web.DAL.Repositories;
using AuthenticationSample.BackEnd.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthenticationSample.BackEnd.Web.DAL.Repositories.Interfaces
{
    public interface ILoginTypeRepository
    {
        Task<LoginType> SelectByCode(string Code);
        Task<IEnumerable<LoginType>> SelectAll();
        Task UpdateById(LoginType entity);
        Task Insert(LoginType entity);
        Task DeleteById(string Id);
        Task SaveLoginType(LoginType entity);
    }
}
