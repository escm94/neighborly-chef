using MediatR;
using Domain;
using Persistence;
using AutoMapper;

namespace Application.Orders
{
    public class Update
    {
        public class Command : IRequest
        {
            public OrderDto Order { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var order = await _context.Orders.FindAsync(request.Order.Id);

                if (order == null) throw new Exception("Could not find order");

                _mapper.Map(request.Order, order);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}