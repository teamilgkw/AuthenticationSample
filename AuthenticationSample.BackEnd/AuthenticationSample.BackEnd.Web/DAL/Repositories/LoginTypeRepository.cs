using AuthenticationSample.BackEnd.Web.DAL.Repositories.Interfaces;
using AuthenticationSample.BackEnd.Web.Data;
using AuthenticationSample.BackEnd.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationSample.BackEnd.Web.DAL.Repositories
{
    public class LoginTypeRepository : ILoginTypeRepository
    {
        private AppDbContext _context;
        private DbSet<LoginType> LoginTypeEntity;
        public LoginTypeRepository(AppDbContext context)
        {
            _context = context;
            LoginTypeEntity = context.Set<LoginType>();
        }

        public async Task Insert(LoginType entity)
        {
            await _context.LoginTypes.AddAsync(entity);
        }

        public async Task<IEnumerable<LoginType>> SelectAll()
        {
            return await _context.LoginTypes.ToListAsync();
        }

        public async Task<LoginType> SelectByCode(string Code)
        {
            return await _context.LoginTypes.FirstOrDefaultAsync(ow => ow.Code ==Code);
        }

        public async Task DeleteById(string Id)
        {
            LoginType LoginType = await _context.LoginTypes.FindAsync(Id);
            _context.LoginTypes.Remove(LoginType);
        }



        public async Task SaveLoginType(LoginType entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(LoginType entity)
        {
            LoginTypeEntity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
