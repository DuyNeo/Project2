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
    public class LichNghicController : ControllerBase
    {
        private readonly ILichNghi _LichNghi;
        private readonly DataContext _context;
        public LichNghicController(ILichNghi LichNghi, DataContext context)
        {
            _context = context;
            _LichNghi = LichNghi;
        }

        [HttpPost]
       
        public async Task<ActionResult<int>> AddLichNghicAsync(HolidaySchedule LichNghi)
        {
            try
            {
                await _LichNghi.AddLichNghiAsync(LichNghi);
            }
            catch (Exception ex)
            {
                Console.WriteLine("loi ne" + ex);
            }
            return Ok(new
            {
                retCode = 1,
                retText = "Thêm thành công"
            });
        }
        [HttpGet]
        [Route("ListLichNghi")]
        public async Task<ActionResult<IEnumerable<HolidaySchedule>>> GetLichNghicAllAsync()
        {
            return await _LichNghi.GetLichNghiAllAsync();
            //return Ok();
        }

        [HttpPut("{id}")]
        
        public async Task<IActionResult> PutLichNghic(int id, HolidaySchedule LichNghi)
        {
            if (id != LichNghi.HolidayId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _LichNghi.EditLichNghiAsync(id, LichNghi);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LichNghicExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new
            {
                retCode = 1,
                retText = "Sửa thành công"
            });
        }
        private bool LichNghicExists(int id)
        {
            return _context.holidaySchedules.Any(e => e.HolidayId == id);

        }
        [HttpDelete("{id}")]
       

        public async Task<IActionResult> DeleteLichNghic(int id)
        {
            var LichNghi = await _context.holidaySchedules.FindAsync(id);
            if (LichNghi == null)
            {
                return NotFound();
            }

            _context.holidaySchedules.Remove(LichNghi);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                retCode = 1,
                retText = "Xóa thành công"
            });
        }

    }
}
