using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tcommerce.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTimeOffset? Created { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? Updated { get; set; } = DateTimeOffset.UtcNow;
    }
}
