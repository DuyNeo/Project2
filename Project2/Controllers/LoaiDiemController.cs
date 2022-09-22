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
    public class LoaiDiemController : ControllerBase
    {
        private readonly ILoaiDiem _LoaiDiem;
        private readonly DataContext _context;
        public LoaiDiemController(ILoaiDiem LoaiDiem, DataContext context)
        {
            _context = context;
            _LoaiDiem = LoaiDiem;
        }
    
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<int>> AddLoaiDiemAsync(LoaiDiem LoaiDiem)
        {
            try
            {
                await _LoaiDiem.AddLoaidiemAsync(LoaiDiem);
            }
            catch (Exception ex)
            {
                Console.WriteLine("loi ne" + ex);
            }
            return Ok(1);
        }
        [HttpGet]
        [Route("ListLoaiDiem")]
        public async Task<ActionResult<IEquatable<LoaiDiem>>> GetLoaiDiemAllAsync()
        {
             await _LoaiDiem.GetLoaidiemAllAsync();
            return Ok();            
        }

        [HttpPut("{id}")]
        [Route("Update")]

        public async Task<IActionResult> PutLoaiDiem(int id, LoaiDiem LoaiDiem)
        {
            if (id != LoaiDiem.loaiDiemId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var monan = await _monAnSvc.GetMonAn(id);
            //if (monan == null) return NotFound($"{id} is not found");


            try
            {
                await _LoaiDiem.EditLoaidiemAsync(id, LoaiDiem);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiDiemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(_LoaiDiem.GetLoaidiemAsync(id));
        }
        private bool LoaiDiemExists(int id)
        {
            return _context.loaiDiems.Any(e => e.loaiDiemId == id);

        }
        [HttpDelete("{id}")]
        [Route("Delete")]

        public async Task<IActionResult> DeleteloaiDiem(int id)
        {
            var loaiDiem = await _context.loaiDiems.FindAsync(id);
            if (loaiDiem == null)
            {
                return NotFound();
            }

            _context.loaiDiems.Remove(loaiDiem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
