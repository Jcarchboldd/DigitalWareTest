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
        public readonly IOrderRepository _repository;
        public readonly IMapper _mapper;

        public OrdersController(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetOrders")]
        public async Task<MessageResult<OrderDTO>> Get()
        {
            var result = await _repository.GetOrders();

            return  new MessageResult<OrderDTO>(result.Error, result.ResponseMessage, result.Items.Select(p => _mapper.Map<OrderDTO>(p)).ToList());
        }

      
    }
}
