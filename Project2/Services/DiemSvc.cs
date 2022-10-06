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
        public Task<List<Score>> GetDiemAllAsync();
        public Task<bool> EditDiemAsync(int id, Score diem);
        public Task<bool> AddDiemAsync(Score diem);
        public Task<Score> GetDiemAsync(int? id);
    }
    public class DiemSvc:IDiem
    {
        protected DataContext _context;
        public DiemSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddDiemAsync(Score diem)
        {
            _context.Add(diem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditDiemAsync(int id, Score diem)
        {
            _context.Update(diem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Score>> GetDiemAllAsync()
        {
            var dataContext = _context.scores;
            return await dataContext.ToListAsync();
        }

        public async Task<Score> GetDiemAsync(int? id)
        {
            var diem = await _context.scores
               .FirstOrDefaultAsync(m => m.ScoreId == id);
            if(diem == null)
            {
                return null;
            }
            return diem;
        }
    }
}
