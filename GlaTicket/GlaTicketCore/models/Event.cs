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
        public int EventProducerId { get; set; }

        //public Event(int id,string name, DateTime eventDate, int price,bool status,int pid)
        //{
        //    this.EventName = name;
        //    this.EventCode = id;
        //    this.EventDate = eventDate;
        //    this.EventPrice = price;
        //    this.EventStatus = status;
        //    this.EventProducerId = pid;
        //}

    }
}
