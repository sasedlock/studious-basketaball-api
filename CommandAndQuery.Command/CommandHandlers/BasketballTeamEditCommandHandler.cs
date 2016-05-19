using System;
using System.Linq;
using CommandAndQuery.Command.Interfaces;
using CommandAndQuery.Data;
using CommandAndQuery.Domain.Models;

namespace CommandAndQuery.Command.CommandHandlers
{
    public class BasketballTeamEditCommandHandler
        : CommandHandler<BasketballTeamEditCommand, BasketballTeam>
    {
        private readonly BasketballContext _context;

        public BasketballTeamEditCommandHandler(BasketballContext context)
        {
            _context = context;
        } 

        public BasketballTeamEditCommandHandler() : this(new BasketballContext()) { }

        public override BasketballTeam Handle(BasketballTeamEditCommand command)
        {
            var teamToEdit = _context.Teams.FirstOrDefault(t => t.Id == command.Id);

            teamToEdit.Name = command.Name;

            _context.SaveChanges();

            return teamToEdit;
        }
    }

    public class BasketballTeamEditCommand : ICommand<BasketballTeam>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}