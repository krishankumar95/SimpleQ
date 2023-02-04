using SimpleQ.Broker.Common;
using SimpleQ.Interface.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQ.Interface.Publisher
{
    public class SlimBrokerPublisher : IPublisher
    {
        private readonly IBroker _broker;

        public SlimBrokerPublisher(IBroker broker)
        {
            _broker = broker;
        }
        public async Task PublishAsync(Message message) => await _broker.Send(message);
    }
}
