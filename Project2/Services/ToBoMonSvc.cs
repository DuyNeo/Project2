using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.Models;
using Microsoft.EntityFrameworkCore;
namespace Project2.Services
{
    public interface IToBoMon
    {
        public Task<List<ToBoMon>> GetToBoMonAllAsync();
        public Task<bool> EditToBoMonAsync(int id, ToBoMon toBoMon);
        public Task<bool> AddToBoMonAsync(ToBoMon toBoMon);
        public Task<ToBoMon> GetToBoMonAsync(int? id);
    }
    public class ToBoMonSvc:IToBoMon
    {
        protected DataContext _context;
        public ToBoMonSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddToBoMonAsync(ToBoMon toBoMon)
        {
            _context.Add(toBoMon);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditToBoMonAsync(int id, ToBoMon toBoMon)
        {
            _context.Update(toBoMon);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ToBoMon>> GetToBoMonAllAsync()
        {
            var dataContext = _context.toBoMons;
            return await dataContext.ToListAsync();
        }

        public async Task<ToBoMon> GetToBoMonAsync(int? id)
        {
            var tobomon = await _context.toBoMons
                .FirstOrDefaultAsync(m => m.toBoMonId == id);
            if(tobomon == null)
            {
                return null;
            }
            return tobomon;
        }
    }
}
