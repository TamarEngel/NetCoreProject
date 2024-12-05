using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlaTicket.Core.models
{
    
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }

        [NotMapped]
        public List<int> ClientTicketList { get; set; }
        public bool ClientStatus { get; set; }
    }
}
