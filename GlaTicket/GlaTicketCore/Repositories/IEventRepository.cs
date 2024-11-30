using GlaTicket.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core.Repositories
{
    public interface IEventRepository
    {
        public List<Event> GetList();
        Event GetEventById(int id);
        int AddEvent(Event e);
        public int ChangeEvent(int id, Event e);
        public int DeleteEvent(int id);
    }
}
