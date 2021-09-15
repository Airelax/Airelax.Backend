using Airelax.Application.Orders.Request;
using Airelax.Application.Orders.Response;

namespace Airelax.Application.Orders
{
    public interface IOrderService
    {
        CreateOrderResponse CreateOrder(OrdersInput input);
    }
}