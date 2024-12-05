
using GlaTicket.Core.interfaces;
using GlaTicket.Core.models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GlaTicket.Data
{
    public class DataContext: DbContext, IDataContext
    {
        public DbSet<Event> EventList { get; set; }
        public DbSet<Producer> ProducerList { get; set; }
        public DbSet<Client> clientList { get; set; }
        public DbSet<Ticket> TicketList { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=sample_db");
        }

    }
}
