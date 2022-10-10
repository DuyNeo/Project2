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
    public class GiangVienController : ControllerBase
    {
        private readonly IGiangVien _GiangVien;
        private readonly DataContext _context;
        public GiangVienController(IGiangVien GiangVien, DataContext context)
        {
            _context = context;
            _GiangVien = GiangVien;
        }
    
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddGiangVienAsync(Teachers GiangVien)
        {
            if (ModelState.IsValid)
            {
                if (await _GiangVien.isEmail(GiangVien.Email))
                {
                    return Ok(new
                    {
                        retCode = 0,
                        retText = "Email đã tồn tại",
                        data = ""
                    });
                }
                else
                {
                    if (await _GiangVien.AddGiangvienAsync(GiangVien))
                    {
                        return Ok(new
                        {
                            retCode = 1,
                            retText = "Thành công",
                            data = await _GiangVien.GetGiangvienAsync(GiangVien.TeachersId)
                        });
                    }
                }

            }
            return Ok(new
            {
                retCode = 0,
                retText = "Thất bại"
            });
        }
        [HttpGet]
        [Route("ListGiangVien")]
        public async Task<ActionResult<IEnumerable<Teachers>>> GetGiangVienAllAsync()
        {
            return await _GiangVien.GetGiangvienAllAsync();
                         
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> PutGiangVien(int id, Teachers GiangVien)
        {
            if (id != GiangVien.TeachersId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _GiangVien.EditGiangvienAsync(id, GiangVien);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiangVienExists(id))
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
        private bool GiangVienExists(int id)
        {
            return _context.teachers.Any(e => e.TeachersId == id);

        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteGv(int id)
        {
            var giangVien = await _context.teachers.FindAsync(id);
            if (giangVien == null)
            {
                return NotFound();
            }

            _context.teachers.Remove(giangVien);
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
