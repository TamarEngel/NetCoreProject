using System.ComponentModel.DataAnnotations;

namespace GlaTicket.Core.models
{
    public class ClientTicket
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int TicketId { get; set; }
    }
}
