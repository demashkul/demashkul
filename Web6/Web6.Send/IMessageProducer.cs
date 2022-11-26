using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web6.Common.Dtos;

namespace Web6.Send
{
    public interface IMessageProducer
    {
        void PublishToQue(MessageDto message);
        void PublishToExchange();
    }
}
