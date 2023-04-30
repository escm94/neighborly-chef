namespace Domain
{
    public class Meal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public List<Order> Orders { get; set; } = new();
    }
}