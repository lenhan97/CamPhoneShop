using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebMobileMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMobileMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index(string id)
        {
            ModelChungSanPham models = new ModelChungSanPham();
            models.danhSachDanhMuc = new DanhMuc(); 
            models.danhSachSanPham = new DSSanPham();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var json1 = webClient.DownloadString("http://localhost:5000/api/DanhMucSP/get");
                string valueOriginal1 = Convert.ToString(json1);
                models.danhSachDanhMuc = JsonConvert.DeserializeObject<DanhMuc>(valueOriginal1);

                var json2 = webClient.DownloadString("http://localhost:5000/api/SanPham/"+id);
                string valueOriginal2 = Convert.ToString(json2);
                models.danhSachSanPham = JsonConvert.DeserializeObject<DSSanPham>(valueOriginal2);
            }

            return View(models);
        }


        public IActionResult Detail(int id)
        {
            DSSanPham item = new DSSanPham();

            ModelChungCTSanPham models = new ModelChungCTSanPham();
            models.SanPham = new SanPham();
            models.Seller = new DSSeller();

            using (WebClient webClient = new System.Net.WebClient())
            {
                var json1 = webClient.DownloadString("http://localhost:5000/api/SanPham/get/" + id);
                string valueOriginal1 = Convert.ToString(json1);
                item = JsonConvert.DeserializeObject<DSSanPham>(valueOriginal1);
                models.SanPham = item.content[0];

                var json2 = webClient.DownloadString("http://localhost:5000/api/Seller/get?ID=" + models.SanPham.IDSeller);
                string valueOriginal2 = Convert.ToString(json2);
                models.Seller = JsonConvert.DeserializeObject<DSSeller>(valueOriginal2);

            }

            return View(models);
        }
    }
}
