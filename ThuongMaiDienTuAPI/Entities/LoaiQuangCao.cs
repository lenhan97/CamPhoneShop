using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ThuongMaiDienTuAPI.Entities
{
    public class LoaiQuangCao
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(56)]
        public string ViTri { get; set; }
        public double Gia { get; set; }
        public bool TinhTrang { get; set; }
    }
}
