using CommandAndQuery.Command.Interfaces;
using CommandAndQuery.Data;
using CommandAndQuery.Data.Repositories;
using CommandAndQuery.Domain.Models;

namespace CommandAndQuery.Command.CommandHandlers
{
    public class PlayerCreateCommandHandler
        : CommandHandler<PlayerCreateCommand, Player>
    {
        private readonly IRepository<Player> _repository;

        public PlayerCreateCommandHandler(IRepository<Player> repository)
        {
            _repository = repository;
        }

        //public PlayerCreateCommandHandler() : this(new PlayerRepository()) { }

        public override Player Handle(PlayerCreateCommand commmand)
        {
            var playerToCreate = new Player
            {
                Id = commmand.Id,
                FirstName = commmand.FirstName,
                LastName = commmand.LastName,
                Position = commmand.Position
            };

            _repository.Add(playerToCreate);
            _repository.SaveChanges();

            return playerToCreate;
        }
    }

    public class PlayerCreateCommand : ICommand<Player>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
    }
}