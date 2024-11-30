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
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public List<Client> GetList()
        {
            return _clientRepository.GetList();
        }
        public Client GetClientById(int id)
        {
            return _clientRepository.GetClientById(id);
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
