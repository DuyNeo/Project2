using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project2.Services;
using Project2.Models;
using Microsoft.EntityFrameworkCore;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LuongController : ControllerBase
    {
        private readonly ILuong _Luong;
        private readonly DataContext _context;
        public LuongController(ILuong Luong, DataContext context)
        {
            _context = context;
            _Luong = Luong;
        }

        [HttpPost]
       
        public async Task<ActionResult<int>> AddLuongAsync(Salary Luong)
        {
            try
            {
                await _Luong.AddLuongAsync(Luong);
            }
            catch (Exception ex)
            {
                
            }
            return Ok(new
            {
                retCode = 1,
                retText = "Thêm thành công"
            });
        }
        [HttpGet]
        [Route("ListLuong")]
        public async Task<ActionResult<IEnumerable<Salary>>> GetLuongAllAsync()
        {
            return await _Luong.GetLuongAllAsync();
            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLuong(int id, Salary Luong)
        {
            if (id != Luong.SalaryId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _Luong.EditLuongAsync(id, Luong);
               
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LuongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(
                 new
                 {
                     retCode = 1,
                     retText = "Sửa thành công"
                 });
        }
        private bool LuongExists(int id)
        {
            return _context.salaries.Any(e => e.SalaryId == id);

        }
        [HttpDelete("{id}")]
       

        public async Task<IActionResult> DeleteLuong(int id)
        {
            var Luong = await _context.salaries.FindAsync(id);
            if (Luong == null)
            {
                return NotFound();
            }

            _context.salaries.Remove(Luong);
            await _context.SaveChangesAsync();

            return Ok(
                 new
                 {
                     retCode = 1,
                     retText = "Xóa thành công"
                 });
        }

    }
}
