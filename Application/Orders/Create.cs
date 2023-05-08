using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Orders
{
  public class Create
  {
    public class Command : IRequest
    {
      public Order Order { get; set; }
    }

    public class Handler : IRequestHandler<Command>
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
        var order = _mapper.Map<Order>(request.Order);
        
        _context.Orders.Add(order);

        var success = await _context.SaveChangesAsync() > 0;

        if (success) return Unit.Value;

        throw new Exception("Problem saving changes");
      }
    }

  }
}