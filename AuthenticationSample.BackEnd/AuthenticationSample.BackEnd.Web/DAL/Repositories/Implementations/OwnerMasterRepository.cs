using AuthenticationSample.BackEnd.Web.DAL.Repositories.Interfaces;
using AuthenticationSample.BackEnd.Web.Data;
using AuthenticationSample.BackEnd.Web.Models;
using AuthenticationSample.BackEnd.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationSample.BackEnd.Web.DAL.Repositories.Implementations
{
    public class OwnerMasterRepository : IOwnerMasterRepository
    {
        private AppDbContext _context;
        private DbSet<OwnerMaster> OwnerMasterEntity;
        public OwnerMasterRepository(AppDbContext context)
        {
            _context = context;
            OwnerMasterEntity = context.Set<OwnerMaster>();
        }

        public async Task Insert(OwnerMaster entity)
        {
            await _context.OwnerMasters.AddAsync(entity);
        }

        public async Task<IEnumerable<OwnerMaster>> SelectAll()
        {
            return await _context.OwnerMasters.ToListAsync();
        }

        public async Task<OwnerMaster> SelectById(string id)
        {
            return await _context.OwnerMasters.FirstOrDefaultAsync(ow => ow.ID == id);
        }

        public async Task DeleteById(string Id)
        {
            OwnerMaster ownerMaster = await _context.OwnerMasters.FindAsync(Id);
            _context.OwnerMasters.Remove(ownerMaster);
        }



        public async Task SaveOwnerMaster(OwnerMaster entity)
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateById(OwnerMaster entity)
        {
            OwnerMasterEntity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task<OwnerMaster> SelectByCriteriaAsync(OwnerMasterSearchViewModel OwnerMasterSearchViewModel)
        {
            IQueryable<OwnerLogin> oLoginTypeIQueryable = _context.OwnerLogins.AsQueryable();
            if (OwnerMasterSearchViewModel != null)
            {
                if (!string.IsNullOrEmpty(OwnerMasterSearchViewModel.FullName))
                {
                    return _context.OwnerMasters.Where(dd => dd.FullName == OwnerMasterSearchViewModel.FullName).SingleOrDefault();
                }
                else
                 if (!string.IsNullOrEmpty(OwnerMasterSearchViewModel.EmailOrMobile))
                {
                    oLoginTypeIQueryable = oLoginTypeIQueryable.Where(e => e.EmailOrMobile.Contains(OwnerMasterSearchViewModel.EmailOrMobile)).Include(ff => ff.OwnerMaster);
                    return  oLoginTypeIQueryable.FirstOrDefaultAsync().Result.OwnerMaster;
                }
            }
            throw new Exception("Please Type your search");
        }
    }
}
