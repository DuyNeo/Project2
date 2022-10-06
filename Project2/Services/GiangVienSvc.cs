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
         Task<List<Teachers>> GetGiangvienAllAsync();
         Task<bool> EditGiangvienAsync(int id, Teachers giangVien);
         Task<bool> AddGiangvienAsync(Teachers giangVien);
         Task<Teachers> GetGiangvienAsync(int? id);
        Task<bool> isEmail(string email);
    }
    public class GiangVienSvc:IGiangVien
    {
        private readonly DataContext _context;
        public GiangVienSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddGiangvienAsync(Teachers giangVien)
        {
            //int ret = 0;
            //try 
            //{

            //    await _context.AddAsync(giangVien);
            //    await _context.SaveChangesAsync();
            //    ret = giangVien.TeachersId;
            //}
            //catch
            //{
            //    ret = 0;
            //}

            //return ret;
            _context.Add(giangVien);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditGiangvienAsync(int id,Teachers giangVien)
        {
            _context.Update(giangVien);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Teachers>> GetGiangvienAllAsync()
        {
            var dataContext = _context.teachers;
            return await dataContext.ToListAsync();
        }

        public async Task<Teachers> GetGiangvienAsync(int? id)
        {
            var giangvien = await _context.teachers
                .FirstOrDefaultAsync(m => m.TeachersId == id);
            if(giangvien == null)
            {
                return null;
            }
            return giangvien;
        }

        public async Task<bool> isEmail(string email)
        {
            bool ret = false;
            try
            {
                Users nguoiDung = await _context.users.Where(x => x.Email == email).FirstOrDefaultAsync();
                if (nguoiDung != null)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
    }
}
