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
        public Task<List<Subjects>> GetMonhocAllAsync();
        public Task<bool> EditMonhocAsync(int id, Subjects monHoc);
        public Task<bool> AddMonhocAsync(Subjects monHoc);
        public Task<Subjects> GetMonhocAsync(int? id);
    }
    public class MonHocSvc : IMonHoc
    {
        protected DataContext _context;
        public MonHocSvc(DataContext context)
        {
            _context = context; 
        }
        public async Task<bool> AddMonhocAsync(Subjects monHoc)
        {
            _context.Add(monHoc);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditMonhocAsync(int id, Subjects monHoc)
        {
            _context.Update(monHoc);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Subjects>> GetMonhocAllAsync()
        {
            var dataContext = _context.subjects;
            return await dataContext.ToListAsync();
        }

        public async Task<Subjects> GetMonhocAsync(int? id)
        {
            var monHoc = await _context.subjects
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if(monHoc == null)
            {
                return null;
            }
            return monHoc;
        }
    }
}
