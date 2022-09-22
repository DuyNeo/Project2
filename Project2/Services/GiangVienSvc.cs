using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2.Models;

namespace Project2.Services
{
    public interface IGiangVien
    {
        public Task<List<GiangVien>> GetGiangvienAllAsync();
        public Task<bool> EditGiangvienAsync(int id, GiangVien giangVien);
        public Task<int> AddGiangvienAsync(GiangVien giangVien);
        public Task<GiangVien> GetGiangvienAsync(int? id);
    }
    public class GiangVienSvc:IGiangVien
    {
        protected DataContext _context;
        public GiangVienSvc(DataContext context)
        {
            _context = context;
        }

        public  Task<int> AddGiangvienAsync(GiangVien giangVien)
        {
            int ret = 0;
            try 
            {
                _context.Add(giangVien);
                 _context.SaveChangesAsync();
                ret = giangVien.gvId;
            }
            catch
            {
                ret = 0;
            }
          
            return Task.FromResult(ret);
        }

        public async Task<bool> EditGiangvienAsync(int id, GiangVien giangVien)
        {
            _context.Update(giangVien);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GiangVien>> GetGiangvienAllAsync()
        {
            var dataContext = _context.giangViens;
            return await dataContext.ToListAsync();
        }

        public async Task<GiangVien> GetGiangvienAsync(int? id)
        {
            var giangvien = await _context.giangViens
                .FirstOrDefaultAsync(m => m.gvId == id);
            if(giangvien == null)
            {
                return null;
            }
            return giangvien;
        }
    }
}
