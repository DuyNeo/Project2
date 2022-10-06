using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2.Models;

namespace Project2.Services
{
    public interface IHocPhi
    {
        
        public Task<List<Tuition>> GetHocphiAllAsync();
        public Task<bool> EditHocphiAsync(int id, Tuition hocPhi);
        public Task<bool> AddHocphiAsync(Tuition hocPhi);
        public Task<Tuition> GetHocphiAsync(int? id);
    }
    public class HocPhiSvc: IHocPhi
    {
        protected DataContext _context;
        public HocPhiSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddHocphiAsync(Tuition hocPhi)
        {
            _context.Add(hocPhi);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditHocphiAsync(int id, Tuition hocPhi)
        {
            _context.Update(hocPhi);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Tuition>> GetHocphiAllAsync()
        {
            var dataContext = _context.tuitions;
            return await dataContext.ToListAsync();
        }

        public async Task<Tuition> GetHocphiAsync(int? id)
        {
            var hocphi = await _context.tuitions
                .FirstOrDefaultAsync(m => m.TuitionId == id);
            if(hocphi == null)
            {
                return null;
            }
            return hocphi;
        }
    }
}
