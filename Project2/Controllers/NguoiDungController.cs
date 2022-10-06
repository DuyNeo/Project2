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

        //[HttpPost]
        //[Route("AddStudent")]
        //public async Task<ActionResult<int>> AddNguoiDungAsync(Users NguoiDung) 
        //{
        //    try
        //    {
        //        await _NguoiDung.AddNguoidungAsync(NguoiDung);
        //        Console.WriteLine("thanh cong");

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("loi ne" + ex);
        //    }
        //    return Ok(1);
        //}
        [HttpPost, ActionName("teacher")]
        public async Task<IActionResult> PostAsync(Users users)
        {
            if (ModelState.IsValid)
            {
                if (await _NguoiDung.isEmail(users.Email))
                {
                    return Ok(new
                    {
                        retCode = 0,
                        retText = "Email đã tồn tại",
                        data = ""
                    });
                }
                else
                {
                    if (await _NguoiDung.AddNguoidungAsync(users))
                    {
                        return Ok(new
                        {
                            retCode = 1,
                            retText = "successfuly",
                            data = await _NguoiDung.GetNguoidungAsync(users.UserId)
                        });
                    }
                }

            }
            return Ok(new
            {
                retCode = 0,
                retText = "failure"
            });
        }
        [HttpGet]
        [Route("ListNguoiDung")]
        public async Task<ActionResult<IEnumerable<Users>>> GetNguoiDungAllAsync()
        {
             
            return await _NguoiDung.GetNguoidungAllAsync(); ;           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutNguoiDung(int id, Users NguoiDung)
        {
            if (id != NguoiDung.UserId)
            {
                return BadRequest();
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);




            try
            {
                await _NguoiDung.EditNguoidungAsync(id, NguoiDung);

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

            return Ok(new
            {
                //_NguoiDung.GetNguoidungAsync(id),
                retCode = 0,
                retText = "Update thanh cong"
            });

        }
        private bool NguoiDungExists(int id)
        {
            return _context.users.Any(e => e.UserId == id);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletenguoiDung(int id)
        {
            var nguoiDung = await _context.users.FindAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();

            }

            _context.users.Remove(nguoiDung);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
