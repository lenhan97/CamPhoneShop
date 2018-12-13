using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Interfaces;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Helpers;
using Microsoft.EntityFrameworkCore;
namespace ThuongMaiDienTuAPI.Services
{
    public class ThongBaoService : IThongBaoService
    {
        DataContext db;
        public ThongBaoService(DataContext db)
        {
            this.db = db;
        }
        private async Task Add(int idUser,string content)
        {
            ThongBao thongBao = new ThongBao
            {
                IDUser = idUser,
                Ngay = DateTime.Now,
                NoiDung = content,
                TinhTrang = ConstantVariable.NotifyStatus.UNSEEN
            };
            await db.ThongBao.AddAsync(thongBao);
            await db.SaveChangesAsync();
        }
        public async Task CheckSeen(int idUser, int idThongBao)
        {
            ThongBao thongBao = await db.ThongBao.FindAsync(idThongBao);
            if (thongBao != null && thongBao.IDUser == idUser)
            {
                thongBao.TinhTrang = ConstantVariable.NotifyStatus.SEEN;
                await db.SaveChangesAsync();
            }
        }

        public async Task<object> Get(int idUser,ThongBaoQuery query)
        {
            var thongBao = Sorting<ThongBao>.Get(Filtering(db.ThongBao.Where(x=>x.IDUser==idUser), query), query);
            return new
            {
                Total = thongBao.Count(),
                Content = await Paging<ThongBao>.Get(thongBao, query).ToListAsync()
            };
        }

        public async Task SendForEmptyProduct(int idUser, int idPhanLoaiSP)
        {
            PhanLoaiSP phanLoaiSP = await db.PhanLoaiSP.FindAsync(idPhanLoaiSP);
            SanPham sanPham = await db.SanPham.FindAsync(phanLoaiSP.IDSanPham);

            string content = "Sản phẩm " + sanPham.Ten + " - " + phanLoaiSP.Mau + " đã hết hàng.";
            await Add(idUser, content);
        }

        private IQueryable<ThongBao> Filtering(IQueryable<ThongBao> thongBao,ThongBaoQuery query)
        {
            if (query.TinhTrang != null)
            {
                thongBao = thongBao.Where(x => x.TinhTrang == query.TinhTrang);
            }

            return thongBao;
        }
    }
}
