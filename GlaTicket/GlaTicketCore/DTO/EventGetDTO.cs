using GlaTicket.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core.DTO
{
    public class EventGetDTO
    {
        public int EventCode { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public int EventPrice { get; set; }
        public bool EventStatus { get; set; }
        public int ProducerId { get; set; }
        public List<TicketGetDTO> EventTicketList { get; set; } = new List<TicketGetDTO>();
    }
}
