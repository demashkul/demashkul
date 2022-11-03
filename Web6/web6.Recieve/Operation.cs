using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web6.Common.Dtos;
using Web6.Data;
using Web6.Data.Entities;
using Web6.Plugin.Abstracts;

namespace web6.Recieve
{
    public class Operation
    {
        private readonly WebContext? webContext;
        private readonly IOpenApi openApi;
        public Operation(ServiceProvider serviceProvider)
        {
            this.webContext = serviceProvider.GetService<WebContext>();
            openApi = serviceProvider.GetService<IOpenApi>();
        }
        public bool Execute(MessageDto messageDto)
        {
            Console.WriteLine(" In Operation Method {0}", messageDto?.Title);

            openApi.CallService("");

            var message = new Message
            {
                Content = messageDto.Content,
            };
            webContext.Message.Add(message);
            webContext.SaveChanges();
            return true;

        }
    }
}
