using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcommerce.Application.Dto;
using Tcommerce.Application.Interfaces;
using Tcommerce.Domain.Entity;

namespace Tcommerce.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProductResponseDto> CreateAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Price = dto.Price
            };

            await _repo.AddAsync(product);

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllAsync(int page, int pageSize, string filter = null)
        {
            var products = await _repo.GetAllAsync(page, pageSize, filter);

            return products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            });
        }
    }
}
