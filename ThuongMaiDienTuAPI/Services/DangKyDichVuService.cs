using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Helpers;
using ThuongMaiDienTuAPI.Interfaces;
namespace ThuongMaiDienTuAPI.Services
{
    public class DangKyDichVuService : IDangKyDichVuService
    {
        DataContext db;
        public DangKyDichVuService(DataContext db)
        {
            this.db = db;
        }
        public async Task<bool> Add(DangKyDichVu dangKyDichVu)
        {
            
            GoiDichVu goiDichVu = await db.GoiDichVu.FindAsync(dangKyDichVu.IDGoiDichVu);
            if (goiDichVu == null || goiDichVu.TinhTrang == false)
            {
                return false;
            }
            await db.AddAsync(dangKyDichVu);
            Seller seller = await db.Seller.FindAsync(dangKyDichVu.IDSeller);
            seller.ThoiGianHetHan=seller.ThoiGianHetHan.AddMonths(goiDichVu.ThoiGian);
            seller.TinhTrang = true;
            await db.SaveChangesAsync();
            return true;

        }

        public async Task<object> Get(DangKyDichVuQuery query)
        {
            var dangKyDichVu = Sorting<DangKyDichVu>.Get(Filtering(db.DangKyDichVu, query), query);
            return new
            {
                Total = dangKyDichVu.Count(),
                Content = await Paging<DangKyDichVu>.Get(dangKyDichVu, query).Include(x=>x.GoiDichVu).ToListAsync()
            };
        }
        private IQueryable<DangKyDichVu> Filtering(IQueryable<DangKyDichVu> dangKyDichVu, DangKyDichVuQuery query)
        {
            if (query.ID != null)
            {
                dangKyDichVu = dangKyDichVu.Where(x => x.ID == query.ID);
            }
            if (query.IDSeller != null)
            {
                dangKyDichVu = dangKyDichVu.Where(x => x.IDSeller == query.IDSeller);
            }
            if (query.IDGoiDichVu != null)
            {
                dangKyDichVu = dangKyDichVu.Where(x => x.IDGoiDichVu == query.IDGoiDichVu);
            }

            return dangKyDichVu;
        }
    }
}
