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
        public Task<List<ThoiKhoaBieu>> GetThoiKhoaBieuAllAsync();
        public Task<bool> EditThoiKhoaBieuAsync(int id, ThoiKhoaBieu thoiKhoaBieu);
        public Task<bool> AddThoiKhoaBieuAsync(ThoiKhoaBieu thoiKhoaBieu);
        public Task<ThoiKhoaBieu> GetThoiKhoaBieuAsync(int? id);
    }
    public class ThoiKhoaBieuSvc:IThoiKhoaBieu
    {
        protected DataContext _context;
        public ThoiKhoaBieuSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddThoiKhoaBieuAsync(ThoiKhoaBieu thoiKhoaBieu)
        {
            _context.Add(thoiKhoaBieu);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> EditThoiKhoaBieuAsync(int id, ThoiKhoaBieu thoiKhoaBieu)
        {
            _context.Update(thoiKhoaBieu);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ThoiKhoaBieu>> GetThoiKhoaBieuAllAsync()
        {
            var dataContext = _context.thoiKhoaBieus;
            return await dataContext.ToListAsync();
        }

        public async Task<ThoiKhoaBieu> GetThoiKhoaBieuAsync(int? id)
        {
            var thoikhoabieu = await _context.thoiKhoaBieus
                .FirstOrDefaultAsync(m => m.Id == id);
            if(thoikhoabieu == null)
            {
                return null;
            }
            return thoikhoabieu;
        }
    }
}
