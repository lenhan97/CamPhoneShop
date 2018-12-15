using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;

namespace ThuongMaiDienTuAPI.Interfaces
{
    public interface IDangKyDichVuService
    {
        Task<object> Get(DangKyDichVuQuery query);
        Task<bool> Add(DangKyDichVu dangKyDichVu);
    }
}
