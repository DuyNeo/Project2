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
        public async Task<ActionResult<int>> AddGiangVienAsync(GiangVien GiangVien)
        {
            try
            {

                await _GiangVien.AddGiangvienAsync(GiangVien);
                Console.WriteLine("thanh cong");

            }
            catch (Exception ex)
            {
                Console.WriteLine("loi ne" + ex);
            }
            return Ok(1);
        }
        [HttpGet]
        [Route("ListGiangVien")]
        public async Task<ActionResult<IEnumerable<GiangVien>>> GetGiangVienAllAsync()
        {
            return await _GiangVien.GetGiangvienAllAsync();
                         
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> PutGiangVien(int id, GiangVien GiangVien)
        {
            if (id != GiangVien.gvId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var monan = await _monAnSvc.GetMonAn(id);
            //if (monan == null) return NotFound($"{id} is not found");


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

            return Ok(_GiangVien.GetGiangvienAsync(id));
        }
        private bool GiangVienExists(int id)
        {
            return _context.giangViens.Any(e => e.gvId == id);

        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteGv(int id)
        {
            var giangVien = await _context.giangViens.FindAsync(id);
            if (giangVien == null)
            {
                return NotFound();
            }

            _context.giangViens.Remove(giangVien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
