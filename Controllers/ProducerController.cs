using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlaTicket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        // GET: api/<ProducerController>
        [HttpGet]
        public ActionResult<IEnumerable<Producer>> Get()
        {
            return Ok(Data.ProducerList);
        }

        // GET api/<ProducerController>/5
        [HttpGet("{id}")]
        public ActionResult<Producer> Get(int id)
        {
            var producer = Data.ProducerList.FirstOrDefault(p => p.ProducerId == id && p.ProducerStatus == true);
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
            Data.ProducerList.Add(new Producer() {ProducerId=producerId,ProducerName=producerName,ProducerStatus=true,ProducerEventList=new List<int>() });
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
            var producer = Data.ProducerList.FirstOrDefault(p => p.ProducerId == id);
            if (producer == null)
            {
                return NotFound($"Producer with ID {id} not found.");
            }

            producer.ProducerStatus = false;
            return Ok($"Producer with ID {id} is now inactive.");
        }
    }
}
