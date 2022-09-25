using AutoMapper;
using DigitalWare.Cross_cutting.Common;
using DigitalWare.Cross_cutting.DTO;
using DigitalWare.Domain.Contrats;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalWareTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public readonly IOrderRepository<OrderDTO> _repository;
        public readonly IMapper _mapper;

        public OrdersController(IOrderRepository<OrderDTO> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetOrders")]
        public async Task<MessageResult<OrderDTO>> Get()
        {
            return await _repository.GetOrders();

        }

      
    }
}
