using Application.Orders;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.OrderItems
{
  public class Create
  {
    public class Command : IRequest
    {
      public OrderItem OrderItem { get; set; }
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
        var orderItem = _mapper.Map<OrderItem>(request.OrderItem);
        orderItem.LinePrice = orderItem.Quantity * _context.Meals.Find(orderItem.MealId).UnitPrice;    

        _context.OrderItems.Add(orderItem);

        var success = await _context.SaveChangesAsync() > 0;

        if (success) return Unit.Value;

        throw new Exception("Problem saving changes");
      }
    }
  }
}