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

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Meal>> Handle(Query request, CancellationToken cancellationToken)
            {
                var meals = await _context.Meals.ToListAsync();

                return meals;
            }
        }
    }
}