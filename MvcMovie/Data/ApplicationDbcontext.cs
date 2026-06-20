using Microsoft.EntityFrameworkCore;
using MvcMovie.Models.Entities;

namespace MvcMovie.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // ===== Student + Faculty =====
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }

        // ===== Customer Order Product =====
        public DbSet<KhachHang> KhachHang { get; set; }
        public DbSet<DonHang> DonHang { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
    }
}