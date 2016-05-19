using CommandAndQuery.Command.Interfaces;
using CommandAndQuery.Domain.Models;

namespace CommandAndQuery.Dto
{
    public class BasketballTeamEditModel : ICommand<BasketballTeam>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
