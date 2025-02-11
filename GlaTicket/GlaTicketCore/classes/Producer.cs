namespace GlaTicketCore.classes
{
    public class Producer
    {
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
        public bool ProducerStatus { get; set; }
        public List<int> ProducerEventList { get; set; }
    }
}
