using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AuthenticationSample.BackEnd.BusinessLogic.Models;
using AuthenticationSample.BackEnd.BusinessLogic.ViewModels;
using AuthenticationSample.BackEnd.BusinessLogic.Abstraction.Repositories;

namespace AuthenticationSample.BackEnd.DataAccess
{
    public class OwnerMasterRepository : IOwnerMasterRepository
    {
        private AuthenticationSampleContext _context;
        private DbSet<OwnerMaster> OwnerMasterEntity;
        public OwnerMasterRepository(AuthenticationSampleContext context)
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

        public async Task Update(OwnerMaster entity)
        {
            OwnerMasterEntity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }


        public async Task<OwnerMaster> SelectByCriteriaAsync(OwnerMasterSearchVM OwnerMasterSearchViewModel)
        {
            IQueryable<OwnerLogin> oLoginTypeIQueryable = _context.OwnerLogins.AsQueryable();
            if (OwnerMasterSearchViewModel != null)
            {
                if (!string.IsNullOrEmpty(OwnerMasterSearchViewModel.FullName))
                {
                    return _context.OwnerMasters.Where(dd => dd.FullName == OwnerMasterSearchViewModel.FullName).SingleOrDefault();
                }
              

                 if (!string.IsNullOrEmpty(OwnerMasterSearchViewModel.MobileNumber))
                {
                    oLoginTypeIQueryable = oLoginTypeIQueryable.Where(e => e.LoginIdentifier.Contains(OwnerMasterSearchViewModel.MobileNumber)).Include(ff => ff.OwnerMaster);
                    return oLoginTypeIQueryable.FirstOrDefaultAsync().Result.OwnerMaster;
                }

                if (!string.IsNullOrEmpty(OwnerMasterSearchViewModel.Email))
                {
                    oLoginTypeIQueryable = oLoginTypeIQueryable.Where(e => e.LoginIdentifier.Contains(OwnerMasterSearchViewModel.Email)).Include(ff => ff.OwnerMaster);
                    return oLoginTypeIQueryable.FirstOrDefaultAsync().Result.OwnerMaster;
                }
            }
            throw new Exception("Please Type your search");
        }
    }
}
