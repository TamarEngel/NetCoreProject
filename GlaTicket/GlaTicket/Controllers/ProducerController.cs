using GlaTicket.Core.models;
using GlaTicket.Core.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GlaTicket.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlaTicket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;
        public ProducerController(IProducerService datacontext)
        {
            _producerService = datacontext;
        }
        // GET: api/<ProducerController>
        [HttpGet]
        public ActionResult<IEnumerable<Producer>> Get()
        {
            return Ok(_producerService.GetList());
        }

        // GET api/<ProducerController>/5
        [HttpGet("{id}")]
        public ActionResult<Producer> Get(int id)
        {
            var producer = _producerService.GetProducerById(id);    
            if (producer == null)
            {
                return NotFound($"Producer with ID {id} not found or inactive.");
            }
            return Ok(producer);
        }

        // POST api/<ProducerController>
        [HttpPost]
        public void Post(int producerId,string producerName)
        {
            _producerService.AddProducer(producerId, producerName);
        }

        // PUT api/<ProducerController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] p)
        //{
            
        //}

        // DELETE api/<ProducerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var producer = _producerService.DeleteProducer(id);
            if (producer == null)
            {
                return NotFound($"Producer with ID {id} not found.");
            }
            return Ok($"Producer with ID {id} is now inactive.");
        }
    }
}
