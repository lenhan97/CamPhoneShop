using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ThuongMaiDienTuAPI.Dtos.Queries;
using ThuongMaiDienTuAPI.Interfaces;
using ThuongMaiDienTuAPI.Entities;
using ThuongMaiDienTuAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

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
            return await db.Seller.FindAsync(user.IdSeller);
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
                    user.IdSeller = seller.ID;
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
