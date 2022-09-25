using DigitalWare.Cross_cutting.Common;
using DigitalWare.Domain.Contrats;
using DigitalWare.Domain.Data;
using DigitalWare.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalWare.DAL.Repositories
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        readonly List<Order> list = new();

        public EFOrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MessageResult<Order>> GetOrders()
        {
            try
            {
                var orders = await _context.Order
                    .Include(p => p.Order_Details)
                    .Include(p => p.Customer)
                    .Select(p => p).ToListAsync();

                return new MessageResult<Order>(error: false, responseMessage: "La información se ha cargado correctamente", orders);

            }
            catch (Exception ex)
            {
                return new MessageResult<Order>(error: true, responseMessage: ex.Message, list);
            }

        }

    }
}
