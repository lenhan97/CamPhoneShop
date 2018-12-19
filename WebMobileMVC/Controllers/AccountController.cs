
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMobileMVC.Helpers;
using WebMobileMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMobileMVC.Controllers
{
    public class AccountController : Controller
    {
        KhachHang khachhang = new KhachHang();
        private void GetInfo()
        {
            khachhang = ApiHelper.Get<KhachHang>(ConstantVariable.URLBase.baseUrl + "khachhang/getinfo");
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            GetInfo();

            return View(khachhang);
        }

        [HttpPost]
        public IActionResult Index([Bind("Ten,Mail,SDT,DiaChi")] KhachHangDto khachhangDto)
        {
            khachhangDto.DiaChi.SoNha = "";
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(khachhangDto);
            var result = ApiHelper.Post<KhachHangDto>(ConstantVariable.URLBase.baseUrl + "khachhang/update", json);
            GetInfo();
            return View(khachhang);
        }

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
            DiaChiDto diaChi = new DiaChiDto();
            register.Diachi = diaChi;
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
                    Helpers.ConstantVariable.token = token.Substring(1, token.Length - 3);
                    //return home
                    return RedirectToAction("index");
                }

            }
            return RedirectToAction("loginregister");
        }
    }
}