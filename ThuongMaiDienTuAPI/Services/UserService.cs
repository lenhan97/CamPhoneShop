using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ThuongMaiDienTuAPI.Dtos;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Helpers;
using ThuongMaiDienTuAPI.Interfaces;

namespace ThuongMaiDienTuAPI.Services
{
    public class UserService : IUserService
    {
        DataContext db; 
        public UserService(DataContext db)
        {
            this.db = db;
        }
        public async Task<object> Get(UserQuery query)
        {
            var users = Sorting<User>.Get(Filtering(db.User, query), query);
            return new
            {
                Total = users.Count(),
                Content = await Paging<User>.Get(users, query).ToListAsync()
            };
        }

        private IQueryable<User> Filtering(IQueryable<User> users,UserQuery query)
        {
            if (query.TenDN != null)
            {
                users = from x in users
                        where x.TenDN.Contains(query.TenDN)
                        select x;
            }
            if (query.LoaiUser != null)
            {
                users = users.Where(x => x.LoaiUser == query.LoaiUser);
            }
            if (query.TrangThai != null)
            {
                users = users.Where(x => x.TinhTrang == query.TrangThai);
            }
            return users;
        }

        public async Task<User> Get(int id)
        {
            return await db.User.FindAsync(id);
        }

        public async Task<User> Get(string username)
        {
            return await db.User.Where(x => x.TenDN == username).FirstOrDefaultAsync();
        }

        public async Task<User> Login(LoginDto login)
        {
            User user = await Get(login.TenDN);
            //Debug.WriteLine(user.IdUser + " " + user.TenDN + " " + user.Matkhau);
            if (user == null||user.Matkhau.Trim()!=login.Matkhau)
                return null;
            return user;
        }

        public async Task<bool> Add(KhachHang khachHang, User user)
        {
            using(IDbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    await db.KhachHang.AddAsync(khachHang);
                    await db.SaveChangesAsync();
                    user.TinhTrang = true;
                    user.LoaiUser = ConstantVariable.UserPermission.CUSTOMER;
                    user.IDKhachHang = khachHang.ID;
                    await db.User.AddAsync(user);
                    await db.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }

        }
        public async Task<bool> ChangePassword(int idUser,ChangePasswordUserDto changePasswordUserDto)
        {
            User user = await Get(idUser);
            changePasswordUserDto.CurrentPass = Encryptor.MD5Hash(changePasswordUserDto.CurrentPass);
            if (user != null && user.Matkhau==changePasswordUserDto.CurrentPass)
            {
                user.Matkhau = Encryptor.MD5Hash(changePasswordUserDto.NewPass);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
