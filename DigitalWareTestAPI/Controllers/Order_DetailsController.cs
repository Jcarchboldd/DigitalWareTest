using AutoMapper;
using DigitalWare.Cross_cutting.Common;
using DigitalWare.Domain.Contrats;
using DigitalWare.Domain.Data;
using DigitalWare.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalWareTestAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class Order_DetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public readonly IMapper _mapper;
        public readonly IDetailsRepository<Order_Detail> _repository;

        public Order_DetailsController(ApplicationDbContext context, IMapper mapper, IDetailsRepository<Order_Detail> repository)
        {
            _context = context;
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<MessageResult<Order_Detail>> Get(int id)
        {
            return await _repository.GetById(id);
        }

        [HttpPost("{id}")]
        public async Task<MessageResult<Order_Detail>> Post(int id, Order_Detail order)
        {
            return await _repository.PostDetail(id, order);
        }

        // PUT api/<Order_DetailsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Order_Detail order)
        {

            order.OrderID = id;
            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                return Ok(order);

            }
            catch (Exception ex)
            {

                return (BadRequest(ex.Message));
            }

        }

        // DELETE api/<Order_DetailsController>/5
        [HttpDelete("{id}/{id2}")]
        public async Task<IActionResult> Delete(int id, int id2)
        {
            try
            {
                var _order = await _context.Order_Detail.FindAsync(id, id2);

                if (_order == null)
                {
                    return NotFound();
                }

                _context.Order_Detail.Remove(_order);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
