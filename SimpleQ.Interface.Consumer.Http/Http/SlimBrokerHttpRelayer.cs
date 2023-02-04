using MediatR;
using SimpleQ.Broker.Common;
using SimpleQ.Interface.Models.Publisher.Events;
using System.Net.Http.Json;

namespace SimpleQ.Interface.Relayer.Http
{
    public class SlimBrokerHttpRelayer : IRelayer, INotificationHandler<UnprocessedMessageEvent>
    {
        private readonly HttpClient _client;
        private readonly IBroker _broker;
        public SlimBrokerHttpRelayer(IBroker broker)
        {
            _broker = broker;
            _client = new HttpClient();
        }


        public async Task ConsumeAndRelayAsync(string consumerName)
        {
            var msg = await _broker.Receive();

            if (msg.ContentType != "JSON")
            {
                throw new NotImplementedException();
            }

            if (msg.DestinationHttpMethod != "POST")
            {
                throw new NotImplementedException();
            }
            
            _client.BaseAddress = new Uri(msg.DestinationBaseAddress);

            var result = await _client.PostAsJsonAsync(msg.DestinationHttpUri, msg.Content);

            await Task.CompletedTask;
        }

        public async Task Handle(UnprocessedMessageEvent notification, CancellationToken cancellationToken)
        {
            if (_broker.ContainsUnprocessedMessages())
            {
                await ConsumeAndRelayAsync("Default");
            }
        }
    }
}
