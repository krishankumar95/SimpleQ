using Microsoft.EntityFrameworkCore;
using SimpleQ.Broker.Slim.DataAccess.DAO;
using SimpleQ.Interface.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleQ.Broker.Slim.DataAccess.DAL
{
    public class MessageRepository : IMessageRepository
    {
        private SlimBrokerDbContext _dbContext;
        public MessageRepository()
        {
            _dbContext = new SlimBrokerDbContext();
        }
        public Message ReadMessage()
        {
           return _dbContext.Messages.First();
        }

        public void WriteMessage(Message message)
        {
            _dbContext.Messages.Add(message);
            _dbContext.SaveChanges();
        }

        public void DeleteMessage(Message message)
        {
            _dbContext.Remove(message);
            _dbContext.SaveChanges();
        }

        public bool HasUnprocessedMessages() => _dbContext.Messages.ToList().Count != 0;
    }
}
