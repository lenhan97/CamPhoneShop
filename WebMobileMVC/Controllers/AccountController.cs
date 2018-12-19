
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMobileMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMobileMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        //[HttpGet]
        public IActionResult Index()
        {
            //DSKhachHang listKH = new DSKhachHang();

            //var json1 = WebClient.DownloadString("http://localhost:5000/api/khachhang/get/1");
            //string valueOriginal1 = Convert.ToString(json1);
            //listKH = JsonConvert.DeserializeObject<DSKhachHang>(valueOriginal1);

            //return View(listKH);
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Index([Bind("Ten,SDT,Mail")] KhachHangDto khachHang)
        //{
        //    return View();
        //}

        public IActionResult LoginRegister()
        {
            return View();
        }

        public IActionResult Bank()
        {           
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult Notification()
        {
            return View();
        }

        public IActionResult OrderDetail()
        {
            return View();
        }

        public IActionResult Orders()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult Wishlist()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([Bind("Ten,SDT,Mail,MatKhau")] RegisterDto register)
        {
            //DiaChiDto diaChi = new DiaChiDto();
            //diaChi.SoNha = "123";
            //diaChi.Duong = "TL 19";
            //diaChi.PhuongXa = "Thanh Loc";
            //diaChi.QuanHuyen = "12";
            //diaChi.TinhTP = "HCM";
            //register.Diachi = diaChi;
            if(register.TenDN == null)
            {
                register.TenDN = register.Mail;
            }

            if(ModelState.IsValid)
            {
                register.MatKhau = Helpers.Encryptor.MD5Hash(register.MatKhau);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5000/");
                    var postTask = await client.PostAsJsonAsync<RegisterDto>("api/user/add", register);
                    //postTask.Wait();

                    var result = postTask;
                }

            }
            return View(register);
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("TenDN, Matkhau")] LoginDto login)
        {
            login.Matkhau = Helpers.Encryptor.MD5Hash(login.Matkhau);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/");
                var post = await client.PostAsJsonAsync<LoginDto>("api/user/login", login);
                //post.Wait();

                var result = await post.Content.ReadAsStringAsync();
                if(post.IsSuccessStatusCode)
                {
                    string token = result.Split(":")[1];
                    Helpers.ConstantVariable.token = token.Substring(1, token.Length - 2);
                    //return home

                }

            }
            return RedirectToAction("loginregister");
        }
    }
}