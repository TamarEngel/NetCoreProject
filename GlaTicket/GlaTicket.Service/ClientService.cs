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
        public async Task<List<ClientGetDTO>> GetAllClientAsync()
        {
            var list = await _clientRepository.GetAllClientAsync();
            var listDto = new List<ClientGetDTO>();
            foreach(var client in list)
            {
                listDto.Add(_mapper.Map<ClientGetDTO>(client));
            }
            return listDto;
        }
        public async Task<ClientGetDTO> GetClientByIdAsync(int id)
        {
            return _mapper.Map<ClientGetDTO>(await _clientRepository.GetClientByIdAsync(id));
        }
        public async Task<int> AddClientAsync(int id, string name)
        {
            return await _clientRepository.AddClientAsync(id,name);
        }
        public async Task<int> ChangeClientAsync(int id, int eventCode)
        {
            return await _clientRepository.ChangeClientAsync(id, eventCode);
        }
        public async Task<int> DeleteClientAsync(int id)
        {
            return (await _clientRepository.DeleteClientAsync(id));
        }
    }
}
