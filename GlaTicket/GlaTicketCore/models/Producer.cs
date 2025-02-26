﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlaTicket.Core.models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
        public bool ProducerStatus { get; set; }
        public List<Event> ProducerEventList { get; set; } = new List<Event>();
    }
}



