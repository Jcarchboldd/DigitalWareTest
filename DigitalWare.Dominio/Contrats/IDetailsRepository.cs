using DigitalWare.Cross_cutting.Common;

namespace DigitalWare.Domain.Contrats
{
    public interface IDetailsRepository<T>
    {
        public Task<MessageResult<T>> GetById(int Id);
        public Task<MessageResult<T>> PostDetail(int Id, T _object);
        public Task<MessageResult<T>> PutDetail(T _object);
        public Task<MessageResult<T>> DeleteDetail(int id, int id2);
    }
}
