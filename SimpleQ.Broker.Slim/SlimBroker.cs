using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleQ.Broker.Common;
using SimpleQ.Broker.Slim.DataAccess.DAL;
using SimpleQ.Interface.Models.Common;
using SimpleQ.Interface.Models.Publisher.Events;

namespace SimpleQ.Broker.Slim
{
    public class SlimBroker : IBroker
    {
        private readonly IMessageRepository _messageRepository;
        private IMediator _mediator;

        public SlimBroker(IMessageRepository messageRepository,IMediator mediator)
        {
            _messageRepository = messageRepository;
            _mediator = mediator;
        }

        public bool ContainsUnprocessedMessages() => _messageRepository.HasUnprocessedMessages();

        public Task<Message> Receive()
        {
            var result = _messageRepository.ReadMessage();
            _messageRepository.DeleteMessage(result);
            return Task.FromResult(result);
        }

        public Task Send(Message message)
        {
             _messageRepository.WriteMessage(message);
            _mediator.Publish(new UnprocessedMessageEvent());
            return Task.CompletedTask;
        }
    }
}
