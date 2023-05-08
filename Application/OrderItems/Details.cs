using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.OrderItems
{
    public class Details
    {
        public class Query : IRequest<OrderItemDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, OrderItemDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            
            public async Task<OrderItemDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var orderItem = await _context.OrderItems.FindAsync(request.Id);

                if (orderItem == null)
                    throw new Exception("Could not find order item");

                var orderItemToReturn = await _context.OrderItems
                    .ProjectTo<OrderItemDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(oi => oi.Id == request.Id);

                return orderItemToReturn;
            }
        }
    }
}