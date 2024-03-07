using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Slate.Data;
using Slate.Models;

namespace Slate.Services
{
    public class EntityService
    {
        private readonly ApplicationDbContext _context;

        public EntityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Entity>> GetAllAsync()
        {
            return await _context.Entities.ToListAsync();
        }

        public async Task<Entity> GetByIdAsync(string entityId)
        {
            return await _context.Entities.FirstOrDefaultAsync(e => e.EntityID == entityId);
        }

        public async Task AddAsync(Entity entity)
        {
            _context.Entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Entity entity)
        {
            _context.Entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string entityId)
        {
            var entity = await _context.Entities.FirstOrDefaultAsync(e => e.EntityID == entityId);
            if (entity != null)
            {
                _context.Entities.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
