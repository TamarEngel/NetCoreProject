using GlaTicket.Core.DTO;
using GlaTicket.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core.Services
{
    public interface IProducerService
    {
        List<ProducerGetDTO> GetList();
        ProducerGetDTO GetProducerById(int id);
        void AddProducer(int producerId, string producerName);
        int DeleteProducer(int id);
    }
}
