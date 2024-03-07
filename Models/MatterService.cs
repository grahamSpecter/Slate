using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Slate.Data;
using Slate.Models;

namespace Slate.Services
{
    public class MatterService
    {
        private readonly ApplicationDbContext _context;

        public MatterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Matter>> GetAllAsync()
        {
            return await _context.Matters.ToListAsync();
        }

        public async Task<Matter> GetByIdAsync(int matterId)
        {
            return await _context.Matters.FirstOrDefaultAsync(m => m.MatterID == matterId);
        }

        public async Task AddAsync(Matter matter)
        {
            _context.Matters.Add(matter);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Matter matter)
        {
            _context.Matters.Update(matter);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int matterId)
        {
            var matter = await _context.Matters.FirstOrDefaultAsync(m => m.MatterID == matterId);
            if (matter != null)
            {
                _context.Matters.Remove(matter);
                await _context.SaveChangesAsync();
            }
        }
    }
}
