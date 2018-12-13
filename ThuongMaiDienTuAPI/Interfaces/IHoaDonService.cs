using System.Threading.Tasks;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;
namespace ThuongMaiDienTuAPI.Interfaces
{
    public interface IHoaDonService
    {
        Task<object> GetByCustomer(int idUser,HoaDonQuery query);
        Task<object> GetBySeller(int idSeller,HoaDonQuery query);
        Task<object> Add(int idUser, HoaDon hoaDon);
    }
}
