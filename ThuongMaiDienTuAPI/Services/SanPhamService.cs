using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Helpers;
using ThuongMaiDienTuAPI.Interfaces;

namespace ThuongMaiDienTuAPI.Services
{
    public class SanPhamService : ISanPhamService
    {
        DataContext db;
        public SanPhamService(DataContext db)
        {
            this.db = db;
        }

        #region Events

        public async Task<bool> Add(int idSeller, SanPham sanPham)
        {

            using (IDbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    sanPham.NgayTao = DateTime.Now;
                    sanPham.TinhTrang = true;
                    sanPham.SLXem = 0;
                    sanPham.IDSeller = idSeller;
                    await db.SanPham.AddAsync(sanPham);
                    await db.SaveChangesAsync();
                    sanPham.TenKhac = sanPham.Ten.ConvertToUnSign3().Replace(' ', '-') + ":" + sanPham.ID.ToString();
                    await db.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<bool> Block(int idSeller, int idSanPham)
        {
            SanPham sanPham = await db.SanPham.FindAsync(idSanPham);
            if (sanPham == null || sanPham.IDSeller != idSeller)
                return false;
            sanPham.TinhTrang = false;
            await db.SaveChangesAsync();
            return false;
        }

        public async Task<bool> Delete(int idSeller, int idSanPham)
        {
            SanPham sanPham = await db.SanPham.Where(x => x.ID == idSanPham).Include(x => x.PhanLoaiSP).FirstOrDefaultAsync();
            if (sanPham == null || sanPham.IDSeller != idSeller)
                return false;
            db.SanPham.Remove(sanPham);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<object> Get(SanPhamQuery query)
        {
            var sanpham = Sorting<SanPham>.Get(Filtering(db.SanPham, query), query);
            //return new
            //{
            //    Total = sanpham.Count(),
            //    Content = await Paging<SanPham>.Get(sanpham, query).Include(x=>x.CauHinh).Include(x=>x.PhanLoaiSP).ToListAsync()
            //};
            return new GetResult(sanpham.Count(), await Paging<SanPham>.Get(sanpham, query).Include(x => x.CauHinh).Include(x => x.PhanLoaiSP).ToListAsync());
        }

        public async Task<object> GetById(int ID)
        {
            var sanpham = await db.SanPham.Where(x => x.ID == ID).Include(x => x.PhanLoaiSP).Include(x => x.CauHinh).ToListAsync();
            if (sanpham != null)
            {
                return new GetResult(sanpham.Count, sanpham);
                //return new
                //{
                //    Total = 1,
                //    Content = sanpham
                //};
            }
            return null;
        }

        public async Task<object> Get(int idSeller, SanPhamQuery query)
        {
            var sanpham = Sorting<SanPham>.Get(Filtering(db.SanPham.Where(x => x.IDSeller == idSeller), query), query);
            return new GetResult(sanpham.Count(), await Paging<SanPham>.Get(sanpham, query).Include(x => x.CauHinh).Include(x => x.PhanLoaiSP).ToListAsync());
            //return new
            //{
            //    Total = sanpham.Count(),
            //    Content = await Paging<SanPham>.Get(sanpham, query).Include(x => x.CauHinh).Include(x => x.PhanLoaiSP).ToListAsync()
            //};
        }

        public async Task<object> GetSanPhamKhuyeMai(int IdKhuyenMai, SanPhamQuery query)
        {
            var sanpham = Sorting<SanPham>.Get(Filtering(db.SanPham.Where(x => x.IDKhuyenMai == IdKhuyenMai), query), query);
            return new GetResult(sanpham.Count(), await Paging<SanPham>.Get(sanpham, query).Include(x => x.CauHinh).Include(x => x.PhanLoaiSP).ToListAsync());
            //return new
            //{
            //    Total = sanpham.Count(),
            //    Content = await Paging<SanPham>.Get(sanpham, query).Include(x => x.CauHinh).Include(x => x.PhanLoaiSP).ToListAsync()
            //};
        }

        private IQueryable<SanPham> Filtering(IQueryable<SanPham> sp, SanPhamQuery query)
        {

            if(query.IDPhanLoaiSP != null)
            {
                sp = sp.Where(x => db.PhanLoaiSP.Any(y => y.IDSanPham == x.ID && y.ID == query.IDPhanLoaiSP));
            }
            if (query.IDSeller != null)
            {
                sp = sp.Where(x => x.IDSeller == query.IDSeller);
            }
            if (query.Ten != null)
            {
                sp = from x in sp
                     where x.Ten.Contains(query.Ten)
                     select x;
            }
            if (query.TinhTrang != null)
            {
                sp = sp.Where(x => x.TinhTrang == query.TinhTrang);
            }
            if (query.IDDanhMuc != null)
            {
                sp = sp.Where(x => x.IDDanhMuc == query.IDDanhMuc);
            }
            if (query.FromGiaKM != null)
            {
                sp = sp.Where(x => x.PhanLoaiSP.Any(y => y.GiaKM >= query.FromGiaKM));
            }
            if (query.ToGiaKM != null)
            {
                sp = sp.Where(x => x.PhanLoaiSP.Any(y => y.GiaKM <= query.ToGiaKM));
            }
            if (query.FromSoLuong != null)
            {
                sp = sp.Where(x => x.PhanLoaiSP.Any(y => y.SoLuong >= query.FromSoLuong));
            }
            if (query.ToSoLuong != null)
            {
                sp = sp.Where(x => x.PhanLoaiSP.Any(y => y.SoLuong <= query.ToSoLuong));
            }
            if (query.Mau != null)
            {
                sp = sp.Where(x => x.PhanLoaiSP.Any(y => y.Mau == query.Mau));
            }
            return sp;
        }

        public async Task<object> GetTopSearch()
        {
            var sanpham = await Sorting<SanPham>.Get(db.SanPham, new SanPhamQuery()).Include(x => x.CauHinh).Include(x => x.PhanLoaiSP).Take(ConstantVariable.ProductStatus.TOPSEARCH).ToListAsync();
            return new GetResult(sanpham.Count(), sanpham);
            //return new
            //{
            //    Total = sanpham.Count(),
            //    Content = sanpham
            //};
        }

        public async Task<object> GetTopBought()
        {
            var sanphamhot = Sorting<SanPham>.Get(db.SanPham, new SanPhamHotQuery());
            //return await db.SanPham.Where(x => x.ID == 5).Include(x=>x.CauHinh).Include(x=>x.PhanLoaiSP).ToListAsync();// GetTopBought(db.SanPham);
            return new
            {
                Total = 1,
                Content = await GetTopBought(sanphamhot.Include(x=>x.CauHinh).Include(x=>x.PhanLoaiSP))
            };
        }

        private async Task<object> GetTopBought(IQueryable<SanPham> sanPhams)
        {
            var phanloaisp = await Sorting<PhanLoaiSP>.Get(db.PhanLoaiSP, new PhanLoaiSPQuery()).Take(ConstantVariable.ProductStatus.TOPHOT).ToListAsync();
            return await sanPhams.Where(x => phanloaisp.Any(y => y.IDSanPham == x.ID)).Select(x => new
            {
                ID = x.ID,
                Ten = x.Ten,
                TenKhac = x.TenKhac,
                IDCauHinh = x.IDCauHinh,
                IDDanhMuc = x.IDDanhMuc,
                IDSeller = x.IDSeller,
                SLXem = x.SLXem,
                Mota = x.Mota,
                NoiDung = x.NoiDung,
                Hinh = x.Hinh,
                HinhCT = x.HinhCT,
                ThoiGianBH = x.ThoiGianBH,
                NgayTao = x.NgayTao,
                TinhTrang = x.TinhTrang,
                TinhTrangHang = x.TinhTrangHang,
                CauHinh = db.CauHinh.Where(y => x.IDCauHinh == y.ID).Select(y => new
                {
                    ID = y.ID,
                    ThuongHieu = y.ThuongHieu,
                    BoNho = y.BoNho,
                    Mang = y.Mang,
                    Sim = y.Sim,
                    ChongThamNuoc = y.ChongThamNuoc,
                    KTManHinh = y.KTManHinh,
                    HeDieuHanh = y.HeDieuHanh,
                    Ram = y.Ram,
                    CMRTruoc = y.CMRTruoc,
                    CMRSau = y.CMRSau,
                    GPS = y.GPS,
                    Bluetooth = y.Bluetooth,
                    Pin = y.Pin
                }),
                PhanLoaiSP = phanloaisp.Where(z => z.IDSanPham == x.ID).Select(z => new
                {
                    ID = z.ID,
                    IDSanPham = z.IDSanPham,
                    SoLuong = z.SoLuong,
                    GiaKM = z.GiaKM,
                    GiaBan = z.GiaBan,
                    GiaGoc = z.GiaGoc,
                    Mau = z.Mau,
                    SLMua = z.SLMua
                }),
                IDKhuyenMai = x.IDKhuyenMai
            }).ToListAsync();
        }

        public async Task<bool> Update(int idSeller, SanPham sanpham)
        {
            if (!await db.SanPham.AnyAsync(x => x.ID == sanpham.ID && x.IDSeller == idSeller))
            {
                return false;
            }
            db.SanPham.Attach(sanpham);
            db.Entry(sanpham).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
