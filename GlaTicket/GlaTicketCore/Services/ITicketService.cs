using GlaTicket.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core.Services
{
    public interface ITicketService
    {
        void AddTicketAndClient(Ticket t);
        public List<Ticket> GetList();

    }
}
