using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2.Models;
namespace Project2.Services
{
    public interface IMonHoc
    {
        public Task<List<MonHoc>> GetMonhocAllAsync();
        public Task<bool> EditMonhocAsync(int id, MonHoc monHoc);
        public Task<bool> AddMonhocAsync(MonHoc monHoc);
        public Task<MonHoc> GetMonhocAsync(int? id);
    }
    public class MonHocSvc : IMonHoc
    {
        protected DataContext _context;
        public MonHocSvc(DataContext context)
        {
            _context = context; 
        }
        public async Task<bool> AddMonhocAsync(MonHoc monHoc)
        {
            _context.Add(monHoc);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditMonhocAsync(int id, MonHoc monHoc)
        {
            _context.Update(monHoc);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<MonHoc>> GetMonhocAllAsync()
        {
            var dataContext = _context.monHocs;
            return await dataContext.ToListAsync();
        }

        public async Task<MonHoc> GetMonhocAsync(int? id)
        {
            var monHoc = await _context.monHocs
                .FirstOrDefaultAsync(m => m.monHocId == id);
            if(monHoc == null)
            {
                return null;
            }
            return monHoc;
        }
    }
}
