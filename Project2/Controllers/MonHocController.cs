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
        public async Task<ActionResult<int>> AddMonHocAsync(Subjects MonHoc)
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
        public async Task<ActionResult<IEnumerable<Subjects>>> GetMonHocAllAsync()
        {
            return await _MonHoc.GetMonhocAllAsync();
            //return Ok();
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> PutMonHoc(int id, Subjects MonHoc)
        {
            if (id != MonHoc.SubjectId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _MonHoc.EditMonhocAsync(id, MonHoc);
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
            return _context.subjects.Any(e => e.SubjectId == id);

        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletemonHoc(int id)
        {
            var monHoc = await _context.subjects.FindAsync(id);
            if (monHoc == null)
            {
                return NotFound();
            }

            _context.subjects.Remove(monHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
