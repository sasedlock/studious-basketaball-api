using System.Collections.Generic;

namespace CommandAndQuery.Domain.Models
{
    public class BasketballTeam
    {
        public BasketballTeam()
        {
            Players = new List<Player>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }
    }
}