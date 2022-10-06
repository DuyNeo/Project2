using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2.Models;
namespace Project2.Services
{
    public interface ILopHoc
    {
        public Task<List<Class>> GetLophocAllAsync();
        public Task<bool> EditLophocAsync(int id, Class lopHoc);
        public Task<bool> AddLophocAsync(Class lopHoc);
        public Task<Class> GetLophocAsync(int? id);
        Task<bool> isId(int id);//kiem tra ton tai cua email

    }

    public class LopHocSvc : ILopHoc
    {
        protected DataContext _context;
        public LopHocSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddLophocAsync(Class lopHoc)
        {
            bool ret = false;
            try
            {
              _context.Add(lopHoc);
            await _context.SaveChangesAsync();
            ret = true;
            }
            catch
            {
            }
            return ret;
        }

        public async Task<bool> EditLophocAsync(int id, Class lopHoc)
        {
            //var lopHoc1 = await _context.lopHocs.FindAsync(id);
            //if (lopHoc == null)
            //{
            //    return false;
            //}
            //return true;
            _context.classes.Update(lopHoc);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Class>> GetLophocAllAsync()
        {
            var dataContext = _context.classes;
            return await dataContext.ToListAsync();
        }

        public async Task<Class> GetLophocAsync(int? id)
        {
            var lopHoc = await _context.classes
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if(lopHoc == null)
            {
                return null;
            }
            return lopHoc;
        }
        public async Task<bool> isId(int id)
        {
            bool ret = false;
            try
            {
                Users nguoiDung = await _context.users.Where(x => x.UserId == id).FirstOrDefaultAsync();
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
