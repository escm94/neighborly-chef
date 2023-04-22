using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Meals
{
  public class Update
  {
    public class Command : IRequest<Unit>
    {
      public Meal Meal { get; set; }
    }

    public class Handler : IRequestHandler<Command, Unit>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;

      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var meal = await _context.Meals.FindAsync(request.Meal.Id);

        _mapper.Map(request.Meal, meal);

        await _context.SaveChangesAsync();

        return Unit.Value;
      }
    }
  }
}