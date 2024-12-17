using GlaTicket.Core.interfaces;
using GlaTicket.Core.models;
using GlaTicket.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Data.Repositories
{
    
    public class ClientRepository:IClientRepository
    {
        private readonly DataContext _context;
        public ClientRepository(DataContext context)
        {
            _context = context;
        }
        public List<Client> GetList()
        {
            return _context.clientList.ToList();
        }
        public Client GetClientById(int id)
        {
            return _context.clientList.FirstOrDefault(c => c.ClientId == id && c.ClientStatus == true);
        }
        public int AddClient(int id, string name)
        {
            if (_context.clientList.Any(c => c.ClientId ==id))
                return -1;
            _context.clientList.Add(new Client() { ClientId = id, ClientName = name, ClientTicketList = new List<Ticket>(), ClientStatus = true });
            _context.SaveChanges();
            return 1;
        }

        public int ChangeClient(int id,int eventCode)
        {
            //אפשרות לבטל הזמנה/כרטיס
            var client = _context.clientList.Include(p => p.ClientTicketList).FirstOrDefault(c => c.ClientId == id);
            var ticketEvent = _context.TicketList.FirstOrDefault(t => t.EventId == eventCode);
            var event1 = _context.EventList.Include(p => p.EventTicketList).FirstOrDefault(e => e.EventCode == eventCode);
            if (client == null)
                return -1;
            if (client.ClientTicketList.Contains(ticketEvent))
            {
                client.ClientTicketList.Remove(ticketEvent);//הסרת הכרטיס מרשימת הכרטיסים של הקליינט
                event1.EventTicketList.Remove(ticketEvent);//הסרת הכרטיס מרשימת הכרטיסים של הארוע
                _context.SaveChanges();
                return 1;
            }
            return 0;
        }
        public int DeleteClient(int id)
        {
            var client = _context.clientList.FirstOrDefault(c => c.ClientId == id);
            if (client == null)
                return -1;
            client.ClientStatus = false;
            _context.SaveChanges();
            return 1;
        }
    }
}
