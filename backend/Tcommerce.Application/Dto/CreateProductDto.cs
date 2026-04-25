using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcommerce.Application.Dto
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Color { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
