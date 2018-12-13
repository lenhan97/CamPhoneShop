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
            DanhMuc listDM = new DanhMuc();
            using (WebClient webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString("http://localhost:5000/api/DanhMucSP/get");
                string valueOriginal = Convert.ToString(json);
                listDM = JsonConvert.DeserializeObject<DanhMuc>(valueOriginal);
            }

            return View(listDM);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
