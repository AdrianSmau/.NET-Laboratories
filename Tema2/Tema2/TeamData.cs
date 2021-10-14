using System;
using System.Collections.Generic;
using System.Text;

namespace Tema2
{
    class TeamData
    {
        public string Name { get; set; }
        public int ScoredGoals { get; set; }
        public int ConcededGoals { get; set; }
        public TeamData()
        {
            Name = "";
            ScoredGoals = 0;
            ConcededGoals = 0;
        }

        public static TeamData[] ArrayGenerator(int size)
        {
            return new TeamData[size];
        }
    }
}
