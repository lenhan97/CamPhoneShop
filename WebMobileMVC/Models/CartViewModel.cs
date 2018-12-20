using System;
namespace WebMobileMVC.Models
{
    public class CartViewModel
    {
        public int ID { get; set; }
        public string Ten { get; set; }
        public int SoLuong { get; set; }
        public double GiaBan { get; set; }
        public double GiaKM { get; set; }
        public string Hinh { get; set; }
        public string Mau { get; set; }
    }
}
