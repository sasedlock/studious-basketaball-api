using System.Runtime.InteropServices;
using CommandAndQuery.Command.Interfaces;
using CommandAndQuery.Data;
using CommandAndQuery.Domain.Models;

namespace CommandAndQuery.Command.CommandHandlers
{
    public class AddPlayerToTeamCommandHandler
        : CommandHandler<AddPlayerToTeamCommand, BasketballTeam>
    {
        private readonly BasketballContext _context;

        public AddPlayerToTeamCommandHandler(BasketballContext context)
        {
            _context = context;
        }

        public AddPlayerToTeamCommandHandler() : this(new BasketballContext()) { }

        public override BasketballTeam Handle(AddPlayerToTeamCommand command)
        {
            var teamToAddPlayerTo = _context.Teams.Find(command.TeamId);
            var playerToAddToTeam = _context.Players.Find(command.PlayerId);

            teamToAddPlayerTo.Players.Add(playerToAddToTeam);

            _context.SaveChanges();

            return teamToAddPlayerTo;
        }
    }

    public class AddPlayerToTeamCommand : ICommand<BasketballTeam>
    {
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
    }
}