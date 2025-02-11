using GlaTicket.Core.Services;
using GlaTicket.Core.models;
using GlaTicket.Core.interfaces;
using Microsoft.AspNetCore.Mvc;
using GlaTicket.Core.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlaTicket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService datacontext)
        {
            _clientService = datacontext;
        }
        // GET: api/<ClientController>
        [HttpGet]
        public async Task<ActionResult <IEnumerable<ClientGetDTO>>> GetAllClientAsync()
        {
            var list = await _clientService.GetAllClientAsync();
            if (list is null)
                return NotFound("empty list");
            return Ok(list);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientGetDTO>> GetClientByIdAsync(int id)
        {
            var client =await _clientService.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound($"Client with ID {id} not found or inactive.");
            }
            return Ok(client);
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult> Post(int id, string name)
        {
            if (await _clientService.AddClientAsync(id,name) ==-1)
            {
                return BadRequest("Invalid client data or client already exists.");
            }
            return Ok($"Add client successfully.");
        }
    

    // PUT api/<ClientController>/53
    [HttpPut("{id}")]
        public async Task<ActionResult> ChangeClientAsync(int id,int eventCode)
        {
            //אפשרות לבטל הזמנה
            var success = await _clientService.ChangeClientAsync(id, eventCode);
            if (success == -1)
                return NotFound($"Client with ID {id} not found.");
            else if (success == 0)
            {
                return BadRequest($"Event code {eventCode} not found in client {id} ticket list.");
            }
            return Ok($"Event code {eventCode} removed from client {id} ticket list.");
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClientAsync(int id)
        {
            var success = await _clientService.DeleteClientAsync(id);
            if (success == -1)
            {
                return NotFound($"Client with ID {id} not found.");
            }
            return Ok($"Client {id} status set to inactive.");
        }
    }
}