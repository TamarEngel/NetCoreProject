using AutoMapper;
using GlaTicket.Core.DTO;
using GlaTicket.Core.models;
using GlaTicket.Core.Repositories;
using GlaTicket.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Service
{
    public class TicketService:ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;
        public TicketService(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }
        public void AddTicketAndClient(TicketPostDTO t)
        {
            _ticketRepository.AddTicketAndClient(_mapper.Map<Ticket>(t));
        }
        public List<TicketGetDTO> GetList()
        {
            var list = _ticketRepository.GetList();
            var listDto = new List<TicketGetDTO>();
            foreach (var t in list)
            {
                listDto.Add(_mapper.Map<TicketGetDTO>(t));
            }
            return listDto;
        }
    }
}
