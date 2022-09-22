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
        [Route("Add")]
        public async Task<ActionResult<int>> AddKhoaHocAsync(KhoaHoc KhoaHoc)
        {
            try
            {
                await _KhoaHoc.AddKhoahocAsync(KhoaHoc);
            }
            catch (Exception ex)
            {
                Console.WriteLine("loi ne" + ex);
            }
            return Ok(1);
        }
        [HttpGet]
        [Route("ListKhoaHoc")]
        public async Task<ActionResult<IEquatable<KhoaHoc>>> GetKhoaHocAllAsync()
        {
             await _KhoaHoc.GetKhoahocAllAsync();
            return Ok();            
        }

        [HttpPut("{id}")]
        [Route("Update")]

        public async Task<IActionResult> PutKhoaHoc(int id, KhoaHoc KhoaHoc)
        {
            if (id != KhoaHoc.khoaHocId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var monan = await _monAnSvc.GetMonAn(id);
            //if (monan == null) return NotFound($"{id} is not found");


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

            return Ok(_KhoaHoc.GetKhoahocAsync(id));
        }
        private bool KhoaHocExists(int id)
        {
            return _context.khoaHocs.Any(e => e.khoaHocId == id);

        }
        [HttpDelete("{id}")]
        [Route("Delete")]

        public async Task<IActionResult> DeletekhoaHoc(int id)
        {
            var khoaHoc = await _context.khoaHocs.FindAsync(id);
            if (khoaHoc == null)
            {
                return NotFound();
            }

            _context.khoaHocs.Remove(khoaHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
