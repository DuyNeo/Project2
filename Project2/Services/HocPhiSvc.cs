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
        
        public Task<List<HocPhi>> GetHocphiAllAsync();
        public Task<bool> EditHocphiAsync(int id, HocPhi hocPhi);
        public Task<bool> AddHocphiAsync(HocPhi hocPhi);
        public Task<HocPhi> GetHocphiAsync(int? id);
    }
    public class HocPhiSvc: IHocPhi
    {
        protected DataContext _context;
        public HocPhiSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddHocphiAsync(HocPhi hocPhi)
        {
            _context.Add(hocPhi);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditHocphiAsync(int id, HocPhi hocPhi)
        {
            _context.Update(hocPhi);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<HocPhi>> GetHocphiAllAsync()
        {
            var dataContext = _context.hocPhis;
            return await dataContext.ToListAsync();
        }

        public async Task<HocPhi> GetHocphiAsync(int? id)
        {
            var hocphi = await _context.hocPhis
                .FirstOrDefaultAsync(m => m.hocPhiId == id);
            if(hocphi == null)
            {
                return null;
            }
            return hocphi;
        }
    }
}
