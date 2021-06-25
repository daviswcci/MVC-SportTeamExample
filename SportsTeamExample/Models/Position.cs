using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsTeamExample.Models
{
    public class Position
    {
        public int Id { get; set;  }
        public string Name { get; set; }
        public virtual List<PlayerPosition> Players { get; set; }
        public Position()
        {

        }
        public Position(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
