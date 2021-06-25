using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsTeamExample.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public virtual List<PlayerPosition> Positions { get; set; }
        public int TeamId { get; set; }
        public virtual Team Team {get; set;}
        //public double PPG { get; set; }

        public Player()
        {

        }
        public Player(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
