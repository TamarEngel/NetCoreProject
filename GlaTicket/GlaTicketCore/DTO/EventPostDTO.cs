using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core.DTO
{
    public class EventPostDTO
    {
        public int EventCode { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public int EventPrice { get; set; }
        public int ProducerId { get; set; }
    }
}
