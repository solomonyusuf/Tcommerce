using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tcommerce.Domain.Common;

namespace Tcommerce.Domain.Entity
{
    public class Product : BaseEntity
    {
        [StringLength(225)]
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
    }
}
