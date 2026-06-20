using System.ComponentModel.DataAnnotations;
namespace MvcMovie.Models.Entities
{
public class DonHang
{
    public int Id { get; set; }

    public int STT { get; set; }

    public string? TenKH { get; set; }
    public string? MaDonHang { get; set; } ="";
    public ICollection<ChiTietDonHang>? ChiTietDonHang { get; set; }

}}