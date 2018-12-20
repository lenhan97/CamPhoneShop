using System;
using System.Collections.Generic;
using WebMobileMVC.Models;

namespace WebMobileMVC.Helpers
{
    public static class ConstantVariable
    {
        public static string token { get; set; }
        public static class URLBase
        {
            public static string baseUrl = "http://localhost:5000/api/";
        }
        public static List<SanPham> dsSanPham = new List<SanPham>();
    }
}
