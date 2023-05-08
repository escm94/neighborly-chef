using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Meals
{
  public class List
  {
    public class Query : IRequest<List<Meal>> { }

    public class Handler : IRequestHandler<Query, List<Meal>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;

      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<List<Meal>> Handle(Query request, CancellationToken cancellationToken)
      {
        var meals = await _context.Meals.ToListAsync();
        var mealsToReturn = _mapper.Map<List<Meal>>(meals);
        
        return mealsToReturn;
      }
    }
  }
}