using DigitalWare.Cross_cutting.Common;

namespace DigitalWare.Domain.Contrats
{
    public interface IProductRepository<T>
    {
        public Task<MessageResult<T>> GetProducts();
    }
}
