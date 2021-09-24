using System.Threading.Tasks;
using Airelax.Application.Orders.Request;
using Airelax.Application.Orders.Response;
using Airelax.Infrastructure.ThirdPartyPayment.ECPay.Request;

namespace Airelax.Application.Orders
{
    public interface IOrderService
    {
        CreateOrderResponse CreateOrder(OrdersInput input);
        Task<bool> Transact(CreateTransactionInput input);
    }
}