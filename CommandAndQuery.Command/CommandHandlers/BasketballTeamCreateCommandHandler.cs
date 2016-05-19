using CommandAndQuery.Command.Interfaces;
using CommandAndQuery.Data;
using CommandAndQuery.Domain.Models;

namespace CommandAndQuery.Command.CommandHandlers
{
    public class BasketballTeamCreateCommandHandler 
        : CommandHandler<BasketballTeamCreateCommand, BasketballTeam>
    {
        private readonly BasketballContext _context;

        public BasketballTeamCreateCommandHandler(BasketballContext context)
        {
            _context = context;
        }    

        public BasketballTeamCreateCommandHandler() : this(new BasketballContext()) { }

        public override BasketballTeam Handle(BasketballTeamCreateCommand command)
        {
            var teamToCreate = new BasketballTeam
            {
                Id = command.Id,
                Name = command.Name
            };

            _context.Teams.Add(teamToCreate);

            _context.SaveChanges();

            return teamToCreate;
        }
    }

    public class BasketballTeamCreateCommand : ICommand<BasketballTeam>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}