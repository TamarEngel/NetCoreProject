using GlaTicket.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core.Repositories
{
    public interface IClientRepository
    {
        List<Client> GetList();
        Client GetClientById(int id);
        int AddClient(int id, string name);
        int ChangeClient(int id, int eventCode);
        int DeleteClient(int id);
    }
}
