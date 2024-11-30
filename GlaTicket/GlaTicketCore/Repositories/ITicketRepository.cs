using GlaTicket.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core.Repositories
{
    public interface ITicketRepository
    {
        void AddTicketAndClient(Ticket t);
    }
}
