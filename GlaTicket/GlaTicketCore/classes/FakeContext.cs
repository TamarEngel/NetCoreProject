using GlaTicketCore.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicketCore.classes
{
    public class FakeContext:IDataContext
    {
        public List<Event> EventList { get; set; }
        public List<Producer> ProducerList { get; set; }
        public List<Client> clientList { get; set; }

        public FakeContext()
        {
            EventList = new List<Event>() { new Event(0, "tamar", 50, true, 85) };
            ProducerList = new List<Producer>();
            clientList = new List<Client>();
        }
    }
}
