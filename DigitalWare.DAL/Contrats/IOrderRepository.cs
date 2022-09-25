using DigitalWare.Cross_cutting.Common;
using DigitalWare.Domain.Models;

namespace DigitalWare.Domain.Contrats
{
    public interface IOrderRepository<T>
    {
        public Task<MessageResult<T>> GetOrders();
    }
}
