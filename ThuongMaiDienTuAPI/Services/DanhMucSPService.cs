using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Helpers;
using ThuongMaiDienTuAPI.Interfaces;
namespace ThuongMaiDienTuAPI.Services
{
    public class DanhMucSPService : IDanhMucSPService
    {
        DataContext db;
        public DanhMucSPService(DataContext db)
        {
            this.db = db;
        }

        public async Task<object> Get(DanhMucSPQuery query)
        {
            //var danhMucSP = Sorting<DanhMucSP>.Get(Filtering(db.DanhMucSP,query),query);
            //return new GetResult(danhMucSP.Count(), await Paging<DanhMucSP>.Get(danhMucSP, query).ToListAsync());
            //return new
            //{
            //    Total = danhMucSP.Count(),
            //    Content = await Paging<DanhMucSP>.Get(danhMucSP, query).ToListAsync()
            //};
            var danhmuc = await Sorting<DanhMucSP>.Get(Filtering(db.DanhMucSP, query),query).ToListAsync();
            return new GetResult(danhmuc.Count(), danhmuc);
        }
        private IQueryable<DanhMucSP> Filtering(IQueryable<DanhMucSP> danhMucSP,DanhMucSPQuery query)
        {
            if (query.TinhTrang != null)
            {
                danhMucSP = danhMucSP.Where(x => x.TinhTrang == query.TinhTrang);
            }
            return danhMucSP;
        }

        public async Task<bool> Add(DanhMucSP danhMucSP)
        {
            await db.DanhMucSP.AddAsync(danhMucSP);
            await db.SaveChangesAsync();
            return true;
        }
    }
}
