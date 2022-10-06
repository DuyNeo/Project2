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
    public class ToBoMonController : ControllerBase
    {
        private readonly IToBoMon _ToBoMon;
        private readonly DataContext _context;
        public ToBoMonController(IToBoMon ToBoMon, DataContext context)
        {
            _context = context;
            _ToBoMon = ToBoMon;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddToBoMonAsync(Department ToBoMon)
        {
            try
            {
                await _ToBoMon.AddToBoMonAsync(ToBoMon);
            }
            catch (Exception ex)
            {
                Console.WriteLine("loi ne" + ex);
            }
            return Ok(1);
        }
        [HttpGet]
        [Route("ListToBoMon")]
        public async Task<ActionResult<IEnumerable<Department>>> GetToBoMonAllAsync()
        {
            return await _ToBoMon.GetToBoMonAllAsync();
            //return Ok();
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> PutToBoMon(int id, Department ToBoMon)
        {
            if (id != ToBoMon.DepartmentId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var monan = await _monAnSvc.GetMonAn(id);
            //if (monan == null) return NotFound($"{id} is not found");


            try
            {
                await _ToBoMon.EditToBoMonAsync(id, ToBoMon);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToBoMonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(_ToBoMon.GetToBoMonAsync(id));
        }
        private bool ToBoMonExists(int id)
        {
            return _context.departments.Any(e => e.DepartmentId == id);

        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteToBoMon(int id)
        {
            var toBoMon = await _context.departments.FindAsync(id);
            if (toBoMon == null)
            {
                return NotFound();
            }

            _context.departments.Remove(toBoMon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
