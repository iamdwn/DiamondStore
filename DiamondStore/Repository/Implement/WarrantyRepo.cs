﻿using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implement
{
    public class WarrantyRepo : IBaseCRUD<Warranty>
    {
        public async Task<Warranty> AddAsync(Warranty entity)
        {
            using (var _context = new DiamondStoreContext())
            {
                await _context.Warranties.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
        }

        public async Task DeleteAsync(string id)
        {
            using (var _context = new DiamondStoreContext())
            {
                var entity = await _context.Set<Warranty>().FindAsync(id);
                if (entity != null)
                {
                    _context.Warranties.Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<IEnumerable<Warranty>> FindAsync(Expression<Func<Warranty, bool>> predicate)
        {
            using (var _context = new DiamondStoreContext())
            {
                return await _context.Warranties.AsNoTracking().Where(predicate).ToListAsync();
            }
        }

        public async Task<IEnumerable<Warranty>> GetAllAsync()
        {
            using (var _context = new DiamondStoreContext())
            {
                return await _context.Warranties
                        .Include(w => w.Product)
                        .Include(w => w.User).AsNoTracking().ToListAsync();
            }
        }

        public async Task<Warranty> GetByIdAsync(string id)
        {
            try
            {
                using (var _context = new DiamondStoreContext())
                {
                    return await _context.Warranties.Include(w => w.Product)
                        .Include(w => w.User).AsNoTracking().FirstAsync(o => o.WarrantyId == Guid.Parse(id));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Warranty> UpdateAsync(Warranty entity)
        {
            using (var _context = new DiamondStoreContext())
            {
                _context.Warranties.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
        }
    }
}
