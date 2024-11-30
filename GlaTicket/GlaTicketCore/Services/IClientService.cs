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
        List<Client> GetList();
        Client GetClientById(int id);
        int ChangeClient(int id, int eventCode);
        int DeleteClient(int id);
    }
}
