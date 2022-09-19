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
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Order_DetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Order_DetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
