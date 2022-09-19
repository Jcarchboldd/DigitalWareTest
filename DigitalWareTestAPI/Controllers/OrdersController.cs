using DigitalWareTestAPI.Data;
using DigitalWareTestAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalWareTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            try
            {
                return await (from o in _context.Orders
                        join c in _context.Customers on o.CustomerID equals c.CustomerID
                        join od in _context.Order_Details.GroupBy(p => p.OrderID).Select(p => new Order_Detail { OrderID = p.Key, Quantity = p.Sum(c => c.Quantity), UnitPrice = p.Sum(c => c.UnitPrice) }) on o.OrderID equals od.OrderID
                        select new Order
                        {
                            OrderID = o.OrderID,
                            CustomerID = o.CustomerID,
                            OrderDate = o.OrderDate,
                            CustomerName = c.FullName,
                            Amount = od.Quantity * od.UnitPrice

                        })
                        .ToListAsync();

            }
            catch (Exception ex)
            {

                return (BadRequest(ex.Message));
            }
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
