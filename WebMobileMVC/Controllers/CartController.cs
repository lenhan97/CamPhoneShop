using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebMobileMVC.Helpers;
using WebMobileMVC.Models;
using static System.Collections.Specialized.BitVector32;

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
        public IActionResult Add(int? id)
        {
            GioHangModel gioHang = new GioHangModel();

            if (id != null)
            {
                using (WebClient webClient = new System.Net.WebClient())
                {
                    gioHang.dsSanPham = ApiHelper.Get<ListModel<SanPham>>(ConstantVariable.URLBase.baseUrl + "sanpham/get/" + id);

                    SanPham sp = new SanPham();
                    sp = gioHang.dsSanPham.Content[0];

                    foreach (SanPham i in Helpers.ConstantVariable.dsSanPham)
                    {
                        if (i.ID == id)
                        {

                            break;
                        }
                    }

                    Helpers.ConstantVariable.dsSanPham.Add(sp);
                }
            }
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Del(int id)
        {
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
