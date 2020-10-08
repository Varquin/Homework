using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Players
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public Players(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
}
