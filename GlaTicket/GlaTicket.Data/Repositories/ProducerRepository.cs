using GlaTicket.Core.interfaces;
using GlaTicket.Core.models;
using GlaTicket.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlaTicket.Data.Repositories
{
    public class ProducerRepository:IProducerRepository
    {
        private readonly DataContext _context;
        public ProducerRepository(DataContext context)
        {
            _context = context;
        }
        public List<Producer> GetList()
        {
            return _context.ProducerList.Include(p => p.ProducerEventList).ToList();
        }
        public Producer GetProducerById(int id)
        {
            return _context.ProducerList.Include(p => p.ProducerEventList).FirstOrDefault(p => p.ProducerId == id && p.ProducerStatus == true);
        }
        public void AddProducer(int producerId, string producerName)
        {
            _context.ProducerList.Add(new Producer() { ProducerId = producerId, ProducerName = producerName, ProducerStatus = true, ProducerEventList = new List<Event>() });
            _context.SaveChanges();
        }
        public int DeleteProducer(int id)
        {
            var producerItem = _context.ProducerList.FirstOrDefault(e => e.ProducerId == id);
            if (producerItem == null)
            {
                return -1;
            }
            producerItem.ProducerStatus = false;
            _context.SaveChanges();
            return 1;
        }

    }
}
