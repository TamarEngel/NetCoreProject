using GlaTicket.Core.DTO;
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
        Task<List<Client>> GetAllClientAsync();
        Task<Client> GetClientByIdAsync(int id);
        Task<int> AddClientAsync(int id, string name);
        Task<int> ChangeClientAsync(int id, int eventCode);
        Task<int> DeleteClientAsync(int id);
    }
}
