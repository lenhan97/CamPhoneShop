using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ThuongMaiDienTuAPI.Dtos.Queries;
namespace ThuongMaiDienTuAPI.Interfaces
{
    public interface IThongBaoService
    {
        Task<object> Get(int idUser,ThongBaoQuery query);
        Task SendForEmptyProduct(int idUser, int idPhanLoaiSP);
        Task CheckSeen(int idUser, int idThongBao);
    }
}
