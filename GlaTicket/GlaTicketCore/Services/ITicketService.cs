﻿using GlaTicket.Core.DTO;
using GlaTicket.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core.Services
{
    public interface ITicketService
    {
        void AddTicketAndClient(TicketPostDTO t);
        public List<TicketGetDTO> GetList();

    }
}
