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
        public async Task<ActionResult<bool>> AddLopHocAsync(Class LopHoc)
        {
            if (ModelState.IsValid)
            {
                if (await _LopHoc.AddLophocAsync(LopHoc))
                {
                    return Ok(new
                    {
                        retCode = 1,
                        retText = "successfuly"
                    });
                }
            }
            return Ok(new
            {
                retCode = 0,
                retText ="Quá trời lỗi luôn",
               
                
            });
        }

       
        [HttpGet]
        [Route("ListLopHoc")]
        public async Task<ActionResult<IEnumerable<Class>>> GetLopHocAllAsync()
        {
           return await _LopHoc.GetLophocAllAsync();
            
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> PutLopHoc(int id, Class lopHoc)
        {
            if (id != lopHoc.ClassId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);
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

            return Ok(new
            {
                retCode = 1,
                retText = "Sửa thành công"
            });
        }
        private bool LopHocExists(int id)
        {
            return _context.classes.Any(e => e.ClassId == id);

        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteLopHoc(int id)
        {
            var lopHoc = await _context.classes.FindAsync(id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            _context.classes.Remove(lopHoc);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                retCode = 1,
                retText = "Xóa thành công"
            });
        }

    }
}
