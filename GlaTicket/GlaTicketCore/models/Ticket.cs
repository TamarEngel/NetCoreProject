using System.ComponentModel.DataAnnotations;

namespace GlaTicket.Core.models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public string ClientName { get; set; }
        public int ClientId { get; set; }
        public int EventCode { get; set; }
        public string EventName { get; set; }
    }
}
