using CommandAndQuery.Domain.Interfaces;

namespace CommandAndQuery.Domain.Models
{
    public class Player : IModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int? BasketballTeamId { get; set; }
        public BasketballTeam Team { get; set; }
    }
}