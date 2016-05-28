using System.Linq;
using CommandAndQuery.Command.Interfaces;
using CommandAndQuery.Data;
using CommandAndQuery.Data.Repositories;
using CommandAndQuery.Domain.Models;

namespace CommandAndQuery.Command.CommandHandlers
{
    public class PlayerEditCommandHandler 
        : CommandHandler<PlayerEditCommand, Player>
    {
        private readonly PlayerRepository _repository;

        public PlayerEditCommandHandler(PlayerRepository repository)
        {
            _repository = repository;
        }

        public PlayerEditCommandHandler() : this(new PlayerRepository()) { }

        public override Player Handle(PlayerEditCommand command)
        {
            var playerToEdit = _repository.GetById(command.Id);

            playerToEdit.FirstName = command.FirstName;
            playerToEdit.LastName = command.LastName;
            playerToEdit.Position = command.Position;

            _repository.Edit(playerToEdit);
            _repository.SaveChanges();

            return playerToEdit;
        }
    }

    public class PlayerEditCommand : ICommand<Player>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
    }
}