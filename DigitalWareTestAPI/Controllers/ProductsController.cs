using DigitalWare.Cross_cutting.Common;
using DigitalWare.Cross_cutting.DTO;
using DigitalWare.Domain.Contrats;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DigitalWareTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public readonly IProductRepository<ProductsListDTO> _repository;

        public ProductsController(IProductRepository<ProductsListDTO> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<MessageResult<ProductsListDTO>> GetProducts()
        {
            return await _repository.GetProducts();
        }

    }
}
