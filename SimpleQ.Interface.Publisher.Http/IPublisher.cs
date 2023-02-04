using SimpleQ.Interface.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQ.Interface.Publisher
{
    /// <summary>
    /// Consumes the message from the REST Interface and Publishes it to the Broker
    /// </summary>
    public interface IPublisher
    {
        Task PublishAsync(Message message);
    }
}
