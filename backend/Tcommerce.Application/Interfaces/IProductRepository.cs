using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcommerce.Domain.Entity;

namespace Tcommerce.Application.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<IEnumerable<Product>> GetAllAsync(int page, int pageSize, string filter = null);
    }
}
