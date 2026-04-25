using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcommerce.Application.Dto;

namespace Tcommerce.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductResponseDto> CreateAsync(CreateProductDto dto);
        Task<IEnumerable<ProductResponseDto>> GetAllAsync(int page, int pageSize, string filter = null);
    }
}
