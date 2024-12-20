using GlaTicket.Core.models;
using GlaTicket.Core.interfaces;
using Microsoft.AspNetCore.Mvc;
using GlaTicket.Core.Services;
using Microsoft.EntityFrameworkCore;
using GlaTicket.Core.DTO;

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
        public void Post(TicketPostDTO t)
        {
            _ticketService.AddTicketAndClient(t);
        }
        [HttpGet]
        public IActionResult Get()
        {
            var tickets = _ticketService.GetList() ;
            return Ok(tickets);
        }

    }
}
