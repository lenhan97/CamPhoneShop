using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Helpers;
using ThuongMaiDienTuAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace ThuongMaiDienTuAPI.Services
{
    public class GoiDichVuService : IGoiDichVuService
    {
        DataContext db;
        public GoiDichVuService(DataContext db)
        {
            this.db = db;
        }
        public async Task<bool> Add(GoiDichVu goiDichVu)
        {
            await db.AddAsync(goiDichVu);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<object> Get(GoiDichVuQuery query)
        {
            var goiDichVu = Sorting<GoiDichVu>.Get(Filtering(db.GoiDichVu, query), query);
            return new
            {
                Total = goiDichVu.Count(),
                Content = await Paging<GoiDichVu>.Get(goiDichVu, query).ToListAsync()
            };
        }
        private IQueryable<GoiDichVu> Filtering(IQueryable<GoiDichVu> goiDichVu, GoiDichVuQuery query)
        {
            if (query.Id != null)
            {
                goiDichVu = goiDichVu.Where(x => x.ID == query.Id);
            }
            if (query.Ten != null)
            {
                goiDichVu = from x in goiDichVu
                            where x.Ten.Contains(query.Ten)
                            select x;
            }
            if (query.TinhTrang != null)
            {
                goiDichVu = goiDichVu.Where(x => x.TinhTrang == query.TinhTrang);
            }
            return goiDichVu;
        }

        public async Task<bool> Update(GoiDichVu goiDichVu)
        {
            db.Update<GoiDichVu>(goiDichVu);
            await db.SaveChangesAsync();
            return true;

        }
    }
}
