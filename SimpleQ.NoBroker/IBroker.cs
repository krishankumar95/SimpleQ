using SimpleQ.Interface.Models.Common;

namespace SimpleQ.Broker.Common
{
    public interface IBroker
    {
        public Task Send(Message message);
        public Task<Message> Receive();
        bool ContainsUnprocessedMessages();
    }
}
