namespace Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Meal> Meals { get; set; } = new();
        public decimal TotalPrice { get; set; }
    }
}