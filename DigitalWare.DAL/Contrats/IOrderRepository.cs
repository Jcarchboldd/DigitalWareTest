using DigitalWare.Cross_cutting.Common;
using DigitalWare.Domain.Models;

namespace DigitalWare.Domain.Contrats
{
    public interface IOrderRepository
    {
        public Task<MessageResult<Order>> GetOrders();
    }
}
