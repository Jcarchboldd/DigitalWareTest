using AutoMapper;
using DigitalWareTestAPI.Data;
using DigitalWareTestAPI.DTO;
using DigitalWareTestAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalWareTestAPI.DAL
{
    public class EFOrderRepository: IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public readonly IMapper _mapper;

        public EFOrderRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            return await _context.Order
                    .Include(p => p.Order_Details)
                    .Include(p => p.Customer)
                    .Select(p => _mapper.Map<OrderDTO>(p)).ToListAsync();
        }

    }
}
