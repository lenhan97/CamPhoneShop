using System;
using System.Threading.Tasks;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;

namespace ThuongMaiDienTuAPI.Interfaces
{
    public interface IKhuyenMaiService
    {
        Task<Object> Get(KhuyenMaiQuery khuyenMaiQuery);
        Task<bool> Add(int IdUser, KhuyenMai khuyenMai);
    }
}
