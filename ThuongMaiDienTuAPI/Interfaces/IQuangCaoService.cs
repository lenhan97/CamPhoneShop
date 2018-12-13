using System.Threading.Tasks;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;

namespace ThuongMaiDienTuAPI.Interfaces
{
    public interface IQuangCaoService
    {
        Task<object> Get(QuangCaoQuery query);
        Task<bool> Add(QuangCao quangcao);
        Task<bool> Update(QuangCao quangcao);
    }
}
