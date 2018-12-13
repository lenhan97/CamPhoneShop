using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;

namespace ThuongMaiDienTuAPI.Interfaces
{
    public interface IDanhGiaService
    {
        Task<object> Get(DanhGiaQuery query);
        Task<bool> Add(int idUser,DanhGia danhGia);
    }
}
