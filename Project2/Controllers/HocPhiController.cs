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
       
        public async Task<ActionResult<int>> AddHocPhiAsync(Tuition HocPhi)
        {
            try
            {
                await _HocPhi.AddHocphiAsync(HocPhi);
            }
            catch (Exception ex)
            {
                
            }
            return Ok(new
            {
                retCode = 1,
                retText = "Thêm thành công"
            });
        }
        [HttpGet]
        [Route("ListHocPhi")]
        public async Task<ActionResult<IEnumerable<Tuition>>> GetHocPhiAllAsync()
        {
            return await _HocPhi.GetHocphiAllAsync();
            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHocPhi(int id, Tuition HocPhi)
        {
            if (id != HocPhi.TuitionId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                await _HocPhi.EditHocphiAsync(id, HocPhi);
               
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

            return Ok(
                 new
                 {
                     retCode = 1,
                     retText = "Sửa thành công"
                 });
        }
        private bool HocPhiExists(int id)
        {
            return _context.pointTypes.Any(e => e.PointTypeId == id);

        }
        [HttpDelete("{id}")]
       

        public async Task<IActionResult> DeleteHocPhi(int id)
        {
            var HocPhi = await _context.pointTypes.FindAsync(id);
            if (HocPhi == null)
            {
                return NotFound();
            }

            _context.pointTypes.Remove(HocPhi);
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
