using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8HourHero.Shared
{
    public class Hero
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Level { get; set; } = 1;
        public int Experience { get; set; }
        public int NextLevelExperience { get; set; } = 100;
    }
}
