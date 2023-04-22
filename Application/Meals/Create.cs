using Domain;
using MediatR;
using Persistence;

namespace Application.Meals
{
    public class Create
    {
        // Command class
        public class Command : IRequest
        {
            public Meal Meal { get; set; }
        }

        // Handler class
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Meals.Add(request.Meal);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}