using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ww.Plugin
{
    public interface IOpClient
    {
        public string SendMessage(string message);
    }
}
