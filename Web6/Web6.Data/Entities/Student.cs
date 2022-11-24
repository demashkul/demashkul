using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web6.Infra.Entity;

namespace Web6.Data.Entities
{
    public class Student : BaseEntity
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime DeletedOn { get; set; }

        public override string ToString()
        => $"{{ Id: {Id}, FirstName={FirstName}, LastName:{LastName} }}";
    }
}
