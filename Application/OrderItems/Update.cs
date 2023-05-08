using AutoMapper;
using MediatR;
using Persistence;

namespace Application.OrderItems
{
  public class Update
  {
    public class Command : IRequest
    {
      public OrderItemDto OrderItem { get; set; }
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
        var orderItem = await _context.OrderItems.FindAsync(request.OrderItem.Id);

        _mapper.Map(request.OrderItem, orderItem);  

        if (orderItem == null) throw new Exception("Could not find order item");

        var success = await _context.SaveChangesAsync() > 0;

        if (success) return Unit.Value;

        throw new Exception("Problem saving changes");
      }
    }
  }
}