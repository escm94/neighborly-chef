namespace Application.OrderItems
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }
        public Guid MealId { get; set; }
        public string MealName { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal LinePrice { get; set; }
    }
}