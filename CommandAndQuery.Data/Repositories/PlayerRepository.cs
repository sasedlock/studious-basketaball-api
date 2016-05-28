﻿using System.Collections.Generic;
using System.Data.Entity;
using CommandAndQuery.Domain.Models;

namespace CommandAndQuery.Data.Repositories
{
    public class PlayerRepository : IRepository<Player>
    {
        private readonly BasketballContext _context;

        public PlayerRepository()
        {
            _context = new BasketballContext();
        }

        public IEnumerable<Player> GetAll()
        {
            return _context.Players;
        }

        public Player GetById(int id)
        {
            return _context.Players.Find(id);
        }

        public void Add(Player model)
        {
            _context.Players.Add(model);
        }

        public void Edit(Player model)
        {
            _context.Players.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}