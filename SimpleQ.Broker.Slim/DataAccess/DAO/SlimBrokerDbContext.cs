using Microsoft.EntityFrameworkCore;
using SimpleQ.Interface.Models.Common;

namespace SimpleQ.Broker.Slim.DataAccess.DAO
{
    public class SlimBrokerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "MessagesDB");
        }
        public DbSet<Message> Messages { get; set; }
    }
}
