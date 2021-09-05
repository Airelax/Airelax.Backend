using Airelax.Application.Orders.Request;

namespace Airelax.Application.Orders
{
    public interface IOrderService
    {
        bool CreateOrder(OrdersInput input);
    }
}