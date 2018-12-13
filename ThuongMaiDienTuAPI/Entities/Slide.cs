using System.ComponentModel.DataAnnotations;
namespace ThuongMaiDienTuAPI.Entities
{
    public class Slide
    {
        [Key]
        public int ID{ get; set; }
        [MaxLength(256)]
        public string Hinh { get; set; }
        public string NoiDung { get; set; }
        [MaxLength(256)]
        public string URL { get; set; }
        public bool TinhTrang { get; set; }
    }
}
