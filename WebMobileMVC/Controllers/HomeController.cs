using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebMobileMVC.Models;

namespace WebMobileMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ModelChungTrangChu models = new ModelChungTrangChu();
            models.dsDanhMuc = new DanhMuc();
            models.dsSanPhamHot = new DSSanPham();
            models.dsSanPhamSearch = new DSSanPham();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var json1 = webClient.DownloadString("http://localhost:5000/api/DanhMucSP/get");
                string valueOriginal1 = Convert.ToString(json1);
                models.dsDanhMuc = JsonConvert.DeserializeObject<DanhMuc>(valueOriginal1);

                var json2 = webClient.DownloadString("http://localhost:5000/api/SanPham/gettopsearch");
                string valueOriginal2 = Convert.ToString(json2);
                models.dsSanPhamHot = JsonConvert.DeserializeObject<DSSanPham>(valueOriginal2);

                var json3 = webClient.DownloadString("http://localhost:5000/api/SanPham/gettopsearch");
                string valueOriginal3 = Convert.ToString(json3);
                models.dsSanPhamSearch = JsonConvert.DeserializeObject<DSSanPham>(valueOriginal3);

            }

            return View(models);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
