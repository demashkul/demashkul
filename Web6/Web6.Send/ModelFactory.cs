using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Web6.Send
{
    public class ModelFactory
    {
        public IModel CreateChannel()
        {
            ConnectionFactory factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "123456"
            };


            IConnection connection = factory.CreateConnection();
            return connection.CreateModel();
        }
    }
}
