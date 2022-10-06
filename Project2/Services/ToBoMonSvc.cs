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
        public Task<List<Department>> GetToBoMonAllAsync();
        public Task<bool> EditToBoMonAsync(int id, Department toBoMon);
        public Task<bool> AddToBoMonAsync(Department toBoMon);
        public Task<Department> GetToBoMonAsync(int? id);
    }
    public class ToBoMonSvc:IToBoMon
    {
        protected DataContext _context;
        public ToBoMonSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddToBoMonAsync(Department toBoMon)
        {
            _context.Add(toBoMon);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditToBoMonAsync(int id, Department toBoMon)
        {
            _context.Update(toBoMon);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Department>> GetToBoMonAllAsync()
        {
            var dataContext = _context.departments;
            return await dataContext.ToListAsync();
        }

        public async Task<Department> GetToBoMonAsync(int? id)
        {
            var tobomon = await _context.departments
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if(tobomon == null)
            {
                return null;
            }
            return tobomon;
        }
    }
}
