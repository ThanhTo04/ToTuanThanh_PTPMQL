using System.ComponentModel.DataAnnotations;

public class Customer
{
    public int CustomerId { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    // 1 khách hàng có nhiều đơn hàng
    public ICollection<Order> Orders { get; set; }
}