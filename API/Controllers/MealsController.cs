using Domain;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Meals;

namespace API.Controllers
{
  public class MealsController : BaseApiController
  {
    [HttpGet]
    public async Task<ActionResult<List<Meal>>> GetMeals()
    {
      return await Mediator.Send(new List.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Meal>> GetMeal(Guid id)
    {
      return await Mediator.Send(new Details.Query { Id = id });
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<Unit>> UpdateMeal(Guid id, Meal meal)
    {
      meal.Id = id;
      return await Mediator.Send(new Update.Command { Meal = meal });
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<Unit>> DeleteMeal(Guid id)
    {
      return await Mediator.Send(new Delete.Command { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<Unit>> CreateMeal(Meal meal)
    {
      return await Mediator.Send(new Create.Command { Meal = meal });
    }
  }
}