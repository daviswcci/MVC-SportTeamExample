using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsTeamExample.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public virtual List<Player> Players { get; set; }

        public Team()
        {

        }
        public Team(int id, string name, string city)
        {
            Id = id;
            Name = name;
            City = city;
        }
    }
}