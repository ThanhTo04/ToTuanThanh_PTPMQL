using System.ComponentModel.DataAnnotations;
namespace MvcMovie.Models.Entities
{
public class ChiTietDonHang
{
    public int Id { get; set; }

    public int STT { get; set; }

    public string? TenKH { get; set; }
    public string? MaDonHang { get; set; }
    public DonHang? DonHang { get; set; }
    public int MaSanPham { get; set; }
    public SanPham? SanPham { get; set; }

}}