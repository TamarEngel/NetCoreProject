using GlaTicket.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core.Services
{
    public interface IEventService
    {
        List<Event> GetAll();
        Event GetEventById(int id);
        int AddEvent(Event e);
        int ChangeEvent(int id,Event e);
        int DeleteEvent(int id);


    }
}
