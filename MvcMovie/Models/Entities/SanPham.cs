using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models.Entities
{
    public class SanPham
    {
        public int Id { get; set; }

        [Required]
        public string TenSanPham { get; set; } = "";

        public decimal Gia { get; set; }

        public int SoLuongTon { get; set; }
        [Required]
        public string MaSanPham { get; set; } = "";
        public ICollection<ChiTietDonHang>? ChiTietDonHang { get; set; }
    }
}