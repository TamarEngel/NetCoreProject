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
        Task<List<ClientGetDTO>> GetAllClientAsync();
        Task<ClientGetDTO> GetClientByIdAsync(int id);
        Task<int> AddClientAsync(int id, string name);
        Task<int> ChangeClientAsync(int id, int eventCode);
        Task<int> DeleteClientAsync(int id);
    }
}


