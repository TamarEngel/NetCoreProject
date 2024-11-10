using GlaTicketCore.classes;
using GlaTicketCore.interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlaTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        static IDataContext _datacontext;
        public ClientController(IDataContext datacontext)
        {
            _datacontext = datacontext;
        }
        // GET: api/<ClientController>
        [HttpGet]
        public ActionResult <IEnumerable<Client>> Get()
        {
            return Ok(_datacontext.clientList);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ActionResult<Client> Get(int id)
        {
            var client = _datacontext.clientList.FirstOrDefault(c => c.ClientId == id && c.ClientStatus == true);
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
            var client = _datacontext.clientList.FirstOrDefault(c => c.ClientId == id);
            if (client == null)
            {
                return NotFound($"Client with ID {id} not found.");
            }

            if (client.ClientTicketList.Contains(eventCode))
            {
                client.ClientTicketList.Remove(eventCode);
                return Ok($"Event code {eventCode} removed from client {id} ticket list.");
            }
            return BadRequest($"Event code {eventCode} not found in client {id} ticket list.");
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var client = _datacontext.clientList.FirstOrDefault(c => c.ClientId == id);
            if (client == null)
            {
                return NotFound($"Client with ID {id} not found.");
            }

            client.ClientStatus = false;
            return Ok($"Client {id} status set to inactive.");
        }
    }
}