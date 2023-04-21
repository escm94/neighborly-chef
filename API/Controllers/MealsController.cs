using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
  public class MealsController : BaseApiController
  {
    private readonly DataContext _context;
    public MealsController(DataContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Meal>>> GetMeals()
    {
        return await _context.Meals.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Meal>> GetMeal(Guid id)
    {
        return await _context.Meals.FindAsync(id);
    }
  }
}