using Microsoft.EntityFrameworkCore;
using Project2.Models;
using Project2.Models.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Services
{
    public interface INguoiDung
    {
        public Task<List<Users>> GetNguoidungAllAsync();
        public Task<bool> EditNguoidungAsync(int id,Users nguoidung);
        public Task<bool> AddNguoidungAsync(Users nguoiDung);
        public Task<Users> GetNguoidungAsync(int? id);
        Task<bool> isEmail(string email);//kiem tra ton tai cua email
        //public Task<bool> DeleteNguoidungAsync(int id, NguoiDung nguoiDung);
        //public Task<Users> Login(ViewLogin viewLogin);
        Task<Users> LoginAsync(ViewLogin login);
        Task<int> ChangePasswordCode(string email, Users user);
    }
    public class NguoiDungSvc : INguoiDung
    {
        protected DataContext _context;
        public NguoiDungSvc(DataContext context)
        {
            _context = context;
        }



        public async Task<bool> AddNguoidungAsync(Users nguoiDung)
        {

            _context.Add(nguoiDung);
            await _context.SaveChangesAsync();
            return true;
        }

        

        public async Task<Users> GetNguoidungAsync(int? id)
        {


            var nguoiDung = await _context.users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (nguoiDung == null)
            {
                return null;
            }

            return nguoiDung;
        }

        public async Task<List<Users>> GetNguoidungAllAsync()
        {
            var dataContext = _context.users;
            return await dataContext.ToListAsync();
        }

        public async Task<bool> EditNguoidungAsync(int id, Users nguoidung)
        {
            _context.users.Update(nguoidung);
            await _context.SaveChangesAsync();
            return true;
        }
        //public async Task<bool> DeleteNguoidungAsync(int id, NguoiDung nguoiDung)
        //{

        //    return true;
        //}
        public async Task<Users> LoginAsync(ViewLogin login)
        {
            Users user = await _context.users.Where(x => x.Email == login.Email
                  && x.Password == (login.Password)).FirstOrDefaultAsync();
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<int> ChangePasswordCode(string email, Users user)
        {
            int ret = 0;
            try
            {

                Users _user = null;
                _user = await GetUserEmail(email);


                _user.Password = user.Password;
                _context.Update(_user);
                await _context.SaveChangesAsync();

                ret = user.UserId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }
        //public async Task<Users> GetUserEmail(ViewLogin viewLogin)
        //{
        //    Users user = null;
        //    user = await _context.users.FirstOrDefaultAsync(u => u.Email == viewLogin.Email);
        //    return user;
        //}
        public async Task<Users> GetUserEmail(string email)
        {
            Users users = null;
            users = await _context.users.FirstOrDefaultAsync(u => u.Email == email);
            return users;
        }
        public async Task<bool> isEmail(string email)
        {
            bool ret = false;
            try
            {
                Users nguoiDung = await _context.users.Where(x => x.Email == email).FirstOrDefaultAsync();
                if (nguoiDung != null)
                {
                    ret = true;
                }
                else
                {
                    ret = false;
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }
    }
}
