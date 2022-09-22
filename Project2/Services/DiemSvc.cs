using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2.Models;
namespace Project2.Services
{
    public interface IDiem
    {
        public Task<List<Diem>> GetDiemAllAsync();
        public Task<bool> EditDiemAsync(int id, Diem diem);
        public Task<bool> AddDiemAsync(Diem diem);
        public Task<Diem> GetDiemAsync(int? id);
    }
    public class DiemSvc:IDiem
    {
        protected DataContext _context;
        public DiemSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddDiemAsync(Diem diem)
        {
            _context.Add(diem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditDiemAsync(int id, Diem diem)
        {
            _context.Update(diem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Diem>> GetDiemAllAsync()
        {
            var dataContext = _context.diems;
            return await dataContext.ToListAsync();
        }

        public async Task<Diem> GetDiemAsync(int? id)
        {
            var diem = await _context.diems
               .FirstOrDefaultAsync(m => m.diemId == id);
            if(diem == null)
            {
                return null;
            }
            return diem;
        }
    }
}
