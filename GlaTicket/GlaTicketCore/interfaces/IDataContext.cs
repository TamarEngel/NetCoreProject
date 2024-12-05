using GlaTicket.Core.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core.interfaces
{
    public interface IDataContext
    {
        public DbSet<Event> EventList { get; set; }
        public DbSet<Producer> ProducerList { get; set; }
        public DbSet<Client> clientList { get; set; }
    }
}
