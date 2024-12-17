using System.ComponentModel.DataAnnotations;

namespace GlaTicket.Core.models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public int EventCode { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public int EventPrice { get; set; }
        public bool EventStatus { get; set; }
        public int ProducerId { get; set; }
        //public Producer EventProducer { get; set; }
        public List<Ticket> EventTicketList { get; set; } = new List<Ticket>();

        //public Event(int Code, string Name, DateTime EventDate, int EventPrice, int EventProducerId)
        //{
        //    EventCode= Code;
        //    EventName= Name;
        //    this.EventPrice = EventPrice;
        //    this.EventProducerId = EventProducerId;
        //    this.EventStatus = true;
        //    this.EventDate = EventDate;
        //}
        

    }
}
