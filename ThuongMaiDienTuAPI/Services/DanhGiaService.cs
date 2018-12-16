using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Helpers;
using ThuongMaiDienTuAPI.Interfaces;
namespace ThuongMaiDienTuAPI.Services
{
    public class DanhGiaService : IDanhGiaService
    {
        private DataContext db;
        public DanhGiaService(DataContext db)
        {
            this.db = db;
        }

        public async Task<bool> Add(int IDKhachHang,DanhGia danhGia)
        {
            bool isHad = db.HoaDon.Where(
                x => x.IDKhachHang == IDKhachHang &&
                x.TinhTrangTT == ConstantVariable.PaymentStatus.COMPLETED &&
                x.TrangThai == true).Any();
            if (!isHad)
                return false;
            danhGia.Ngay = DateTime.Now;
            danhGia.IDUser = IDKhachHang;
            await db.DanhGia.AddAsync(danhGia);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<object> Get(DanhGiaQuery query)
        {
            var danhGia = Sorting<DanhGia>.Get(Filtering(db.DanhGia, query), query);
            return new
            {
                Total = danhGia.Count(),
                Content = await Paging<DanhGia>.Get(danhGia, query).ToListAsync()
            };
        }

        private IQueryable<DanhGia> Filtering(IQueryable<DanhGia> danhGia,DanhGiaQuery query)
        {
            if(query.IDSeller != -1)
            {
                danhGia = danhGia.Where(x => x.IDSeller == query.IDSeller);
                if (query.FromDanhGia != null)
                {
                    danhGia = danhGia.Where(x => x.Danhgia >= query.FromDanhGia);
                }
                if (query.ToDanhGia != null)
                {
                    danhGia = danhGia.Where(x => x.Danhgia <= query.ToDanhGia);
                }
            }
            else
            {
                danhGia = null;
            }

            return danhGia;
        }
    }
}
