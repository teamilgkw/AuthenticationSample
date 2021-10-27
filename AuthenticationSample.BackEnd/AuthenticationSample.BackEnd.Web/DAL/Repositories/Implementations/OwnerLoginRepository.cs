using AuthenticationSample.BackEnd.Web.DAL.Repositories.Interfaces;
using AuthenticationSample.BackEnd.Web.Data;
using AuthenticationSample.BackEnd.Web.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationSample.BackEnd.Web.DAL.Repositories.Implementations
{
    public class OwnerLoginRepository : IOwnerLoginRepository
    {
        private AppDbContext _context;
        private DbSet<OwnerLogin> OwnerLoginEntity;
        public OwnerLoginRepository(AppDbContext context)
        {
            _context = context;
            OwnerLoginEntity = context.Set<OwnerLogin>();
        }

        public async Task Insert(OwnerLogin entity)
        {
            await _context.OwnerLogins.AddAsync(entity);
        }

        public async Task<IEnumerable<OwnerLogin>> SelectAll()
        {
            return await _context.OwnerLogins.ToListAsync();
        }

        public async Task<OwnerLogin> SelectById(int Id)
        {
            return await _context.OwnerLogins.FirstOrDefaultAsync(ow => ow.ID ==Id);
        }

        public async Task DeleteById(string Id)
        {
            OwnerLogin OwnerLogin = await _context.OwnerLogins.FindAsync(Id);
            _context.OwnerLogins.Remove(OwnerLogin);
        }



        public async Task SaveOwnerLogin(OwnerLogin entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById( OwnerLogin entity)
        {
            OwnerLoginEntity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
