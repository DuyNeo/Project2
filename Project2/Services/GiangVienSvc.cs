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
         Task<List<GiangVien>> GetGiangvienAllAsync();
         Task<bool> EditGiangvienAsync(int id, GiangVien giangVien);
         Task<int> AddGiangvienAsync(GiangVien giangVien);
         Task<GiangVien> GetGiangvienAsync(int? id);
    }
    public class GiangVienSvc:IGiangVien
    {
        private readonly DataContext _context;
        public GiangVienSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<int> AddGiangvienAsync(GiangVien giangVien)
        {
            int ret = 0;
            try 
            {
                //giangVien.role.roleId =  1  ;
                await _context.AddAsync(giangVien);
                await _context.SaveChangesAsync();
                ret = giangVien.gvId;
            }
            catch
            {
                ret = 0;
            }
          
            return ret;
        }

        public async Task<bool> EditGiangvienAsync(int id,GiangVien giangVien)
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
