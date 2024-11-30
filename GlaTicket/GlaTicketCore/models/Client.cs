namespace GlaTicket.Core.models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public List<int> ClientTicketList { get; set; }
        public bool ClientStatus { get; set; }
    }
}
