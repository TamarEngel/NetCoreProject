using GlaTicket.Core.interfaces;
using GlaTicket.Core.models;
using GlaTicket.Core.Repositories;
using Microsoft.EntityFrameworkCore;
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
        public List<Ticket> GetList()
        {
            return _context.TicketList.ToList();
        }
        public void AddTicketAndClient(Ticket t)
        {
            // בדיקה אם האירוע קיים ברשימת האירועים
            var existingEvent = _context.EventList.Include(p => p.EventTicketList).FirstOrDefault(c => c.EventCode == t.EventId);
            if (existingEvent == null || existingEvent.EventStatus==false)
                return; // אם האירוע לא קיים, יוצאים מהפונקציה
            existingEvent.EventTicketList.Add(t);//הוספת הכרטיס לרשימת הכרטיסים של הארוע הנוכחי
            // בדיקה אם הלקוח קיים ברשימת הלקוחות
            var client = _context.clientList.Include(p => p.ClientTicketList).FirstOrDefault(c => c.ClientId == t.ClientId);
            if (client != null && client.ClientStatus)//הוספת הכרטיס ללקוח קיים
            {
                client.ClientTicketList.Add(t);
                _context.TicketList.Add(t);
            }
            else
            {
                _context.clientList.Add(new Client
                {
                    ClientId = t.ClientId,
                    ClientName = t.ClientName,
                    ClientStatus = true,
                    ClientTicketList = new List<Ticket> { t }
                });
                _context.TicketList.Add(t);
            }
            _context.SaveChanges();
        }
    }
}
