using Microsoft.EntityFrameworkCore;
using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Services
{
    public interface INguoiDung
    {
        public Task<List<NguoiDung>> GetNguoidungAllAsync();
        public Task<bool> EditNguoidungAsync(int id, NguoiDung nguoidung);
        public Task<bool> AddNguoidungAsync(NguoiDung nguoiDung);
        public Task<NguoiDung> GetNguoidungAsync(int? id);
    }
    public class NguoiDungSvc: INguoiDung
    {
        protected DataContext _context;
        public NguoiDungSvc(DataContext context)
        {
            _context = context;
        }

       

        public async Task<bool> AddNguoidungAsync(NguoiDung nguoiDung)
        {

             _context.Add(nguoiDung);
            await _context.SaveChangesAsync();
            return true;

            //ViewData["PhanQuyenId"] = new SelectList(_context.phanQuyens, "Id", "Id", nguoiDung.PhanQuyenId);
            //return View(nguoiDung);
        }
        public async Task<bool> EditNguoidung(int id, NguoiDung nguoidung)
        {

            var nguoiDung = await _context.nguoiDungs.FindAsync(id);
            if (nguoiDung == null)
            {
                return false;
            }
            //ViewData["PhanQuyenId"] = new SelectList(_context.phanQuyens, "Id", "Id", nguoiDung.PhanQuyenId);
            return true;
        }
        public async Task<NguoiDung> GetNguoidungAsync(int? id)
        {


            var nguoiDung = await _context.nguoiDungs
                .FirstOrDefaultAsync(m => m.idNguoiDung == id);
            if (nguoiDung == null)
            {
                return null;
            }

            return nguoiDung;
        }

        public async Task<List<NguoiDung>> GetNguoidungAllAsync()
        {
            var dataContext = _context.nguoiDungs;
            return await dataContext.ToListAsync();
        }

        public async Task<bool> EditNguoidungAsync(int id, NguoiDung nguoidung)
        {
            _context.nguoiDungs.Update(nguoidung);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
