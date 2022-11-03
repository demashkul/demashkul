using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web6.Common.Enums;

namespace Web6.Common.Dtos
{
    public class MessageDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Via { get; set; }
        public Vias Vias { get; set; }
    }
}
