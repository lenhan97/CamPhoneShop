using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebMobileMVC.Helpers;
using WebMobileMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMobileMVC.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View(Helpers.ConstantVariable.dsSanPham);
        }

        // GET: /<controller>/
        public IActionResult Add(int id)
        {
            ListModel<SanPham> sp = ApiHelper.Get<ListModel<SanPham>>(ConstantVariable.URLBase.baseUrl + "sanpham/get/" + id);
            if(sp!= null)
            {
                if (sp.Content[0].PhanLoaiSP[0].SoLuong >= 1)
                {
                    if (ConstantVariable.dsSanPham.Any(x => x.ID == sp.Content[0].ID))
                    {
                        ConstantVariable.dsSanPham.Where(x => x.ID == sp.Content[0].ID).FirstOrDefault().SoLuong += 1;
                    }
                    else
                    {
                        CartViewModel cart = new CartViewModel();
                        cart.SoLuong = 1;
                        cart.ID = sp.Content[0].ID;
                        cart.Ten = sp.Content[0].Ten;
                        cart.GiaBan = sp.Content[0].PhanLoaiSP[0].GiaBan;
                        cart.GiaKM = sp.Content[0].PhanLoaiSP[0].GiaKM == null ? 0 : sp.Content[0].PhanLoaiSP[0].GiaKM.GetValueOrDefault();
                        cart.Hinh = sp.Content[0].Hinh;
                        cart.Mau = sp.Content[0].PhanLoaiSP[0].Mau;
                        ConstantVariable.dsSanPham.Add(cart);
                    }
                }
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Del(int? id)
        {
            if(id != null)
            {
                foreach (CartViewModel i in Helpers.ConstantVariable.dsSanPham)
                {
                    if (i.ID == id)
                    {
                        Helpers.ConstantVariable.dsSanPham.Remove(i);
                        break;
                    }
                }
                return Redirect(Request.Headers["Referer"].ToString());
            }
            Helpers.ConstantVariable.dsSanPham.Clear();
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
