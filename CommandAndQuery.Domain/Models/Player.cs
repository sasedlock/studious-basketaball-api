namespace CommandAndQuery.Domain.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int BasketballTeamId { get; set; }
        public BasketballTeam Team { get; set; }
    }
}