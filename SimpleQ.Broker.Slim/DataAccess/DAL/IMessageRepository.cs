using SimpleQ.Interface.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQ.Broker.Slim.DataAccess.DAL
{
    public interface IMessageRepository
    {
        public Message ReadMessage();
        public void WriteMessage(Message message);
        public void DeleteMessage(Message message);
        public bool HasUnprocessedMessages();


    }
}
