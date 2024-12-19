using AutoMapper;
using GlaTicket.Core.DTO;
using GlaTicket.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Client,ClientGetDTO>().ReverseMap();
            CreateMap<Event,EventGetDTO>().ReverseMap();
            CreateMap<Event,EventPostDTO>().ReverseMap();
            CreateMap<Event, EventGetOListDTO>().ReverseMap();
            CreateMap<Producer,ProducerGetDTO>().ReverseMap();
            CreateMap<Ticket, TicketGetDTO>().ReverseMap();
            CreateMap<Ticket, TicketPostDTO>().ReverseMap();
        }
    }
}
