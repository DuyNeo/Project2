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
        public Task<List<LopHoc>> GetLophocAllAsync();
        public Task<bool> EditLophocAsync(int id, LopHoc lopHoc);
        public Task<bool> AddLophocAsync(LopHoc lopHoc);
        public Task<LopHoc> GetLophocAsync(int? id);
    }

    public class LopHocSvc : ILopHoc
    {
        protected DataContext _context;
        public LopHocSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddLophocAsync(LopHoc lopHoc)
        {
            _context.Add(lopHoc);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditLophocAsync(int id, LopHoc lopHoc)
        {
            //var lopHoc1 = await _context.lopHocs.FindAsync(id);
            //if (lopHoc == null)
            //{
            //    return false;
            //}
            //return true;
            _context.lopHocs.Update(lopHoc);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<LopHoc>> GetLophocAllAsync()
        {
            var dataContext = _context.lopHocs;
            return await dataContext.ToListAsync();
        }

        public async Task<LopHoc> GetLophocAsync(int? id)
        {
            var lopHoc = await _context.lopHocs
                .FirstOrDefaultAsync(m => m.lopHocId == id);
            if(lopHoc == null)
            {
                return null;
            }
            return lopHoc;
        }
    }
}
