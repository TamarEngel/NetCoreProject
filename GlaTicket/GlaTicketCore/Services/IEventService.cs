using GlaTicket.Core.DTO;
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
        List<EventGetDTO> GetAll();
        EventGetDTO GetEventById(int id);
        int AddEvent(EventPostDTO e);
        int ChangeEvent(int id, int EventPrice, DateTime EventDate);
        int DeleteEvent(int id);


    }
}
