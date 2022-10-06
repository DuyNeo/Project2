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
    public class KhoaHocController : ControllerBase
    {
        private readonly IKhoaHoc _KhoaHoc;
        private readonly DataContext _context;
        public KhoaHocController(IKhoaHoc KhoaHoc, DataContext context)
        {
            _context = context;
            _KhoaHoc = KhoaHoc;
        }

        [HttpPost]
       
        public async Task<ActionResult<int>> AddKhoaHocAsync(Course KhoaHoc)
        {
            try
            {
                await _KhoaHoc.AddKhoahocAsync(KhoaHoc);
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
        [Route("ListKhoaHoc")]
        public async Task<ActionResult<IEnumerable<Course>>> GetKhoaHocAllAsync()
        {
            return await _KhoaHoc.GetKhoahocAllAsync();
            //return Ok();
        }

        [HttpPut("{id}")]
        
        public async Task<IActionResult> PutKhoaHoc(int id, Course KhoaHoc)
        {
            if (id != KhoaHoc.CourseId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _KhoaHoc.EditKhoahocAsync(id, KhoaHoc);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhoaHocExists(id))
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
        private bool KhoaHocExists(int id)
        {
            return _context.courses.Any(e => e.CourseId == id);

        }
        [HttpDelete("{id}")]
       

        public async Task<IActionResult> DeletekhoaHoc(int id)
        {
            var khoaHoc = await _context.courses.FindAsync(id);
            if (khoaHoc == null)
            {
                return NotFound();
            }

            _context.courses.Remove(khoaHoc);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                retCode = 1,
                retText = "Xóa thành công"
            });
        }

    }
}
