using CommandAndQuery.Command.Interfaces;
using CommandAndQuery.Data;
using CommandAndQuery.Data.Repositories;
using CommandAndQuery.Domain.Models;

namespace CommandAndQuery.Command.CommandHandlers
{
    public class BasketballTeamCreateCommandHandler
        : CommandHandler<BasketballTeamCreateCommand, BasketballTeam>
    {
        private readonly IRepository<BasketballTeam> _repository;

        public BasketballTeamCreateCommandHandler(IRepository<BasketballTeam> repository)
        {
            _repository = repository;
        }

        //public BasketballTeamCreateCommandHandler() : this(new BasketballTeamRepository()) { }

        public override BasketballTeam Handle(BasketballTeamCreateCommand command)
        {
            var teamToCreate = new BasketballTeam
            {
                Id = command.Id,
                Name = command.Name
            };

            _repository.Add(teamToCreate);
            _repository.SaveChanges();

            return teamToCreate;
        }
    }

    public class BasketballTeamCreateCommand : ICommand<BasketballTeam>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}