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
        public async Task<ActionResult<int>> AddLoaiDiemAsync(PointType LoaiDiem)
        {
            try
            {
                await _LoaiDiem.AddLoaidiemAsync(LoaiDiem);
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
        [Route("ListLoaiDiem")]
        public async Task<ActionResult<IEnumerable<PointType>>> GetLoaiDiemAllAsync()
        {
            return await _LoaiDiem.GetLoaidiemAllAsync();
            //return Ok();
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> PutLoaiDiem(int id, PointType LoaiDiem)
        {
            if (id != LoaiDiem.PointTypeId)
            {
                return BadRequest(new {
                    retCode = 0,
                    retText="Thất bại"
                });
                

            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           


            try
            {
                await _LoaiDiem.EditLoaidiemAsync(id, LoaiDiem);
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

            return Ok(new
            {
                retCode = 1,
                retText = "Sửa thành công"
            });
        }
        private bool LoaiDiemExists(int id)
        {
            return _context.pointTypes.Any(e => e.PointTypeId == id);

        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteloaiDiem(int id)
        {
            var loaiDiem = await _context.pointTypes.FindAsync(id);
            if (loaiDiem == null)
            {
                return NotFound();
            }

            _context.pointTypes.Remove(loaiDiem);
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
