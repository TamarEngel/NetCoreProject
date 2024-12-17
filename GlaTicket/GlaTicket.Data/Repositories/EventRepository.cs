using GlaTicket.Core.interfaces;
using GlaTicket.Core.models;
using GlaTicket.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Data.Repositories
{
    public class EventRepository:IEventRepository
    {
        private readonly DataContext _context;
        public EventRepository(DataContext context)
        {
            _context = context;
        }

        public List<Event> GetList()
        {
            return _context.EventList.ToList();
        }
        public Event GetEventById(int id)
        {
            return _context.EventList.FirstOrDefault(e => e.EventCode == id && e.EventStatus == true);
        }
        public int AddEvent(Event e)
        {
            //var producer = _context.ProducerList.FirstOrDefault(p => p.ProducerId == e.EventProducerId);
            var producer = _context.ProducerList.Include(p => p.ProducerEventList).FirstOrDefault(p => p.ProducerId == e.ProducerId);

            if (producer == null)
                return -1;
            _context.EventList.Add(e);
            producer.ProducerEventList.Add(e);
            _context.SaveChanges();
            return 1;
        }
        public int ChangeEvent(int id,int EventPrice, DateTime EventDate)
        {
            var eventItem = _context.EventList.FirstOrDefault(ev => ev.EventCode == id);
            if (eventItem == null)
                return -1;
            eventItem.EventPrice = EventPrice;
            eventItem.EventDate = EventDate;
            _context.SaveChanges();
            return 1;
        }
        public int DeleteEvent(int id)
        {
            var eventItem = _context.EventList.FirstOrDefault(e => e.EventCode == id);
            if (eventItem == null)
            {
                return -1;
            }
            eventItem.EventStatus = false;
            _context.SaveChanges();
            return 1;
            //_context.ProducerList.FirstOrDefault(p => p.ProducerEventList.Contains(id)).ProducerEventList.Remove(id);
            //_context.clientList.FirstOrDefault(p => p.ClientTicketList.Contains(id)).ClientTicketList.Remove(id);
        }
    }
}
