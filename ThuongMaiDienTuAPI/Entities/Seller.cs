using System;
using System.ComponentModel.DataAnnotations;
namespace ThuongMaiDienTuAPI.Entities
{
    public class Seller
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(20)]
        public string CMND { get; set; }
        [MaxLength(128)]
        [EmailAddress]
        public string Mail { get; set; }
        public bool? CheckMail { get; set; }
        public bool? CheckCMND { get; set; }
        public DateTime NgayDK { get; set; }
        public int? IDDiaChi { get; set; }
        [MaxLength(256)]
        public string Ten { get; set; }
        [MaxLength(50)]
        public string SDT { get; set; }
        public DateTime ThoiGianHetHan { get; set; }

        public DiaChi DiaChi { get; set; }
    }
}
