using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2.Models;
namespace Project2.Services
{
    public interface ILichNghi
    {
        public Task<List<HolidaySchedule>> GetLichNghiAllAsync();
        public Task<bool> EditLichNghiAsync(int id, HolidaySchedule LichNghi);
        public Task<bool> AddLichNghiAsync(HolidaySchedule LichNghi);
        public Task<HolidaySchedule> GetLichNghiAsync(int? id);
    }
    public class LichNghiSvc : ILichNghi
    {
        protected DataContext _context;
        public LichNghiSvc(DataContext context)
        {
            _context = context; 
        }
        public async Task<bool> AddLichNghiAsync(HolidaySchedule LichNghi)
        {
            _context.Add(LichNghi);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditLichNghiAsync(int id, HolidaySchedule LichNghi)
        {
            _context.Update(LichNghi);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<HolidaySchedule>> GetLichNghiAllAsync()
        {
            var dataContext = _context.holidaySchedules;
            return await dataContext.ToListAsync();
        }

        public async Task<HolidaySchedule> GetLichNghiAsync(int? id)
        {
            var LichNghi = await _context.holidaySchedules
                .FirstOrDefaultAsync(m => m.HolidayId == id);
            if(LichNghi == null)
            {
                return null;
            }
            return LichNghi;
        }
    }
}
