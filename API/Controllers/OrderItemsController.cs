using Application.OrderItems;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class OrderItemsController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItemDto>> GetOrderItem(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }
        
        [HttpPost]
        public async Task<ActionResult<Unit>> CreateOrderItem(OrderItem orderItem)
        {
            return await Mediator.Send(new Create.Command { OrderItem = orderItem });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> EditOrderItem(Guid id, OrderItemDto orderItem)
        {
            orderItem.Id = id;
            return await Mediator.Send(new Update.Command { OrderItem = orderItem });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteOrderItem(Guid id)
        {
            return await Mediator.Send(new Delete.Command { Id = id });
        }
    }
}