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
    public class Order_DetailsController : ControllerBase
    {
        public readonly IDetailsRepository<DetailsDTO> _repository;

        public Order_DetailsController(IDetailsRepository<DetailsDTO> repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<MessageResult<DetailsDTO>> Get(int id)
        {
            return await _repository.GetById(id);
        }

        [HttpPost("{id}")]
        public async Task<MessageResult<DetailsDTO>> Post(int id, DetailsDTO order)
        {
            return await _repository.PostDetail(id, order);
        }

        [HttpPut]
        public async Task<MessageResult<DetailsDTO>> Put(DetailsDTO order)
        {
            return await _repository.PutDetail(order);
        }

        [HttpDelete("{id}/{id2}")]
        public async Task<MessageResult<DetailsDTO>> Delete(int id, int id2)
        {
            return await _repository.DeleteDetail(id, id2);
        }
    }
}
