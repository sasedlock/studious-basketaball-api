using System.Collections.Generic;
using CommandAndQuery.Domain.Interfaces;

namespace CommandAndQuery.Domain.Models
{
    public class BasketballTeam : IModel
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