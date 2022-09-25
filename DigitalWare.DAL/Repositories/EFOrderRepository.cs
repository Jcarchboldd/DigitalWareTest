using AutoMapper;
using DigitalWare.Cross_cutting.Common;
using DigitalWare.Cross_cutting.DTO;
using DigitalWare.Domain.Contrats;
using DigitalWare.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace DigitalWare.DAL.Repositories
{
    public class EFOrderRepository : IOrderRepository<OrderDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EFOrderRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MessageResult<OrderDTO>> GetOrders()
        {
            try
            {
                var orders = await _context.Order
                    .Include(p => p.Order_Details)
                    .Include(p => p.Customer)
                    .Select(p => p).ToListAsync();

                var _orders = _mapper.Map<List<OrderDTO>>(orders);
                return new MessageResult<OrderDTO>(error: false, items: _orders);

            }
            catch (Exception ex)
            {
                return new MessageResult<OrderDTO>(error: true, responseMessage: ex.Message);
            }

        }

    }
}
