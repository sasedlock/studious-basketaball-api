using System.Runtime.InteropServices;
using CommandAndQuery.Command.Interfaces;
using CommandAndQuery.Data;
using CommandAndQuery.Data.Repositories;
using CommandAndQuery.Domain.Models;

namespace CommandAndQuery.Command.CommandHandlers
{
    public class AddPlayerToTeamCommandHandler
        : CommandHandler<AddPlayerToTeamCommand, BasketballTeam>
    {
        private readonly BasketballTeamRepository _repository;

        public AddPlayerToTeamCommandHandler(BasketballTeamRepository repository)
        {
            _repository = repository;
        }

        public AddPlayerToTeamCommandHandler() : this(new BasketballTeamRepository()) { }

        public override BasketballTeam Handle(AddPlayerToTeamCommand command)
        {
            var teamToAddPlayerTo = _repository.AddPlayerToTeam(command.TeamId, command.PlayerId);
            _repository.SaveChanges();

            return teamToAddPlayerTo;
        }
    }

    public class AddPlayerToTeamCommand : ICommand<BasketballTeam>
    {
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
    }
}