using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQ.Interface.Relayer
{
    /// <summary>
    /// Consumes the Message from the Broker and relays it to the Target Client
    /// </summary>
    public interface IRelayer
    {
        Task ConsumeAndRelayAsync(string consumerName);
    }
}
