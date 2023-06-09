namespace Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<OrderItem> OrderItems { get; } = new List<OrderItem>();
        public decimal TotalPrice { get; set; }
    }
}