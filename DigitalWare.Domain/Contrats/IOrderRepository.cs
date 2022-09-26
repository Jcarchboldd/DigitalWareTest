using DigitalWare.Cross_cutting.Common;

namespace DigitalWare.Domain.Contrats
{
    public interface IOrderRepository<T>
    {
        public Task<MessageResult<T>> GetOrders();
    }
}