using System.Linq;
using CommandAndQuery.Command.Interfaces;
using CommandAndQuery.Data;
using CommandAndQuery.Domain.Models;

namespace CommandAndQuery.Command.CommandHandlers
{
    public class PlayerEditCommandHandler 
        : CommandHandler<PlayerEditCommand, Player>
    {
        private readonly BasketballContext _context;

        public PlayerEditCommandHandler(BasketballContext context)
        {
            _context = context;
        }

        public PlayerEditCommandHandler() : this(new BasketballContext()) { }

        public override Player Handle(PlayerEditCommand command)
        {
            var playerToEdit = _context.Players.FirstOrDefault(p => p.Id == command.Id);

            playerToEdit.FirstName = command.FirstName;
            playerToEdit.LastName = command.LastName;
            playerToEdit.Position = command.Position;

            _context.SaveChanges();

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