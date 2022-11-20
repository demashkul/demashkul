using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Common.Dtos.Product
{
    public class ProductSaveDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
