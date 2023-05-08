using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using Persistence;

namespace Application.Orders
{
  public class Details
  {
    public class Query : IRequest<OrderDto>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, OrderDto>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;

      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<OrderDto> Handle(Query request, CancellationToken cancellationToken)
      {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(o => o.Id == request.Id);

        order.TotalPrice = order.OrderItems.Sum(oi => oi.LinePrice);

        return order;
      }
    }
  }
}