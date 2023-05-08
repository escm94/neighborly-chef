namespace Domain
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;
        public Guid MealId { get; set; }
        public Meal Meal { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal LinePrice { get; set; }
    }
}