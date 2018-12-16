using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Helpers;
using ThuongMaiDienTuAPI.Interfaces;
namespace ThuongMaiDienTuAPI.Services
{
    public class KhachHangService : IKhachHangService
    {
        DataContext db;
        public KhachHangService(DataContext db)
        {
            this.db = db;
        }
        public async Task<object> Get(KhachHangQuery query)
        {
            var kh = Sorting<KhachHang>.Get(Filtering(db.KhachHang, query), query);
            return new
            {
                Total = kh.Count(),
                Content = await Paging<KhachHang>.Get(kh, query).Include(x=>x.DiaChi).ToListAsync()
            };
        }
        public IQueryable<KhachHang> Filtering(IQueryable<KhachHang> kh,KhachHangQuery query)
        {
            if (query.TenKh != null)
            {
                kh = from x in kh
                     where x.Ten.Contains(query.TenKh)
                     select x;
            }
            if (query.SDT != null)
            {
                kh = from x in kh
                     where x.SDT.Contains(query.SDT)
                     select x;
            }
            if (query.Mail != null)
            {
                kh = from x in kh
                     where x.Mail.Contains(query.Mail)
                     select x;
            }
            if (query.FromDiem != null)
            {
                kh = kh.Where(x => x.Diem >= query.FromDiem);
            }
            if (query.ToDiem != null)
            {
                kh = kh.Where(x => x.Diem <= query.ToDiem);
            }
            return kh;
        }

        public async Task<KhachHang> GetByIdUser(int idUser)
        {
            int idKhachHang = (await db.User.FindAsync(idUser)).IDKhachHang;
            return await db.KhachHang.FindAsync(idKhachHang);
        }

        public async Task<bool> Update(KhachHang khachHang)
        {
            if (!db.KhachHang.Any(x => x.ID == khachHang.ID))
            {
                return false;
            }
            db.KhachHang.Attach(khachHang);
            db.Entry(khachHang).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return true;
        }
    }
}
