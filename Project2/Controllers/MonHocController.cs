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
    public class MonHocController : ControllerBase
    {
        private readonly IMonHoc _MonHoc;
        private readonly DataContext _context;
        public MonHocController(IMonHoc MonHoc, DataContext context)
        {
            _context = context;
            _MonHoc = MonHoc;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddMonHocAsync(MonHoc MonHoc)
        {
            try
            {
                await _MonHoc.AddMonhocAsync(MonHoc);
            }
            catch (Exception ex)
            {
                Console.WriteLine("loi ne" + ex);
            }
            return Ok(1);
        }
        [HttpGet]
        [Route("ListMonHoc")]
        public async Task<ActionResult<IEnumerable<MonHoc>>> GetMonHocAllAsync()
        {
            return await _MonHoc.GetMonhocAllAsync();
            //return Ok();
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> PutMonHoc(int id, MonHoc MonHoc)
        {
            if (id != MonHoc.monHocId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var monan = await _monAnSvc.GetMonAn(id);
            //if (monan == null) return NotFound($"{id} is not found");


            try
            {
                await _MonHoc.EditMonhocAsync(id, MonHoc);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonHocExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(_MonHoc.GetMonhocAsync(id));
        }
        private bool MonHocExists(int id)
        {
            return _context.monHocs.Any(e => e.monHocId == id);

        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletemonHoc(int id)
        {
            var monHoc = await _context.monHocs.FindAsync(id);
            if (monHoc == null)
            {
                return NotFound();
            }

            _context.monHocs.Remove(monHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
