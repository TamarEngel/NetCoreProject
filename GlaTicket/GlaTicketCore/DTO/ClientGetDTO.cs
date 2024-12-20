using GlaTicket.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core.DTO
{
    public class ClientGetDTO
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public List<TicketGetDTO> ClientTicketList { get; set; } = new List<TicketGetDTO>();
        public bool ClientStatus { get; set; }
    }
}
