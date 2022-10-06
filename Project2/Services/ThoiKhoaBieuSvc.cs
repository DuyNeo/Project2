using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.Models;
using Microsoft.EntityFrameworkCore;
namespace Project2.Services
{
    public interface IThoiKhoaBieu
    {
        public Task<List<Schedule>> GetThoiKhoaBieuAllAsync();
        public Task<bool> EditThoiKhoaBieuAsync(int id, Schedule thoiKhoaBieu);
        public Task<bool> AddThoiKhoaBieuAsync(Schedule thoiKhoaBieu);
        public Task<Schedule> GetThoiKhoaBieuAsync(int? id);
    }
    public class ThoiKhoaBieuSvc:IThoiKhoaBieu
    {
        protected DataContext _context;
        public ThoiKhoaBieuSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddThoiKhoaBieuAsync(Schedule thoiKhoaBieu)
        {
            _context.Add(thoiKhoaBieu);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> EditThoiKhoaBieuAsync(int id, Schedule thoiKhoaBieu)
        {
            _context.Update(thoiKhoaBieu);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Schedule>> GetThoiKhoaBieuAllAsync()
        {
            var dataContext = _context.schedules;
            return await dataContext.ToListAsync();
        }

        public async Task<Schedule> GetThoiKhoaBieuAsync(int? id)
        {
            var thoikhoabieu = await _context.schedules
                .FirstOrDefaultAsync(m => m.Id == id);
            if(thoikhoabieu == null)
            {
                return null;
            }
            return thoikhoabieu;
        }
    }
}
