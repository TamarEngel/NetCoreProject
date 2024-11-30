﻿using GlaTicket.Core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Core.Services
{
    public interface IProducerService
    {
        List<Producer> GetList();
        Producer GetProducerById(int id);
        void AddProducer(int producerId, string producerName);
        int DeleteProducer(int id);
    }
}