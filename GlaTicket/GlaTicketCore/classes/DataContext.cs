using GlaTicketCore.interfaces;

namespace GlaTicketCore.classes
{
    public class DataContext:IDataContext
    {
        public  List<Event> EventList { get; set; }
        public  List<Producer> ProducerList { get; set; }
        public  List<Client> clientList { get; set; }

        public DataContext()
        {
            EventList= new List<Event>();
            ProducerList= new List<Producer>();
            clientList = new List<Client>();
        }

    }
}
