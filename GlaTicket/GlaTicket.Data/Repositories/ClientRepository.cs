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
        public async Task<List<Client>> GetAllClientAsync()
        {
            return await _context.clientList.Include(p => p.ClientTicketList).ToListAsync();
        }
        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _context.clientList.Include(p => p.ClientTicketList).FirstOrDefaultAsync(c => c.ClientId == id && c.ClientStatus == true);
        }
        public async Task<int> AddClientAsync(int id, string name)
        {
            if (await _context.clientList.AnyAsync(c => c.ClientId ==id))
                return -1;
            _context.clientList.Add(new Client() { ClientId = id, ClientName = name, ClientTicketList = new List<Ticket>(), ClientStatus = true });
            _context.SaveChanges();
            return 1;
        }

        public async Task<int>ChangeClientAsync(int id,int eventCode)
        {
            //אפשרות לבטל הזמנה/כרטיס
            var client = await _context.clientList.Include(p => p.ClientTicketList).FirstOrDefaultAsync(c => c.ClientId == id);
            var ticketEvent = await _context.TicketList.FirstOrDefaultAsync(t => t.EventId == eventCode);
            var event1 = await _context.EventList.Include(p => p.EventTicketList).FirstOrDefaultAsync(e => e.EventCode == eventCode);
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
        public async Task<int> DeleteClientAsync(int id)
        {
            var client = await _context.clientList.FirstOrDefaultAsync(c => c.ClientId == id);
            if (client == null)
                return -1;
            client.ClientStatus = false;
            _context.SaveChanges();
            return 1;
        }
    }
}
