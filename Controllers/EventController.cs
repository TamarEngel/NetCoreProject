using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlaTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        static public List<Event> EventList = new List<Event>();
        // GET: api/<EventController>
        [HttpGet]
        public ActionResult<IEnumerable<Event>> Get()
        {
            return Ok(EventList);
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public ActionResult<Event> Get(int id)
        {
            var eventItem = EventList.FirstOrDefault(e => e.EventCode == id && e.EventStatus == true);
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
            var producer = ProducerController.ProducerList.FirstOrDefault(p => p.ProducerId == e.EventProducerId);
            if (producer == null)
            {
                return NotFound($"Producer with ID {e.EventProducerId} not found.");
            }

            EventList.Add(e);
            producer.ProducerEventList.Add(e.EventCode);
            return Ok($"Add {e} successfully.");
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Event e)
        {
            var eventItem = EventList.FirstOrDefault(ev => ev.EventCode == id);
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
            var eventItem = EventList.FirstOrDefault(e => e.EventCode == id);
            if (eventItem == null)
            {
                return NotFound($"Event with ID {id} not found.");
            }

            eventItem.EventStatus = false;
            return Ok($"Event with ID {id} is now inactive .");
            //ProducerController.ProducerList.FirstOrDefault(p => p.ProducerEventList.Contains(id)).ProducerEventList.Remove(id);
            //ClientController.clientList.FirstOrDefault(p => p.ClientTicketList.Contains(id)).ClientTicketList.Remove(id);
        }
    }
}
