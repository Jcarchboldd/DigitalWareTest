using AutoMapper;
using DigitalWareTestAPI.Data;
using DigitalWareTestAPI.Data.Models;
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

        public Order_DetailsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<Order_DetailsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order_Detail>>> Get()
        {
            try
            {   
                return await _context.Order_Detail.ToListAsync();
            }
            catch (Exception ex)
            {

                return (BadRequest(ex.Message));
            }
        }

        // GET api/<Order_DetailsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Order_Detail>>> Get(int id)
        {
            try
            {
                return await _context.Order_Detail.Where(p => p.OrderID == id).ToListAsync();
            }
            catch (Exception ex)
            {

                return (BadRequest(ex.Message));
            }
        }

        // POST api/<Order_DetailsController>
        [HttpPost("{id}")]
        public async Task<IActionResult> Post(int id, Order_Detail order)
        {
            try
            {
                order.OrderID = id;

                var obj = await _context.Order_Detail.FindAsync(order.OrderID, order.ProductID);

                if(obj != null)
                {
                    return BadRequest("Ya existe ese producto en la orden");
                }
          
                _context.Order_Detail.Add(order);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {

                return (BadRequest(ex.Message));
            }
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
