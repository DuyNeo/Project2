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
        
        public async Task<ActionResult<int>> AddDiemAsync(Score Diem)
        {
            try
            {
                await _Diem.AddDiemAsync(Diem);
            }
            catch (Exception ex)
            {
                Console.WriteLine("loi ne" + ex);
            }
            return Ok(
                 new
                 {
                     retCode = 1,
                     retText = "Thêm thành công"
                 });
        }
        [HttpGet]
        [Route("ListDiem")]
        public async Task<ActionResult<IEnumerable<Score>>> GetDiemAllAsync()
        {
            return await _Diem.GetDiemAllAsync();
            
        }

        [HttpPut("{id}")]
        

        public async Task<IActionResult> PutDiem(int id, Score Diem)
        {
            if (id != Diem.ScoreId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _Diem.EditDiemAsync(id, Diem);
                
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

            return Ok(
                new
                {
                    retCode = 1,
                    retText = "Sửa điểm thành công"
                }   
                ) ;
        }
        private bool DiemExists(int id)
        {
            return _context.scores.Any(e => e.ScoreId == id);

        }
        [HttpDelete("{id}")]
      
        public async Task<IActionResult> DeleteMonAn(int id)
        {
            var monAn = await _context.scores.FindAsync(id);
            if (monAn == null)
            {
                return NotFound();
            }

            _context.scores.Remove(monAn);
            await _context.SaveChangesAsync();

            return Ok(
                new
            {
                    retCode =1,
                    retText="Xóa thành công"
            });
        }

    }
}
