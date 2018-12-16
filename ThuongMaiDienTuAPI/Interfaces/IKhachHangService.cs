using System.Threading.Tasks;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;
namespace ThuongMaiDienTuAPI.Interfaces
{
    public interface IKhachHangService
    {
        Task<object> Get(KhachHangQuery query);
        Task<KhachHang> GetByIdUser(int idUser);
        Task<bool> Update(KhachHang khachHang);
    }
}
