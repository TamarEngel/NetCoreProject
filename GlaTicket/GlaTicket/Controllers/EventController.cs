using GlaTicket.Core.models;
using GlaTicket.Core.interfaces;
using Microsoft.AspNetCore.Mvc;
using GlaTicket.Service;
using GlaTicket.Core.Services;
using GlaTicket.Core.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlaTicket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService datacontext)
        {
            _eventService = datacontext;
        }
        // GET: api/<EventController>
        [HttpGet]
        public ActionResult<IEnumerable<EventGetDTO>> Get()
        {
            return Ok(_eventService.GetAll());
        }

        // GET api/<EventController>/5
        [HttpGet("{id}")]
        public ActionResult<EventGetDTO> Get(int id)
        {
            var eventItem = _eventService.GetEventById(id);
            if (eventItem == null)
            {
                return NotFound($"Event with ID {id} not found or inactive.");
            }
            return Ok(eventItem);
        }

        // POST api/<EventController>
        [HttpPost]
        public ActionResult Post(EventPostDTO e)
        {
            if (e == null)
            {
                return BadRequest("Event data is missing.");
            }
            var success= _eventService.AddEvent(e);
            if (success==-1)
            {
                return NotFound($"Producer with ID {e.ProducerId} not found.");
            }
            return Ok($"Add {e} successfully.");
        }

        // PUT api/<EventController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, int EventPrice, DateTime EventDate)
        {
            var success = _eventService.ChangeEvent(id, EventPrice, EventDate);
            if (success == -1)
            {
                return NotFound($"Event with ID {id} not found.");
            }
            return Ok($"Event with ID {id} updated successfully.");
        }

        // DELETE api/<EventController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var success = _eventService.DeleteEvent(id);
            if (success == -1)
            {
                return NotFound($"Event with ID {id} not found.");
            }
            return Ok($"Event with ID {id} is now inactive .");
        }
    }
}
