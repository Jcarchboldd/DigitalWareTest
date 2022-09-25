using AutoMapper;
using DigitalWare.Cross_cutting.Common;
using DigitalWare.Cross_cutting.DTO;
using DigitalWare.Domain.Contrats;
using DigitalWare.Domain.Data;
using Microsoft.EntityFrameworkCore;

namespace DigitalWare.DAL.Repositories
{
    public class EFProductRepository : IProductRepository<ProductsListDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EFProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MessageResult<ProductsListDTO>> GetProducts()
        {
            try
            {
                var list = await _context.Product.ToListAsync();

                var _orders = _mapper.Map<List<ProductsListDTO>>(list);
                return new MessageResult<ProductsListDTO>(error: false, items: _orders);
            }
            catch (Exception ex)
            {

                return new MessageResult<ProductsListDTO>(error: true, responseMessage: ex.Message);
            }
        }
    }
}
