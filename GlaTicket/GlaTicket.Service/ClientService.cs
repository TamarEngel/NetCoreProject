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
    public class ClientService:IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }
        public List<ClientGetDTO> GetList()
        {
            var list = _clientRepository.GetList();
            var listDto = new List<ClientGetDTO>();
            foreach(var client in list)
            {
                listDto.Add(_mapper.Map<ClientGetDTO>(client));
            }
            return listDto;
        }
        public ClientGetDTO GetClientById(int id)
        {
            return _mapper.Map<ClientGetDTO>(_clientRepository.GetClientById(id));
        }
        public int AddClient(int id, string name)
        {
            return _clientRepository.AddClient(id,name);
        }
        public int ChangeClient(int id, int eventCode)
        {
            return _clientRepository.ChangeClient(id, eventCode);
        }
        public int DeleteClient(int id)
        {
            return (_clientRepository.DeleteClient(id));
        }
    }
}
