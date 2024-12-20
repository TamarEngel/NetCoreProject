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
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        private readonly IMapper _mapper;
        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public List<EventGetDTO> GetAll()
        {
            var list = _eventRepository.GetList();
            var listDto = new List<EventGetDTO>();
            foreach (var event1 in list)
            {
                listDto.Add(_mapper.Map<EventGetDTO>(event1));
            }
            return listDto;
        }
        public EventGetDTO GetEventById(int id)
        {
            return _mapper.Map<EventGetDTO>(_eventRepository.GetEventById(id));
        }
        public int AddEvent(EventPostDTO e)
        {
            var eventDto = _mapper.Map<Event>(e);
            return _eventRepository.AddEvent(eventDto);
        }
        public int ChangeEvent(int id, int EventPrice, DateTime EventDate)
        {
            return (_eventRepository.ChangeEvent(id, EventPrice, EventDate));   
        }
        public int DeleteEvent(int id)
        {
            return _eventRepository.DeleteEvent(id);
        }
    }
}
