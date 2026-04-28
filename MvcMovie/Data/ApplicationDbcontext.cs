using Microsoft.EntityFrameworkCore;
using MvcMovie.Models.Entities;

namespace MvcMovie.Data
{
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {}
    public DbSet<Student> Students { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    //buoi9
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
}
}