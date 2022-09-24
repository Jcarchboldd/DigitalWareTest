using DigitalWareTestAPI.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DigitalWareTestAPI.Services
{
    public interface IOrderRepository
    {
        Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders();

    }
}
