using Domain.BoundedContexts.RoomContext.Interfaces;
using Domain.BoundedContexts.RoomContext.Models;
using Infrastructure.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ConfigurationContext _context;

        public RoomRepository(ConfigurationContext context)
        {
            _context = context;
        }

        public void Add(Room t)
        {
            _context.Set<Room>().Add(t);
            _context.SaveChanges();
        }

        public Room FindById(Guid id)
        {
            return _context.Set<Room>().FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Set<Room>().Where(t => !t.Deleted).ToList();
        }

        public void Remove(Guid id)
        {
            var t = FindById(id);
            _context.Set<Room>().Remove(t);
            _context.SaveChanges();
        }

        public void Update(Room t)
        {
            _context.Set<Room>().Update(t);
            _context.SaveChanges();
        }
    }
}