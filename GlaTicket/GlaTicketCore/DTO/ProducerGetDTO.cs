using GlaTicket.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core.DTO
{
    public class ProducerGetDTO
    {
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
        public bool ProducerStatus { get; set; }
        public List<EventGetOListDTO> ProducerEventList { get; set; } = new List<EventGetOListDTO>();
    }
}
