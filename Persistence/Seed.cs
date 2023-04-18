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
                },
                new Meal
                {
                    Name = "Meatball Sub",
                    Description = "Excepteur eu in tempor culpa exercitation nulla sunt laboris mollit proident ullamco qui quis.",
                },
                new Meal
                {
                    Name = "Broccoli Cheddar Soup",
                    Description = "Fugiat tempor adipisicing nulla culpa minim reprehenderit aliquip.",
                },
                new Meal
                {
                    Name = "Bacon Cheeseburger",
                    Description = "Sit qui aute mollit deserunt.",
                }
            };

            await context.Meals.AddRangeAsync(meals);
            await context.SaveChangesAsync();
        }
    }
}