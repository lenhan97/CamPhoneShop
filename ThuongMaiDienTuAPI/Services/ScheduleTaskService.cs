using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThuongMaiDienTuAPI.Helpers;
using ThuongMaiDienTuAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace ThuongMaiDienTuAPI.Services
{
    public class ScheduleTaskService : IScheduleTaskService
    {
        public async Task DailyTask()
        {
            await UpdateSeller();
            await UpdateKhuyenMai();
            await UpdateQuangCao();
        }

        public async Task MonthlyTask()
        {
            await ResetLuotXem();
        }
        
        private async Task UpdateSeller()
        {
            using(DataContext db=new DataContext())
            {
                DateTime date = DateTime.Now.Date;
                await db.Seller.Where(x => x.ThoiGianHetHan < date).ForEachAsync(x => x.TinhTrang = false);
            }
        }

        private async Task UpdateKhuyenMai()
        {
            using(DataContext db =new DataContext())
            {
                await db.PhanLoaiSP.ForEachAsync(x => x.GiaKM = null);
                await db.SaveChangesAsync();
                DateTime date = DateTime.Now.Date;
                string query = "update PHANLOAISP " +
                    "set GiaKM = km.PhamTramKM * plsp.GiaBan / 100 " +
                    "from sanpham as sp, khuyenmai as km, PHANLOAISP as plsp " +
                    "where sp.ID = plsp.IDSanPham and sp.IDKhuyenMai = km.ID and km.NgayBatDau <= @CategoryName and km.NgayKetThuc >= @CategoryName ";
                var name = new SqlParameter("@CategoryName", date);
                db.Database.ExecuteSqlCommand(query, name);
                await db.SaveChangesAsync();    // maybe not need
            }
        }
        private async Task UpdateQuangCao()
        {

        }
        private async Task ResetLuotXem()
        {
            using(DataContext db = new DataContext())
            {
                await db.SanPham.ForEachAsync(x => x.SLXem = 0);
                await db.SaveChangesAsync();
            }
        }
    }
}
