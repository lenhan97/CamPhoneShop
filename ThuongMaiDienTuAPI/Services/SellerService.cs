﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ThuongMaiDienTuAPI.Dtos;
using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Helpers;
using ThuongMaiDienTuAPI.Interfaces;

namespace ThuongMaiDienTuAPI.Services
{
    public class SellerService : ISellerService
    {
        DataContext db;
        public SellerService(DataContext db)
        {
            this.db = db;
        }

        #region Events

        public async Task<object> Get(SellerQuery query)
        {
            var sellers = Sorting<Seller>.Get(Filtering(db.Seller, query), query);
            return new
            {
                Total = sellers.Count(),
                Content = await Paging<Seller>.Get(sellers, query).Include(x=>x.DiaChi).ToListAsync()
            };
        }

        public async Task<Seller> GetByIdUser(int idUser)
        {
            User user = (await db.User.FindAsync(idUser));
            if (user.LoaiUser != ConstantVariable.UserPermission.SELLER)
                return null;
            return await db.Seller.FindAsync(user.IDSeller);
        }

        public async Task<bool> Register(int idUser, Seller seller)
        {
            using (IDbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    User user = await db.User.FindAsync(idUser);
                    seller.CheckCMND = true;
                    seller.CheckMail = false;
                    seller.NgayDK = DateTime.Now;
                    await db.Seller.AddAsync(seller);
                    await db.SaveChangesAsync();
                    user.IDSeller = seller.ID;
                    await db.SaveChangesAsync();
                    //-----------Send Mail-----------------
                    string code = StringExtensions.RandomString(30);
                    await db.XacNhanMail.AddAsync(new XacNhanMail{ IDUser=idUser, Code=code });
                    await db.SaveChangesAsync();
                    EmailSender.SendVerifyMail(seller.Mail, code);
                    //-------------------------------------
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

        public async Task<bool> Update(int idSeller,SellerUpdateDto sellerUpdateDto)
        {
            Seller seller = await db.Seller.FindAsync(idSeller);
            seller.Ten = sellerUpdateDto.Ten;
            seller.SDT = sellerUpdateDto.SDT;
            seller.DiaChi.Duong = sellerUpdateDto.DiaChi.Duong;
            seller.DiaChi.SoNha = sellerUpdateDto.DiaChi.SoNha;
            seller.DiaChi.TinhTP = sellerUpdateDto.DiaChi.TinhTP;
            seller.DiaChi.PhuongXa = seller.DiaChi.PhuongXa;
            seller.DiaChi.QuanHuyen = seller.DiaChi.QuanHuyen;
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> VerifyMail(int idUser, string code)
        {
            XacNhanMail xacNhanMail= await db.XacNhanMail.FindAsync(idUser);
            if (xacNhanMail != null && xacNhanMail.Code == code)
            {
                User user= await db.User.FindAsync(idUser);
                user.LoaiUser = ConstantVariable.UserPermission.SELLER;
                db.XacNhanMail.Remove(xacNhanMail);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

        private IQueryable<Seller> Filtering(IQueryable<Seller> sellers,SellerQuery query)
        {
            if(query.ID != null)
            {
                sellers = sellers.Where(x => x.ID == query.ID);
            }
            if (query.TenSeller != null)
            {
                sellers = from x in sellers
                          where x.Ten.Contains(query.TenSeller)
                          select x;
            }
            if (query.CMND != null)
            {
                sellers = from x in sellers
                          where x.CMND.Contains(query.CMND)
                          select x;
            }
            if (query.Mail != null)
            {
                sellers = from x in sellers
                          where x.Mail.Contains(query.Mail)
                          select x;
            }
            if (query.FromDanhGia != null)
            {
                sellers = sellers.Where(x => x.DanhGia >= query.FromDanhGia);
            }
            if (query.ToDanhGia != null)
            {
                sellers = sellers.Where(x => x.DanhGia <= query.ToDanhGia);
            }
            if (query.CheckMail != null)
            {
                sellers = sellers.Where(x => x.CheckMail == query.CheckMail);
            }
            if (query.CheckCMND != null)
            {
                sellers = sellers.Where(x => x.CheckCMND == query.CheckCMND);
            }

            return sellers;
        }
        #endregion
    }
}
