namespace GlaTicketCore.classes
{
    public class Event
    {
        public int EventCode { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public int EventPrice { get; set; }
        public bool EventStatus { get; set; }
        public int EventProducerId { get; set; }

        public Event(int id,string name,int price,bool status,int pid)
        {
            this.EventName = name;
            this.EventCode = id;
            this.EventPrice = price;
            this.EventStatus = status;
            this.EventProducerId = pid;
        }

    }
}
