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
    public class LopHocController : ControllerBase
    {
        private readonly ILopHoc _LopHoc;
        private readonly DataContext _context;
        public LopHocController(ILopHoc LopHoc, DataContext context)
        {
            _context = context;
            _LopHoc = LopHoc;
        }
    
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<int>> AddLopHocAsync(LopHoc LopHoc)
        {
            try
            {
                await _LopHoc.AddLophocAsync(LopHoc);
            }
            catch (Exception ex)
            {
                Console.WriteLine("loi ne" + ex);
            }
            return Ok(1);
        }
        [HttpGet]
        [Route("ListLopHoc")]
        public async Task<ActionResult<IEquatable<LopHoc>>> GetLopHocAllAsync()
        {
             await _LopHoc.GetLophocAllAsync();
            return Ok();            
        }

        [HttpPut("{id}")]
        [Route("Update")]

        public async Task<IActionResult> PutLopHoc(int id, LopHoc lopHoc)
        {
            if (id != lopHoc.lopHocId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var monan = await _monAnSvc.GetMonAn(id);
            //if (monan == null) return NotFound($"{id} is not found");


            try
            {
                await _LopHoc.EditLophocAsync(id, lopHoc);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LopHocExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(_LopHoc.GetLophocAsync(id));
        }
        private bool LopHocExists(int id)
        {
            return _context.lopHocs.Any(e => e.lopHocId == id);

        }
        [HttpDelete("{id}")]
        [Route("Delete")]

        public async Task<IActionResult> DeleteLopHoc(int id)
        {
            var lopHoc = await _context.lopHocs.FindAsync(id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            _context.lopHocs.Remove(lopHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
