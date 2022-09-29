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
    public class NguoiDungController : ControllerBase
    {
        private readonly INguoiDung _NguoiDung;
        private readonly DataContext _context;
        public NguoiDungController(INguoiDung NguoiDung, DataContext context)
        {
            _context = context;
            _NguoiDung = NguoiDung;
        }
    
        [HttpPost]
        [Route("AddStudent")]
        public async Task<ActionResult<int>> AddNguoiDungAsync(NguoiDung NguoiDung) 
        {
            try
            {
                await _NguoiDung.AddNguoidungAsync(NguoiDung);
                Console.WriteLine("thanh cong");

            }
            catch (Exception ex)
            {
                Console.WriteLine("loi ne" + ex);
            }
            return Ok(1);
        }
        [HttpGet]
        [Route("ListNguoiDung")]
        public async Task<ActionResult<IEnumerable<NguoiDung>>> GetNguoiDungAllAsync()
        {
             
            return await _NguoiDung.GetNguoidungAllAsync(); ;           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNguoiDung(int id, NguoiDung NguoiDung)
        {
            if (id != NguoiDung.idNguoiDung)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            


            try
            {
                await _NguoiDung.EditNguoidungAsync(id, NguoiDung);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiDungExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(_NguoiDung.GetNguoidungAsync(id));
        }
        private bool NguoiDungExists(int id)
        {
            return _context.nguoiDungs.Any(e => e.idNguoiDung == id);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletenguoiDung(int id)
        {
            var nguoiDung = await _context.nguoiDungs.FindAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            _context.nguoiDungs.Remove(nguoiDung);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
