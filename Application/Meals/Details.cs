using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Meals
{
    public class Details
    {
        public class Query : IRequest<Meal> 
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Meal>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Meal> Handle(Query request, CancellationToken cancellationToken)
            {
                var meal = await _context.Meals.FindAsync(request.Id);

                return meal;
            }
        }
    }
}