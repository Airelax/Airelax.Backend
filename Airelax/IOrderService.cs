using Microsoft.AspNetCore.Mvc;

namespace Airelax
{
    public interface IOrderService
    {
        bool CreateOrder([FromBody] OrdersInput input);
    }
}