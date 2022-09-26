
using AutoMapper;
using DigitalWare.Cross_cutting.Common;
using DigitalWare.Cross_cutting.DTO;
using DigitalWare.Domain.Contrats;
using DigitalWare.Domain.Data;
using DigitalWare.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalWare.DAL.Repositories
{
    public class EFDetailRepository : IDetailsRepository<DetailsDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EFDetailRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MessageResult<DetailsDTO>> GetById(int id)
        {
            try
            {
                var details = await _context.Order_Detail.Where(p => p.OrderID == id).ToListAsync();
                var _details = _mapper.Map<List<DetailsDTO>>(details);

                return new MessageResult<DetailsDTO>(error: false, items: _details);
            }
            catch (Exception ex)
            {

                return new MessageResult<DetailsDTO>(error: true, responseMessage: ex.Message);
            }
        }

        public async Task<MessageResult<DetailsDTO>> PostDetail(int id, DetailsDTO order)
        {

            try
            {
                order.OrderID = id;

                var obj = await _context.Order_Detail.FindAsync(order.OrderID, order.ProductID);

                if (obj != null)
                {
                    throw new ArgumentException(nameof(obj));
                }

                var _order = _mapper.Map<Order_Detail>(order);
                _context.Order_Detail.Add(_order);
                await _context.SaveChangesAsync();

                return new MessageResult<DetailsDTO>(error: false);
            }
            catch (Exception ex)
            {
                return new MessageResult<DetailsDTO>(error: true, responseMessage: ex.Message);
            }
        }

        public async Task<MessageResult<DetailsDTO>> PutDetail(DetailsDTO order)
        {

            var _order = _mapper.Map<Order_Detail>(order);
            _context.Entry(_order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return new MessageResult<DetailsDTO>(error: false);

            }
            catch (Exception ex)
            {
                return new MessageResult<DetailsDTO>(error: true, responseMessage: ex.Message);
            }
        }

        public async Task<MessageResult<DetailsDTO>> DeleteDetail(int id, int id2)
        {

            try
            {
                var _order = await _context.Order_Detail.FindAsync(id, id2);

                if (_order == null)
                {
                    throw new ArgumentNullException(nameof(id));
                }

                _context.Order_Detail.Remove(_order);
                await _context.SaveChangesAsync();

                return new MessageResult<DetailsDTO>(error: false);
            }
            catch (Exception ex)
            {

                return new MessageResult<DetailsDTO>(error: true, responseMessage: ex.Message);
            }
        }

    }
}