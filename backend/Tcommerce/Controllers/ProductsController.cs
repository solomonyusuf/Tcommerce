using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tcommerce.Application.Dto;
using Tcommerce.Application.Interfaces;

namespace Tcommerce.Controllers
{
    [ApiController]
    [Route("api/products")]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]int page = 1, [FromQuery]int pageSize = 20, [FromQuery]string filter = null)
        {
            return Ok(await _service.GetAllAsync(page, pageSize, filter));
        }
    }
}
