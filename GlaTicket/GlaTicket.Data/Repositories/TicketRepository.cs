using GlaTicket.Core.interfaces;
using GlaTicket.Core.models;
using GlaTicket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Data.Repositories
{
    public class TicketRepository:ITicketRepository
    {
        private readonly DataContext _context;
        public TicketRepository(DataContext context)
        {
            _context = context;
        }
        public void AddTicketAndClient(Ticket t)
        {
            // בדיקה אם האירוע קיים ברשימת האירועים
            var existingEvent = _context.EventList.FirstOrDefault(c => c.EventCode == t.EventCode);
            if (existingEvent == null)
                return; // אם האירוע לא קיים, יוצאים מהפונקציה

            // בדיקה אם הלקוח קיים ברשימת הלקוחות
            var client = _context.clientList.FirstOrDefault(c => c.ClientId == t.ClientId);
            if (client != null)//הוספת הכרטיס ללקוח קיים
            {
                client.ClientTicketList.Add(t.EventCode);
            }
            else
            {
                _context.clientList.Add(new Client
                {
                    ClientId = t.ClientId,
                    ClientName = t.ClientName,
                    ClientStatus = true,
                    ClientTicketList = new List<int> { t.EventCode }
                });
            }
        }
    }
}
