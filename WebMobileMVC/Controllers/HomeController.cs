using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebMobileMVC.Helpers;
using WebMobileMVC.Models;

namespace WebMobileMVC.Controllers
{
    public class HomeController : Controller
    {
        KhachHang khachHang = new KhachHang();
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

        //public IActionResult Header()
        //{
        //    khachHang = ApiHelper.Get<KhachHang>(ConstantVariable.URLBase.baseUrl + "khachhang/getinfo");
            
        //    return ViewComponent("Header");
        //}
    }
}
