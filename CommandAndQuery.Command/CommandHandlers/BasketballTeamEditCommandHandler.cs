using System;
using System.Linq;
using CommandAndQuery.Command.Interfaces;
using CommandAndQuery.Data;
using CommandAndQuery.Data.Repositories;
using CommandAndQuery.Domain.Models;

namespace CommandAndQuery.Command.CommandHandlers
{
    public class BasketballTeamEditCommandHandler
        : CommandHandler<BasketballTeamEditCommand, BasketballTeam>
    {
        private readonly IRepository<BasketballTeam> _repository;

        public BasketballTeamEditCommandHandler(IRepository<BasketballTeam> repository)
        {
            _repository = repository;
        } 

        //public BasketballTeamEditCommandHandler() : this(new BasketballTeamRepository()) { }

        public override BasketballTeam Handle(BasketballTeamEditCommand command)
        {
            var teamToEdit = _repository.GetById(command.Id);

            teamToEdit.Name = command.Name;

            _repository.Edit(teamToEdit);
            _repository.SaveChanges();

            return teamToEdit;
        }
    }

    public class BasketballTeamEditCommand : ICommand<BasketballTeam>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}