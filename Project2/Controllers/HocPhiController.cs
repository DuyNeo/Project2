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
    public class HocPhiController : ControllerBase
    {
        private readonly IHocPhi _HocPhi;
        private readonly DataContext _context;
        public HocPhiController(IHocPhi HocPhi, DataContext context)
        {
            _context = context;
            _HocPhi = HocPhi;
        }
    
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<int>> AddHocPhiAsync(HocPhi HocPhi)
        {
            try
            {
                await _HocPhi.AddHocphiAsync(HocPhi);
            }
            catch (Exception ex)
            {
                Console.WriteLine("loi ne" + ex);
            }
            return Ok(1);
        }
        [HttpGet]
        [Route("ListHocPhi")]
        public async Task<ActionResult<IEquatable<HocPhi>>> GetHocPhiAllAsync()
        {
             await _HocPhi.GetHocphiAllAsync();
            return Ok();            
        }

        [HttpPut("{id}")]
        [Route("Update")]

        public async Task<IActionResult> PutHocPhi(int id, HocPhi HocPhi)
        {
            if (id != HocPhi.hocPhiId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var monan = await _monAnSvc.GetMonAn(id);
            //if (monan == null) return NotFound($"{id} is not found");


            try
            {
                await _HocPhi.EditHocphiAsync(id, HocPhi);
                //await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HocPhiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(_HocPhi.GetHocphiAsync(id));
        }
        private bool HocPhiExists(int id)
        {
            return _context.hocPhis.Any(e => e.hocPhiId == id);

        }
        [HttpDelete("{id}")]
        [Route("Delete")]

        public async Task<IActionResult> DeleteHocPhi(int id)
        {
            var HocPhi = await _context.hocPhis.FindAsync(id);
            if (HocPhi == null)
            {
                return NotFound();
            }

            _context.hocPhis.Remove(HocPhi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
