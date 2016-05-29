using System.Collections.Generic;
using System.Data.Entity;
using CommandAndQuery.Domain.Models;
using MediatR;

namespace CommandAndQuery.Data.Repositories
{
    public class BasketballTeamRepository : IRepository<BasketballTeam>
    {
        private readonly BasketballContext _context;

        public BasketballTeamRepository()
        {
            _context = new BasketballContext();
        }

        public IEnumerable<BasketballTeam> GetAll()
        {
            return _context.Teams;
        }

        public BasketballTeam GetById(int id)
        {
            return _context.Teams.Find(id);
        }

        public void Add(BasketballTeam model)
        {
            _context.Teams.Add(model);
        }

        public void Edit(BasketballTeam model)
        {
            _context.Teams.Attach(model);
            _context.Entry(model).State = EntityState.Modified;
        }

        public Unit Delete(BasketballTeam model)
        {
            _context.Teams.Attach(model);
            _context.Entry(model).State = EntityState.Deleted;

            return new Unit();
        }

        public BasketballTeam AddPlayerToTeam(int basketballTeamId, int playerId)
        {
            var teamToAddPlayerTo = _context.Teams.Find(basketballTeamId);
            var playerToAddToTeam = _context.Players.Find(playerId);

            teamToAddPlayerTo.Players.Add(playerToAddToTeam);

            return teamToAddPlayerTo;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}