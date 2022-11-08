namespace solfordTestCase.Domain.Models
{
    public class OrderItem: BaseEntity
    {
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public string? Name { get; set; }
        public Decimal Quantity { get; set; }
        public string? Unit { get; set; }
    }
}