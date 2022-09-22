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
        public Task<List<KhoaHoc>> GetKhoahocAllAsync();
        public Task<bool> EditKhoahocAsync(int id, KhoaHoc khoaHoc);
        public Task<bool> AddKhoahocAsync(KhoaHoc khoaHoc);
        public Task<KhoaHoc> GetKhoahocAsync(int? id);
    }
    public class KhoaHocSvc:IKhoaHoc
    {
        protected DataContext _context;
        public KhoaHocSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddKhoahocAsync(KhoaHoc khoaHoc)
        {
            _context.Add(khoaHoc);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<bool> EditKhoahocAsync(int id, KhoaHoc khoaHoc)
        {
            _context.Update(khoaHoc);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<KhoaHoc>> GetKhoahocAllAsync()
        {
            var dataContext = _context.khoaHocs;
            return await dataContext.ToListAsync();
        }

        public async Task<KhoaHoc> GetKhoahocAsync(int? id)
        {
            var khoahoc = await _context.khoaHocs
                .FirstOrDefaultAsync(m => m.khoaHocId == id);
            if(khoahoc == null) 
            {
                return null;
            }
            return khoahoc;
        }
    }
}
