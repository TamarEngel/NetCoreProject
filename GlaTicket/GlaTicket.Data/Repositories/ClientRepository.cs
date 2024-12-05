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
        public int ChangeClient(int id,int eventCode)
        {
            //אפשרות לבטל הזמנה
            var client = _context.clientList.FirstOrDefault(c => c.ClientId == id);
            if (client == null)
                return -1;
            if (client.ClientTicketList.Contains(eventCode))
            {
                client.ClientTicketList.Remove(eventCode);
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
