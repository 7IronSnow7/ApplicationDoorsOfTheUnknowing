using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ApplicationDoorsOfTheUnknowing
{
    public class JackRabbitClass
    {
        public static void Explanation(PlayerClass currentPlayer) 
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("| You open the door and a bright light blinds you, you walk through it cautiously.");
            Console.WriteLine("| A Jack Rabbit sits on the tree flipping a coin continuosly, you approach.");
            Console.WriteLine($"| Jack Rabbit: 'Ahh {currentPlayer.name} champion of the Earth Realm' I see you have chosen the path to save your beloved planet.");
            Console.WriteLine("| (Nothing but silence while the Jack Rabbit eagerly flips his coin).");
            Console.WriteLine($"| So {currentPlayer.name} the challenge before you is a game of chance. You have to beat me in coin flipping contest.");
            Console.WriteLine("| I will flip the coin 3 times, you have to guess Heads or Tails. My choice is opposite to your guess.");
            Console.WriteLine("| The person with the most correct guesses WINS!");
            Console.WriteLine("| Winner continues along the path, loser...(Jack Rabbit smiles eagerly). Well we know what happens....");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------");

        }

    }
}
