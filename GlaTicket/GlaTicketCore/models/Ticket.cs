using System.ComponentModel.DataAnnotations;

namespace GlaTicket.Core.models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public string ClientName { get; set; }
        public int ClientId { get; set; }
        //public Client Client { get; set; }
        public int EventId { get; set; }
        //public Event Event { get; set; }
        public string EventName { get; set; }
    }
}
