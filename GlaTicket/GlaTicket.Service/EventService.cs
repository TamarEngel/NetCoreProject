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
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public List<Event> GetAll()
        {
            return _eventRepository.GetList();
        }
        public Event GetEventById(int id)
        {
            return _eventRepository.GetEventById(id);
        }
        public int AddEvent(Event e)
        {
            return _eventRepository.AddEvent(e);
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
