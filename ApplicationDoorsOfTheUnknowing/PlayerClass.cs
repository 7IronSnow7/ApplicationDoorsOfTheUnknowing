using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDoorsOfTheUnknowing
{
    // Creating the player
    // Got information from here ---> https://www.youtube.com/watch?v=EURyF4U5OKw&list=PL04Naussmr9dWEMfIDE9trydZQda897bc
    public class PlayerClass
    {
        //Variables of player class
        public string? Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Potion { get; set; }
        public int Score { get; set; }
    }
}
