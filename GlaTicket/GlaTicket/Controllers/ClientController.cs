using GlaTicket.Core.Services;
using GlaTicket.Core.models;
using GlaTicket.Core.interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult <IEnumerable<Client>> Get()
        {
            return Ok(_clientService.GetList());
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            var client =_clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound($"Client with ID {id} not found or inactive.");
            }
            return Ok(client);
        }

        //ההכנסה מתבצעת בהזמנת כרטיס
        // POST api/<ClientController>
        //[HttpPost]
        //public ActionResult Post([FromBody] Client newClient)
        //{
        //    if (newClient == null || clientList.Any(c => c.ClientId == newClient.ClientId))
        //    {
        //        return BadRequest("Invalid client data or client already exists.");
        //    }

        //    clientList.Add(newClient);
        //    return CreatedAtAction(nameof(Get), new { id = newClient.ClientId }, newClient);
        //}
        //}

        // PUT api/<ClientController>/53
        [HttpPut("{id}")]
        public ActionResult Put(int id,int eventCode)
        {
            //אפשרות לבטל הזמנה
            var success = _clientService.ChangeClient(id, eventCode);
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
        public ActionResult Delete(int id)
        {
            var success = _clientService.DeleteClient(id);
            if (success == -1)
            {
                return NotFound($"Client with ID {id} not found.");
            }
            return Ok($"Client {id} status set to inactive.");
        }
    }
}