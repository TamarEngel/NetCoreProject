using GlaTicket.Core.models;
using GlaTicket.Core.interfaces;
using Microsoft.AspNetCore.Mvc;
using GlaTicket.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlaTicket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService datacontext)
        {
            _ticketService = datacontext;
        }
       
        [HttpPost]
        public void Post([FromBody] Ticket t)
        {
            _ticketService.AddTicketAndClient(t);
        }

    }
}
