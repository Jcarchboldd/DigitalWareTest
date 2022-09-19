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

        public Order_DetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<Order_DetailsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order_Detail>>> Get()
        {
            try
            {
                return await _context.Order_Details.ToListAsync();
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
                return await _context.Order_Details.Where(p => p.OrderID == id).ToListAsync();
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
                _context.Order_Details.Add(order);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {

                return (BadRequest(ex.Message));
            }
        }

        // PUT api/<Order_DetailsController>/5
        [HttpPut]
        public async Task<IActionResult> Put(Order_Detail order)
        {
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
                var _order = await _context.Order_Details.FindAsync(id, id2);

                if (_order == null)
                {
                    return NotFound();
                }

                _context.Order_Details.Remove(_order);
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
