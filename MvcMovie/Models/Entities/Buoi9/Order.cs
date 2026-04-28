using System.ComponentModel.DataAnnotations;

public class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    // FK
    public int CustomerId { get; set; }

    public Customer Customer { get; set; }

    // 1 đơn có nhiều chi tiết
    public ICollection<OrderDetail> OrderDetails { get; set; }
}