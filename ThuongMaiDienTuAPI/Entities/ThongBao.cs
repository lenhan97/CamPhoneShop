using System;
using System.ComponentModel.DataAnnotations;
namespace ThuongMaiDienTuAPI.Entities
{
    public class ThongBao
    {
        [Key]
        public int ID { get; set; }
        public int IDUser { get; set; }
        public DateTime Ngay { get; set; }
        public string NoiDung { get; set; }
        [MaxLength(256)]
        public string URL { get; set; }
        public string TinhTrang { get; set; }
    }
}
