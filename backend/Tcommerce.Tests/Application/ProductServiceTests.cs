using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcommerce.Application.Dto;
using Tcommerce.Application.Interfaces;
using Tcommerce.Application.Services;
using Tcommerce.Domain.Entity;
using Xunit;

namespace Tcommerce.Tests.Application
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _repoMock;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _repoMock = new Mock<IProductRepository>();
            _service = new ProductService(_repoMock.Object);
        }

        [Fact]
        public async Task CreateProduct_Should_Return_ProductResponse()
        {
            var dto = new CreateProductDto
            {
                Name = "Laptop",
                Price = 1500,
                Color = "red"
            };

            _repoMock
                .Setup(r => r.AddAsync(It.IsAny<Product>()))
                .Returns(Task.CompletedTask);

            var result = await _service.CreateAsync(dto);

            Assert.NotNull(result);
            Assert.Equal("Laptop", result.Name);
            Assert.Equal(1500, result.Price);
            Assert.Equal("red", result.Color);
        }

        [Fact]
        public async Task GetAll_Should_Filter_By_Color()
        {
            var products = new List<Product>
            {
                new Product { Name = "Phone", Price = 4000, Color = "Black" },
                new Product { Name = "Laptop",Price = 4000, Color = "Silver" }
            };

           _repoMock.Setup(r => r.GetAllAsync(1, 10, "Black"))
                     .ReturnsAsync(products);

            var result = await _service.GetAllAsync(1, 10, "Black");

            Assert.Single(result);
        }
    }
}
