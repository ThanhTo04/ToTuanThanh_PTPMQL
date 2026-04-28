using System.ComponentModel.DataAnnotations;

public class OrderDetail
{
    public int OrderDetailId { get; set; }

    // FK
    public int OrderId { get; set; }
    public Order Order { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; }

    [Range(1, 1000)]
    public int Quantity { get; set; }
}