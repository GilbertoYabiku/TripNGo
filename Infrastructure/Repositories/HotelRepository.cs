using Domain.BoundedContexts.RoomContext.Interfaces;
using Domain.BoundedContexts.RoomContext.Models;
using Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ConfigurationContext _context;

        public HotelRepository(ConfigurationContext context)
        {
            _context = context;
        }

        public void Add(Hotel t)
        {
            _context.Set<Hotel>().Add(t);
            _context.SaveChanges();
        }

        public Hotel FindById(Guid id)
        {
            return _context.Set<Hotel>().FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _context.Set<Hotel>().Where(t => !t.Deleted).ToList();
        }

        public void Remove(Guid id)
        {
            var t = FindById(id);
            _context.Set<Hotel>().Remove(t);
            _context.SaveChanges();
        }

        public void Update(Hotel t)
        {
            _context.Set<Hotel>().Update(t);
            _context.SaveChanges();
        }
    }
}