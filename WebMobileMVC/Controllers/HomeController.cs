using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebMobileMVC.Helpers;
using WebMobileMVC.Models;

namespace WebMobileMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HomeModel models = new HomeModel();

            models.dsDanhMuc = ApiHelper.Get<ListModel<DanhMucSP>>(ConstantVariable.URLBase.baseUrl + "danhmucsp/get");
            models.dsSanPhamHot = models.dsSanPhamSearch = ApiHelper.Get<ListModel<SanPham>>(ConstantVariable.URLBase.baseUrl + "sanpham/gettopsearch");

            return View(models);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
