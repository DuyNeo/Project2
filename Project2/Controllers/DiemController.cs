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
    public class DiemController : ControllerBase
    {
        private readonly IDiem _Diem;
        private readonly DataContext _context;
        public DiemController(IDiem Diem, DataContext context)
        {
            _context = context;
            _Diem = Diem;
        }

        [HttpPost]
        
        public async Task<ActionResult<int>> AddDiemAsync(Diem Diem)
        {
            try
            {
                await _Diem.AddDiemAsync(Diem);
            }
            catch (Exception ex)
            {
                Console.WriteLine("loi ne" + ex);
            }
            return Ok(1);
        }
        [HttpGet]
        [Route("ListDiem")]
        public async Task<ActionResult<IEnumerable<Diem>>> GetDiemAllAsync()
        {
            return await _Diem.GetDiemAllAsync();
            //return Ok();
        }

        [HttpPut("{id}")]
        

        public async Task<IActionResult> PutDiem(int id, Diem Diem)
        {
            if (id != Diem.diemId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var monan = await _monAnSvc.GetMonAn(id);
            //if (monan == null) return NotFound($"{id} is not found");


            try
            {
                await _Diem.EditDiemAsync(id, Diem);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(_Diem.GetDiemAsync(id));
        }
        private bool DiemExists(int id)
        {
            return _context.diems.Any(e => e.diemId == id);

        }
        [HttpDelete("{id}")]
      
        public async Task<IActionResult> DeleteMonAn(int id)
        {
            var monAn = await _context.diems.FindAsync(id);
            if (monAn == null)
            {
                return NotFound();
            }

            _context.diems.Remove(monAn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
