using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.Models;
using Microsoft.EntityFrameworkCore;
namespace Project2.Services
{
    public interface ILoaiDiem
    {
        public Task<List<LoaiDiem>> GetLoaidiemAllAsync();
        public Task<bool> EditLoaidiemAsync(int id, LoaiDiem loaiDiem);
        public Task<bool> AddLoaidiemAsync(LoaiDiem loaiDiem);
        public Task<LoaiDiem> GetLoaidiemAsync(int? id);
    }
    public class LoaiDiemSvc:ILoaiDiem
    {
        protected DataContext _context;
        public LoaiDiemSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddLoaidiemAsync(LoaiDiem loaiDiem)
        {
            _context.Add(loaiDiem);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> EditLoaidiemAsync(int id, LoaiDiem loaiDiem)
        {
            _context.Update(loaiDiem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<LoaiDiem>> GetLoaidiemAllAsync()
        {
            var dataContext = _context.loaiDiems;
            return await dataContext.ToListAsync();
        }

        public async Task<LoaiDiem> GetLoaidiemAsync(int? id)
        {
            var loaidiem = await _context.loaiDiems
                .FirstOrDefaultAsync(m => m.loaiDiemId == id);
            if(loaidiem == null)
            {
                return null;
            }
            return loaidiem;
        }
    }
}
