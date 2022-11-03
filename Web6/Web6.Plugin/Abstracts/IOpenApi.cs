using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web6.Plugin.Abstracts
{
    public interface IOpenApi
    {
        Task CallServiceAsync(string token);
        bool CallService(string token);
    }
}
