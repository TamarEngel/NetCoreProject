using GlaTicket.Core.models;
using GlaTicket.Core.Repositories;
using GlaTicket.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Service
{
    public class ProducerService:IProducerService
    {
        private readonly IProducerRepository _producerRepository;
        public ProducerService(IProducerRepository producerRepository)
        {
            _producerRepository = producerRepository;
        }
        public List<Producer> GetList()
        {
            return _producerRepository.GetList();
        }
        public Producer GetProducerById(int id)
        {
            return _producerRepository.GetProducerById(id);
        }
        public void AddProducer(int producerId, string producerName)
        {
            _producerRepository.AddProducer(producerId, producerName);
        }
        public int DeleteProducer(int id)
        {
            return (_producerRepository.DeleteProducer(id));
        }
    }
}
