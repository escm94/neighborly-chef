using Domain;

namespace Persistence
{
  public class Seed
    {
        public static async Task SeedData(DataContext context)
        {

            if (context.Meals.Any()) return;
            
            var meals = new List<Meal>
            {
                new Meal
                {
                    Name = "Baked Ziti",
                    Description = "Laborum cillum id ut ea in Lorem amet commodo nostrud esse.",
                    UnitPrice = 9.99m,
                },
                new Meal
                {
                    Name = "Meatball Sub",
                    Description = "Excepteur eu in tempor culpa exercitation nulla sunt laboris mollit proident ullamco qui quis.",
                    UnitPrice = 8.99m,
                },
                new Meal
                {
                    Name = "Broccoli Cheddar Soup",
                    Description = "Fugiat tempor adipisicing nulla culpa minim reprehenderit aliquip.",
                    UnitPrice = 5.99m,
                },
                new Meal
                {
                    Name = "Bacon Cheeseburger",
                    Description = "Sit qui aute mollit deserunt.",
                    UnitPrice = 10.99m,
                }
            };

            await context.Meals.AddRangeAsync(meals);
            await context.SaveChangesAsync();
        }
    }
}