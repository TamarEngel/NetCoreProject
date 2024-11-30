using GlaTicket.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core.interfaces
{
    public interface IDataContext
    {
        public  List<Event> EventList { get; set; }
        public  List<Producer> ProducerList { get; set; }
        public  List<Client> clientList { get; set; }
    }
}
