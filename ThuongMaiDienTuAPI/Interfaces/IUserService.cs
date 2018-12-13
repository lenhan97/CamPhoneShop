using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Dtos;
using ThuongMaiDienTuAPI.Dtos.Queries;
namespace ThuongMaiDienTuAPI.Interfaces
{
    public interface IUserService
    {
        Task<object> Get(UserQuery query);
        Task<User> Get(int id);
        Task<User> Get(string username);
        Task<User> Login(LoginDto login);
        Task<bool> Add(KhachHang khachHang, User user);
    }
}
