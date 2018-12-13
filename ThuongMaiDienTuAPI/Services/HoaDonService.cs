using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Helpers;
using ThuongMaiDienTuAPI.Interfaces;
namespace ThuongMaiDienTuAPI.Services
{
    public class HoaDonService : IHoaDonService
    {
        private DataContext db;
        public HoaDonService(DataContext db)
        {
            this.db = db;
        }

        public async Task<object> GetByCustomer(int idUser,HoaDonQuery query)
        {
            var hoaDon = Sorting<HoaDon>.Get(Filtering(db.HoaDon.Where(x=>x.IDUser==idUser), query), query);
            return new {
                Total = hoaDon.Count(),
                Content= await Paging<HoaDon>.Get(hoaDon,query).Include(x=>x.ChiTietHD).ToListAsync()
            };
        }
        private double GetGiaGoc(int idPhanLoaiSP)
        {
            return db.PhanLoaiSP.Find(idPhanLoaiSP).GiaGoc;
        }
        private async Task<object> GetBySeller(IQueryable<HoaDon> hoaDon)
        {
            return await hoaDon.Select(x => new
            {
                IdHoaDon = x.ID,
                IdSeller = x.IDSeller,
                IdUser = x.IDUser,
                TenKH = x.TenKH,
                DiaChiKH = x.DiaChiKH,
                GhiChu = x.GhiChu,
                SDT = x.SDT,
                Mail = x.Mail,
                Ngay = x.Ngay,
                TongTien = x.TongTien,
                PhuongThucTT = x.PhuongThucTT,
                TinhTrangTT = x.TinhTrangTT,
                TrangThai = x.TrangThai,
                ChiTietHD = x.ChiTietHD.Select(y => new
                {
                    IdHoaDon = y.IDHoaDon,
                    IdPhanLoaiSP = y.IDPhanLoaiSP,
                    Gia = y.Gia,
                    GiaKM = y.GiaKM,
                    GiaGoc = GetGiaGoc(y.IDPhanLoaiSP),
                    SoLuong = y.SoLuong
                })
            }).ToListAsync();
        }

        public async Task<object> GetBySeller(int idSeller, HoaDonQuery query)
        {
            var hoaDon = Sorting<HoaDon>.Get(Filtering(db.HoaDon.Where(x=>x.IDSeller==idSeller), query), query);
            return new
            {
                Total = hoaDon.Count(),
                Content = await GetBySeller(Paging<HoaDon>.Get(hoaDon, query).Include(x => x.ChiTietHD))
            };
        }

        private IQueryable<HoaDon> Filtering(IQueryable<HoaDon> hoaDon, HoaDonQuery query)
        {
            if (query.IdUser != null)
            {
                hoaDon = hoaDon.Where(x => x.ID == query.IdUser);
            }
            if (query.IdSeller != null)
            {
                hoaDon = hoaDon.Where(x => x.IDSeller == query.IdSeller);
            }
            if (query.TenKH != null)
            {
                hoaDon = from x in hoaDon
                         where x.TenKH.Contains(query.TenKH)
                         select x;
            }
            if (query.Mail != null)
            {
                hoaDon = from x in hoaDon
                         where x.Mail.Contains(query.Mail)
                         select x;
            }
            if (query.SDT != null)
            {
                hoaDon = from x in hoaDon
                         where x.SDT.Contains(query.SDT)
                         select x;
            }
            if (query.PhuongThucTT != null)
            {
                hoaDon = from x in hoaDon
                         where x.PhuongThucTT.Contains(query.PhuongThucTT)
                         select x;
            }
            if (query.TinhTrangTT != null)
            {
                hoaDon = from x in hoaDon
                         where x.TinhTrangTT.Contains(query.TinhTrangTT)
                         select x;
            }
            if (query.TrangThai != null)
            {
                hoaDon = hoaDon.Where(x => x.TrangThai == query.TrangThai);
            }

            return hoaDon;
        }
        private int GetIdSellerByIdPhanLoaiSP(int IdPhanLoaiSP)
        {
            int idSanPham = db.PhanLoaiSP.Find(IdPhanLoaiSP).IDSanPham;
            return db.SanPham.Find(idSanPham).IDSeller;
        }
        public async Task<object> Add(int idUser, HoaDon hoaDon)
        {
            hoaDon.Ngay = DateTime.Now;
            hoaDon.TrangThai = true;
            hoaDon.TinhTrangTT = ConstantVariable.PaymentStatus.WAIT;
            hoaDon.IDUser = idUser;
            Dictionary<int, HoaDon> dictionary = new Dictionary<int, HoaDon>();
            int idSeller;
            PhanLoaiSP phanLoaiSP;
            foreach(var i in hoaDon.ChiTietHD)
            {
                phanLoaiSP = db.PhanLoaiSP.Find(i.IDPhanLoaiSP);
                idSeller = db.SanPham.Find(phanLoaiSP.IDSanPham).IDSeller;
                if (!dictionary.ContainsKey(idSeller))
                {
                    dictionary.Add(idSeller, new HoaDon(hoaDon));
                    dictionary[idSeller].IDSeller = idSeller;
                    dictionary[idSeller].TongTien = 0;
                }
                ChiTietHD chiTietHD = new ChiTietHD();
                chiTietHD.IDPhanLoaiSP = i.IDPhanLoaiSP;
                chiTietHD.SoLuong = i.SoLuong;
                chiTietHD.Gia = phanLoaiSP.GiaBan;
                chiTietHD.GiaKM = phanLoaiSP.GiaKM;
                dictionary[idSeller].ChiTietHD.Add(chiTietHD);
                if (chiTietHD.GiaKM != null)
                    dictionary[idSeller].TongTien += ((int)chiTietHD.GiaKM * (int)chiTietHD.SoLuong);
                else
                    dictionary[idSeller].TongTien += ((int)chiTietHD.Gia * (int)chiTietHD.SoLuong);
            }
            List<HoaDon> list = new List<HoaDon>();
            List<KeyValuePair<int, int>> listThongBao=new List<KeyValuePair<int, int>>();
            foreach(var i in dictionary)
            {
                foreach(var j in i.Value.ChiTietHD)
                {
                    phanLoaiSP = await db.PhanLoaiSP.FindAsync(j.IDPhanLoaiSP);
                    phanLoaiSP.SoLuong-=(int)j.SoLuong;
                    if (phanLoaiSP.SoLuong == 0)
                    {
                        int idUserSeller = (await db.User.Where(x => x.IdSeller == i.Value.IDSeller).FirstOrDefaultAsync()).ID;
                        listThongBao.Add(new KeyValuePair<int, int>(idUserSeller,j.IDPhanLoaiSP));
                    }
                }
                await db.HoaDon.AddAsync(i.Value);
                list.Add(i.Value);
            }
            await db.SaveChangesAsync();
            ThongBaoService thongBaoService = new ThongBaoService(db);
            foreach(var i in listThongBao)
            {
                await thongBaoService.SendForEmptyProduct(i.Key, i.Value);
            }
            return new
            {
                Total = list.Count(),
                Content = list
            };
        }
    }
}
