using CommandAndQuery.Command.Interfaces;
using CommandAndQuery.Data;
using CommandAndQuery.Domain.Models;

namespace CommandAndQuery.Command.CommandHandlers
{
    public class PlayerCreateCommandHandler
        : CommandHandler<PlayerCreateCommand, Player>
    {
        private readonly BasketballContext _context;

        public PlayerCreateCommandHandler(BasketballContext context)
        {
            _context = context;
        }

        public PlayerCreateCommandHandler() : this(new BasketballContext()) { }

        public override Player Handle(PlayerCreateCommand commmand)
        {
            var playerToCreate = new Player
            {
                Id = commmand.Id,
                FirstName = commmand.FirstName,
                LastName = commmand.LastName,
                Position = commmand.Position
            };

            _context.Players.Add(playerToCreate);

            _context.SaveChanges();

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