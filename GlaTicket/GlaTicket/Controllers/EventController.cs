using GlaTicketCore.classes;
using GlaTicketCore.interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlaTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        static IDataContext _datacontext;
        public EventController(IDataContext datacontext)
        {
            _datacontext = datacontext;
        }
        // GET: api/<EventController>
        [HttpGet]
        public ActionResult<IEnumerable<Event>> Get()
        {
            return Ok(_datacontext.EventList);
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            var eventItem = _datacontext.EventList.FirstOrDefault(e => e.EventCode == id && e.EventStatus == true);
            if (eventItem == null)
            {
                return NotFound($"Event with ID {id} not found or inactive.");
            }
            return Ok(eventItem);
        }

        // POST api/<EventController>
        [HttpPost]
        public ActionResult Post([FromBody] Event e)
        {
            if (e == null)
            {
                return BadRequest("Event data is missing.");
            }

            // בדיקה אם המפיק קיים
            var producer = _datacontext.ProducerList.FirstOrDefault(p => p.ProducerId == e.EventProducerId);
            if (producer == null)
            {
                return NotFound($"Producer with ID {e.EventProducerId} not found.");
            }

            _datacontext.EventList.Add(e);
            producer.ProducerEventList.Add(e.EventCode);
            return Ok($"Add {e} successfully.");
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Event e)
        {
            var eventItem = _datacontext.EventList.FirstOrDefault(ev => ev.EventCode == id);
            if (eventItem == null)
            {
                return NotFound($"Event with ID {id} not found.");
            }

            eventItem.EventPrice = e.EventPrice;
            eventItem.EventDate = e.EventDate;

            return Ok($"Event with ID {id} updated successfully.");
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var eventItem = _datacontext.EventList.FirstOrDefault(e => e.EventCode == id);
            if (eventItem == null)
            {
                return NotFound($"Event with ID {id} not found.");
            }

            eventItem.EventStatus = false;
            return Ok($"Event with ID {id} is now inactive .");
            //Data.ProducerList.FirstOrDefault(p => p.ProducerEventList.Contains(id)).ProducerEventList.Remove(id);
            //Data.clientList.FirstOrDefault(p => p.ClientTicketList.Contains(id)).ClientTicketList.Remove(id);
        }
    }
}
