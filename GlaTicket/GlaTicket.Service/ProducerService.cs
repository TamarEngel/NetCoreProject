using AutoMapper;
using GlaTicket.Core.DTO;
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
        private readonly IMapper _mapper;
        public ProducerService(IProducerRepository producerRepository, IMapper mapper)
        {
            _producerRepository = producerRepository;
            _mapper = mapper;
        }
        public List<ProducerGetDTO> GetList()
        {
            var list = _producerRepository.GetList(); ;
            var listDto = new List<ProducerGetDTO>();
            foreach (var producer in list)
            {
                listDto.Add(_mapper.Map<ProducerGetDTO>(producer));
            }
            return listDto;
        }
        public ProducerGetDTO GetProducerById(int id)
        {
            return _mapper.Map<ProducerGetDTO>(_producerRepository.GetProducerById(id));
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
