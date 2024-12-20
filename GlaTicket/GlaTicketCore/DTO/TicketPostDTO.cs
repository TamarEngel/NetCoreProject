using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core.DTO
{
    public class TicketPostDTO
    {
        public string ClientName { get; set; }
        public int ClientId { get; set; }
        public int EventId { get; set; }
        public string EventName { get; set; }
    }
}
