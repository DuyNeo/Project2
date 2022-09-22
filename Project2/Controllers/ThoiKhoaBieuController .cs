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
    public class ThoiKhoaBieuController : ControllerBase
    {
        private readonly IThoiKhoaBieu _ThoiKhoaBieu;
        private readonly DataContext _context;
        public ThoiKhoaBieuController(IThoiKhoaBieu ThoiKhoaBieu, DataContext context)
        {
            _context = context;
            _ThoiKhoaBieu = ThoiKhoaBieu;
        }
    
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<int>> AddThoiKhoaBieuAsync(ThoiKhoaBieu ThoiKhoaBieu)
        {
            try
            {
                await _ThoiKhoaBieu.AddThoiKhoaBieuAsync(ThoiKhoaBieu);
            }
            catch (Exception ex)
            {
                Console.WriteLine("loi ne" + ex);
            }
            return Ok(1);
        }
        [HttpGet]
        [Route("ListThoiKhoaBieu")]
        public async Task<ActionResult<IEquatable<ThoiKhoaBieu>>> GetThoiKhoaBieuAllAsync()
        {
             await _ThoiKhoaBieu.GetThoiKhoaBieuAllAsync();
            return Ok();            
        }

        [HttpPut("{id}")]
        [Route("Update")]

        public async Task<IActionResult> PutThoiKhoaBieu(int id, ThoiKhoaBieu ThoiKhoaBieu)
        {
            if (id != ThoiKhoaBieu.Id)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var monan = await _monAnSvc.GetMonAn(id);
            //if (monan == null) return NotFound($"{id} is not found");


            try
            {
                await _ThoiKhoaBieu.EditThoiKhoaBieuAsync(id, ThoiKhoaBieu);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThoiKhoaBieuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(_ThoiKhoaBieu.GetThoiKhoaBieuAsync(id));
        }
        private bool ThoiKhoaBieuExists(int id)
        {
            return _context.thoiKhoaBieus.Any(e => e.Id == id);

        }
        [HttpDelete("{id}")]
        [Route("Delete")]

        public async Task<IActionResult> DeleteThoiKhoaBieu(int id)
        {
            var thoiKhoaBieu = await _context.thoiKhoaBieus.FindAsync(id);
            if (thoiKhoaBieu == null)
            {
                return NotFound();
            }

            _context.thoiKhoaBieus.Remove(thoiKhoaBieu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
