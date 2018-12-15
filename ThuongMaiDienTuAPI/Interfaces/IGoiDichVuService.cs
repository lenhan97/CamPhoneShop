using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;

namespace ThuongMaiDienTuAPI.Interfaces
{
    public interface IGoiDichVuService
    {
        Task<object> Get(GoiDichVuQuery query);
        Task<bool> Add(GoiDichVu goiDichVu);
        Task<bool> Update(GoiDichVu goiDichVu);
    }
}
