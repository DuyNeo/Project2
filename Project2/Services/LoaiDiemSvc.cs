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
        public Task<List<PointType>> GetLoaidiemAllAsync();
        public Task<bool> EditLoaidiemAsync(int id, PointType loaiDiem);
        public Task<bool> AddLoaidiemAsync(PointType loaiDiem);
        public Task<PointType> GetLoaidiemAsync(int? id);
    }
    public class LoaiDiemSvc:ILoaiDiem
    {
        protected DataContext _context;
        public LoaiDiemSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddLoaidiemAsync(PointType loaiDiem)
        {
            _context.Add(loaiDiem);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> EditLoaidiemAsync(int id, PointType loaiDiem)
        {
            _context.Update(loaiDiem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<PointType>> GetLoaidiemAllAsync()
        {
            var dataContext = _context.pointTypes
                ;
            return await dataContext.ToListAsync();
        }

        public async Task<PointType> GetLoaidiemAsync(int? id)
        {
            var loaidiem = await _context.pointTypes
                .FirstOrDefaultAsync(m => m.PointTypeId == id);
            if(loaidiem == null)
            {
                return null;
            }
            return loaidiem;
        }
    }
}
