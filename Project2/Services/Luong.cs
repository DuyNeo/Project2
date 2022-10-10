using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project2.Models;
namespace Project2.Services
{
    public interface ILuong
    {
        public Task<List<Salary>> GetLuongAllAsync();
        public Task<bool> EditLuongAsync(int id, Salary Luong);
        public Task<bool> AddLuongAsync(Salary Luong);
        public Task<Salary> GetLuongAsync(int? id);
         //Task<int> AddLuong(Salary salary);
    }
    public class LuongSvc : ILuong
    {
        protected DataContext _context;
        public LuongSvc(DataContext context)
        {
            _context = context; 
        }
        public async Task<bool> AddLuongAsync(Salary Luong)
        {
            _context.Add(Luong);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditLuongAsync(int id, Salary Luong)
        {
            _context.Update(Luong);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Salary>> GetLuongAllAsync()
        {
            var dataContext = _context.salaries;
            return await dataContext.ToListAsync();
        }

        public async Task<Salary> GetLuongAsync(int? id)
        {
            var Luong = await _context.salaries
                .FirstOrDefaultAsync(m => m.SalaryId == id);
            if(Luong == null)
            {
                return null;
            }
            return Luong;
        }
        //public async Task<int> AddLuong(Salary salary)
        //{
        //    int ret = 0;
        //    try
        //    {
        //        List<Salary> list = await _context.salaries.Where(x => x.TeacherId == salary.TeacherId).ToListAsync();
        //        float doanhthu = 0;
        //        foreach(var item in list)
        //        {
        //            doanhthu +=item.tong
        //    }
        //    catch
        //    {


        //    }
        //    return ret;
        //}


    }
}
