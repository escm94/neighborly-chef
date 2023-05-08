using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Orders
{
  public class List
  {
    public class Query : IRequest<List<OrderDto>> { }

    public class Handler : IRequestHandler<Query, List<OrderDto>>
    {
      private readonly DataContext _context;
      private readonly IMapper _mapper;

      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<List<OrderDto>> Handle(Query request, CancellationToken cancellationToken)
      {
        var orders = await _context.Orders.Include(o => o.OrderItems).ToListAsync();        
        var ordersToReturn = _mapper.Map<List<OrderDto>>(orders);
        
        ordersToReturn.ForEach(o => 
        {
          o.OrderItems.ForEach(oi => oi.MealName = _context.Meals.Find(oi.MealId).Name);
          o.TotalPrice = o.OrderItems.Sum(oi => oi.LinePrice);
        });
        
        return ordersToReturn;
      }
    }
  }
}