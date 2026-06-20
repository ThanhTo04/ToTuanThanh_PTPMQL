using System.ComponentModel.DataAnnotations;
namespace MvcMovie.Models.Entities
{

public class KhachHang
{
    public int Id { get; set; }

    [Required]
    public required string HoTen { get; set; }

    public string? DiaChi { get; set; }

    [Phone]
    public string? SoDienThoai { get; set; }
}}