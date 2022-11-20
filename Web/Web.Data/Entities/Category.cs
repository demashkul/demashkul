using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Infra.Entity;

namespace Web.Data.Entities
{
    public class Category: BaseEntity
    {
        public string Name { get; set; }
    }
}
