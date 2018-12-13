using System;
using System.Threading.Tasks;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;

namespace ThuongMaiDienTuAPI.Interfaces
{
    public interface IDanhMucSPService
    {
        Task<Object> Get(DanhMucSPQuery query);
        Task<bool> Add(DanhMucSP danhMucSP);
    }
}
