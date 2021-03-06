﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Helpers;
using ThuongMaiDienTuAPI.Interfaces;

namespace ThuongMaiDienTuAPI.Services
{
    public class QuangCaoService : IQuangCaoService
    {
        DataContext db;
        public QuangCaoService(DataContext db)
        {
            this.db = db;
        }

        public async Task<bool> Add(QuangCao quangcao)
        {
            if (await CheckDateDup(quangcao))
            {
                return false;
            }
            quangcao.NgayDangKy = DateTime.Now;
            int Days = quangcao.NgayKetThuc.Day - quangcao.NgayBatDau.Day;
            quangcao.GiaThue = db.LoaiQuangCao.Find(quangcao.IDLoaiQC).Gia * Days;

            await db.QuangCao.AddAsync(quangcao);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<object> Get(QuangCaoQuery query)
        {
            var quangcao = Sorting<QuangCao>.Get(Filtering(db.QuangCao, query), query);
            return new
            {
                Total = quangcao.Count(),
                Content = await Paging<QuangCao>.Get(quangcao, query).ToListAsync()
            };
        }

        public async Task<bool> Update(int id)
        {
            if (!await db.QuangCao.AnyAsync(x => x.ID == id))
            {
                return false;
            }

            //db.QuangCao.Attach(quangcao);
            //db.Entry(quangcao).State = EntityState.Modified;
            var QC = await db.QuangCao.FirstOrDefaultAsync(x => x.ID == id);
            if (await CheckDateDup(QC) || await checkAdMiddle(id))
            {
                return false;
            }

            QC.TinhTrang = QC.TinhTrang != true;
            await db.SaveChangesAsync();
            return true;
        }

        private async Task<bool> CheckDateDup(QuangCao quangcao)
        {

            if (await db.QuangCao.AnyAsync(x => (x.NgayBatDau <= quangcao.NgayBatDau && x.NgayKetThuc >= quangcao.NgayBatDau) ||
            (x.NgayBatDau <= quangcao.NgayKetThuc && x.NgayKetThuc >= quangcao.NgayKetThuc)))
            {
                return true;
            }
            return false;
        }

        private async Task<bool> checkAdMiddle(int id)
        {
            if (await db.LoaiQuangCao.AnyAsync(x => x.ID == id && x.ViTri == ConstantVariable.AdvertisementPlacementStatus.MIDDLE))
            {
                return true;
            }
            return false;
        }

        private IQueryable<QuangCao> Filtering(IQueryable<QuangCao> quangcao, QuangCaoQuery query)
        {
            if(query.TenDoiTac != null)
            {
                quangcao = quangcao.Where(x => x.TenDoiTac.Contains(query.TenDoiTac));
            }
            if(query.NguoiDaiDien != null)
            {
                quangcao = quangcao.Where(x => x.NguoiDaiDien.Contains(query.NguoiDaiDien));
            }
            if(query.NgayBatDau != null)
            {
                quangcao = quangcao.Where(x => x.NgayBatDau >= query.NgayBatDau);
            }
            if(query.NgayKetThuc != null)
            {
                quangcao = quangcao.Where(x => x.NgayKetThuc <= query.NgayKetThuc);
            }
            if(query.TinhTrang != null)
            {
                quangcao = quangcao.Where(x => x.TinhTrang == query.TinhTrang);
            }
            if(query.LoaiQuangCao != null)
            {
                quangcao = quangcao.Where(x => db.LoaiQuangCao.Find(x.IDLoaiQC).ViTri == query.LoaiQuangCao);
            }

            return quangcao;
        }
    }
}
