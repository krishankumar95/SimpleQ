using Microsoft.AspNetCore.Mvc;
using SimpleQ.Interface.Models.Common;
using SimpleQ.Interface.Publisher;

namespace SimpleQ.SimpleQ.Interface.Htttp
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleQHttpController : ControllerBase
    {
        private readonly IPublisher _publisher;

        public SimpleQHttpController(IPublisher publisher)
        {
            _publisher = publisher;
        }

        [HttpPost]
        public async Task PublishMessage(Message message)
        {
            await _publisher.PublishAsync(message);
        }


    }
}
