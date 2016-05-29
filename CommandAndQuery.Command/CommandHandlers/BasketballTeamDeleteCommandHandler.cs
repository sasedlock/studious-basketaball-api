using System.Windows.Input;
using CommandAndQuery.Command.Interfaces;
using CommandAndQuery.Data;
using CommandAndQuery.Domain.Models;
using MediatR;

namespace CommandAndQuery.Command.CommandHandlers
{
    public class BasketballTeamDeleteCommandHandler : CommandHandler<BasketballTeamDeleteCommand, Unit>
    {
        private readonly IRepository<BasketballTeam> _repository;

        public BasketballTeamDeleteCommandHandler(IRepository<BasketballTeam> repository)
        {
            _repository = repository;
        }

        public override Unit Handle(BasketballTeamDeleteCommand command)
        {
            var teamToDelete = _repository.GetById(command.TeamId);

            return _repository.Delete(teamToDelete);
        }
    }

    public class BasketballTeamDeleteCommand : ICommand<Unit>
    {
        public int TeamId { get; set; }
    }
}