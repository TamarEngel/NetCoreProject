using GlaTicket.Core.DTO;
using GlaTicket.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core.Services
{
    public interface IClientService
    {
        List<ClientGetDTO> GetList();
        ClientGetDTO GetClientById(int id);
        int AddClient(int id, string name);
        int ChangeClient(int id, int eventCode);
        int DeleteClient(int id);
    }
}
