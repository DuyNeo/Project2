using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.Models;
using Microsoft.EntityFrameworkCore;
namespace Project2.Services
{
    public interface IKhoaHoc
    {
        public Task<List<Course>> GetKhoahocAllAsync();
        public Task<bool> EditKhoahocAsync(int id, Course khoaHoc);
        public Task<bool> AddKhoahocAsync(Course khoaHoc);
        public Task<Course> GetKhoahocAsync(int? id);
    }
    public class KhoaHocSvc:IKhoaHoc
    {
        protected DataContext _context;
        public KhoaHocSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddKhoahocAsync(Course khoaHoc)
        {
            _context.Add(khoaHoc);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> EditKhoahocAsync(int id, Course khoaHoc)
        {
            _context.Update(khoaHoc);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Course>> GetKhoahocAllAsync()
        {
            var dataContext = _context.courses;
            return await dataContext.ToListAsync();
        }

        public async Task<Course> GetKhoahocAsync(int? id)
        {
            var khoahoc = await _context.courses
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if(khoahoc == null) 
            {
                return null;
            }
            return khoahoc; 
        }
    }
}
