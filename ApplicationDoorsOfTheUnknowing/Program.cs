using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml.Linq;

namespace ApplicationDoorsOfTheUnknowing
{

    class Program
    {
        public static PlayerClass currentPlayer = new();

        public static EnemyOrc orc = new();

        public static JackRabbitClass jackRabbit = new();

        const string cosmicDweller = "Celestial Being";

        static void Main(string[] args)
        {
            Console.WriteLine("..........................");
            Console.WriteLine("| Doors Of The Unknowing |");
            Console.WriteLine("..........................");

            GameStart();
            TheChallengeAhead();
            DoorsOfUnknowing(Doors, JackRabbitChallenge); // Challenge for the user
        }
        public static void GameStart()
        {
            // Display the introduction messages
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine("| You have been teleported to a strange cosmic realm.                            ");
            Console.WriteLine("| You are greeted by a Celestial Being, its Aura frightens you but you trust it. ");
            Console.WriteLine("| Celestial Being: What is thy name Earth being?                                 ");
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine(" [Please enter your name:] ");
            Console.Write("> ");

            // Get the player's name, ensuring it's valid
            currentPlayer.name = GetValidName();

            // If the player didn't provide a valid name, assign a default name
            if (currentPlayer.name == "")
            {
                Console.Clear();
                Console.WriteLine("----------------------------");
                Console.WriteLine("| You are unworthy of a name");
                Console.WriteLine("----------------------------");
                currentPlayer.name = "Nameless Earth being";
            }
            else
            {
                // Display a welcome message with the player's name
                Console.Clear();
                Console.WriteLine("***************************************************************");
                Console.WriteLine($"{currentPlayer.name} ?");
                Console.WriteLine($"Ahhh {currentPlayer.name} the protector of the Earth Realm");
                Console.WriteLine("***************************************************************");
            }
        }

        // Get a valid name from the player
        public static string GetValidName()
        {
            string playerName = Console.ReadLine();

            // Keep asking for a valid name until one is provided
            while (string.IsNullOrWhiteSpace(playerName) || !IsNameValid(playerName))
            {
                Console.WriteLine("[Please enter a valid name]");
                Console.Write("> ");
                playerName = Console.ReadLine();
            }

            return playerName;
        }

        // Check if a name is valid (contains no invalid characters)
        public static bool IsNameValid(string name)
        {
            // Use regular expressions to check for invalid characters
            return !Regex.IsMatch(name, "[0-9]|\\!|\\@|\\#|\\$|\\^|\\%|\\&|\\*|\\(|\\)|\\?");
        }
        // Explains the plot of the game.
        // Gives the user a choice of actually playing the game or ending it immediately.
        public static void TheChallengeAhead()
        {
            // Display the introduction messages
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine($"| {cosmicDweller}: I have summoned you here today as the champion of your realm. ");
            Console.WriteLine($"| {currentPlayer.name}, you have a great challenge ahead of you.                ");
            Console.WriteLine("| Do you accept what lies ahead?                                                  ");
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine("[Please type: (Yes) to continue or (No) to be transported back to Earth]");
            Console.Write("> ");

            // Get the player's choice and make it lowercase to eliminate case sensitivity
            var choice = Console.ReadLine().ToLower();

            if (choice == "yes")
            {
                Console.Clear();
                Console.WriteLine("**************************************************************");
                Console.WriteLine("| I expect nothing less than the champion of the Earth Realm ");
                Console.WriteLine("**************************************************************");
            }
            else
            {
                // Display a farewell message and exit the program
                Console.Clear();
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine($"| Goodbye {currentPlayer.name}.                                                            ");
                Console.WriteLine("| You have been transported back to Earth. Another champion has been chosen in your place.  ");
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                System.Environment.Exit(0); // Exit the program
            }

            // Provide an explanation of the game if the user chooses "yes."
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"|{cosmicDweller}: You are in the cosmic realm of the unknowing.                                                 ");
            Console.WriteLine("| Earth is in grave danger of being destroyed. You will have a series of three doors in front of you.          ");
            Console.WriteLine("| Each door will have a challenge behind it.                                                                       ");
            Console.WriteLine("| The challenge difficulty varies, thus, meaning it is left to chance as to what you will face behind these doors. ");
            Console.WriteLine("| You need to complete each challenge successfully in order to save Earth                                          ");
            Console.WriteLine($"| Godspeed {currentPlayer.name}                                                                                 ");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
        }
        public static void Doors()
        {
            for (int i = 0; i < 8; i++)
            {
                for (var j = 6; j >= 0; j--)
                {
                    Console.Write("|" + " ");
                }
                Console.Write("               ");
                for (var j = 6; j >= 0; j--)
                {
                    Console.Write("|" + " ");
                }
                Console.Write("               ");
                for (var j = 6; j >= 0; j--)
                {
                    Console.Write("|" + " ");
                }
                Console.WriteLine("");
            }
        }

        public static void JackRabbitChallenge()
        {
            jackRabbit.Explanation(currentPlayer);

            Random random = new Random();
            var playerScore = 0;
            var jackRabbitScore = 0;

            const int scoreThreshold = 3;

            while (playerScore < scoreThreshold && jackRabbitScore < scoreThreshold)
            {
                Console.WriteLine("==========================================");
                Console.WriteLine($"| Your score = {playerScore} : Jack Rabbit score = {jackRabbitScore} |");
                Console.WriteLine("==========================================");
                Console.WriteLine("[Please enter 'T' for (Tails) or 'H' for (Heads)]");
                Console.Write("> ");
                var playerChoice = Console.ReadLine();
                int coinFlip = random.Next(0, 2);

                if ((playerChoice.ToLower() == "h" && coinFlip == 0) || (playerChoice.ToLower() == "t" && coinFlip == 1))
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("| Jack Rabbit has flipped the coin.");
                    Console.WriteLine("| You guessed correctly !");
                    Console.WriteLine("------------------------------------");
                    playerScore++;
                }
                else
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("| You guessed incorrectly.");
                    Console.WriteLine("---------------------------");
                    jackRabbitScore++;
                }
            }

            if (jackRabbitScore == scoreThreshold)
            {
                Console.Clear();
                Console.WriteLine("\n*********************************************");
                Console.WriteLine("             YOU HAVE LOST!                   ");
                Console.WriteLine("***********************************************");
                Console.WriteLine("\n---------------------------------------------------------");
                Console.WriteLine($"| I see luck is not on your side, {currentPlayer.name}.");
                Console.WriteLine("| Let me ask you this.");
                Console.WriteLine($"| How far can a Jack Rabbit jump {currentPlayer.name}? ");
                Console.WriteLine("---------------------------------------------------------");

                string answerToJump;
                do
                {
                    Console.WriteLine("[Please type 'jackrabbit' to answer]");
                    Console.Write("> ");
                    answerToJump = Console.ReadLine();

                    if (currentPlayer.name == "")
                    {
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("| Hmmm, I guess you caught onto my trick question. ");
                        Console.WriteLine("| You may pass.");
                        Console.WriteLine("--------------------------------------------------");
                    }
                    else if (answerToJump.Equals("jackrabbit", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("| You are correct, you may pass!");
                        Console.WriteLine("----------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine("| That's not correct, try again.");
                        Console.WriteLine("----------------------------------------");
                    }
                } while (!answerToJump.Equals("jackrabbit", StringComparison.OrdinalIgnoreCase));
            }

            Console.Clear();
            Console.WriteLine("\n*********************************************");
            Console.WriteLine("             YOU HAVE WON!                   ");
            Console.WriteLine("***********************************************");
            Console.WriteLine("\n");
            Console.WriteLine($"Congratulations {currentPlayer.name}, you have defeated the Jack Rabbit!");
            Console.WriteLine("A large door appears before you.");
            Console.WriteLine("\n");
            for (int i = 20; i >= 0; i--)
            {
                for (int j = 15; j >= 0; j--)
                {
                    Console.Write("|" + " ");
                }
                Console.WriteLine("");
            }
        }


        // Three doors with tasks of random probability behind it.
        public static void DoorsOfUnknowing(Action doors, Action jackChal)
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("| Please choose one of the three doors.");
            Console.WriteLine("***************************************");
            doors();
            Console.Write("Door 1 = [one] | [1].      ");
            Console.Write("Door 2 = [two] | [2].      ");
            Console.Write("Door 3 = [three] | [3].");
            Console.WriteLine("\nPlease type your option below.");
            Console.Write("> ");
            var doorChoice = Console.ReadLine();

            
            if (doorChoice.ToLower() == "one" || doorChoice == "1")
            {
                Console.Clear();
                jackChal();
                
                // Door 1, 2nd Boss Battle
                Console.WriteLine("\n");
                Console.WriteLine("*******************************************");
                Console.WriteLine(" You proceed to the door in front of you");
                Console.WriteLine("*******************************************");
                Console.WriteLine("\n");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("| You open the door slowly.                ");
                Console.WriteLine("| An Orc appears, sitting on a rock waiting.");
                Console.WriteLine("| He looks at you with red glowing eyes.   ");
                Console.WriteLine("| He says: Prepare to fight!               ");
                Console.WriteLine("--------------------------------------------");
                // Users Health
                PlayerClass health = new PlayerClass();
                currentPlayer.health = 20;
                // Users Attack damage
                PlayerClass attack = new PlayerClass();
                currentPlayer.attack = 5;
                // Users Potion
                PlayerClass potion = new PlayerClass();
                currentPlayer.potion = 4;
                // Orcs Health
                EnemyOrc enemyHealth = new EnemyOrc();
                orc.enemyHealth = 10;
                // Orcs Attack damage 
                EnemyOrc enemyAttack = new EnemyOrc();
                orc.enemyAttack = 3;
                // Orcs potion
                EnemyOrc enemyPotion = new EnemyOrc();
                orc.enemyPotion = 2;
                // Orcs Actions in the battle with be of random
                Random orcRandom = new Random();
                // Orc Fight
                while (currentPlayer.health > 0 && orc.enemyHealth > 0)
                {
                    // Users Turn
                    Console.WriteLine("=========================");
                    Console.WriteLine($"{currentPlayer.name} = {currentPlayer.health} HP | Orc = {orc.enemyHealth} HP");
                    Console.WriteLine("=========================");
                    Console.WriteLine("\n--Your Turn--");
                    Console.WriteLine("Press [A] to attack or [H] to heal");
                    Console.WriteLine("--------------------");
                    Console.WriteLine("[(A)ttack | (H)eal]");
                    Console.WriteLine("--------------------");
                    Console.Write("> ");

                    var choice = Console.ReadLine();
                    if (choice.ToLower() == "a")
                    {
                        Console.Clear();
                        orc.enemyHealth -= currentPlayer.attack;
                        Console.WriteLine($"{currentPlayer.name} attacks the Orc! Orc takes ({currentPlayer.attack}) damage");
                    }
                    else
                    {
                        Console.Clear();
                        currentPlayer.health += currentPlayer.potion;
                        Console.WriteLine($"{currentPlayer.name} heals ({currentPlayer.potion}) HP");
                    }

                    // Orc's Turn
                    if (orc.enemyHealth > 0)
                    {
                        Console.WriteLine("\n--Orc's Turn--");
                        var orcChoice = orcRandom.Next(0, 2);

                        if (orc.enemyAttack == 0)
                        {
                            currentPlayer.health -= orc.enemyAttack;
                            Console.WriteLine($"The Orc attacks you and deals {orc.enemyAttack} damage!");
                        }
                        else
                        {
                            orc.enemyHealth += orc.enemyPotion;
                            Console.WriteLine($"The Orc has healed {orc.enemyPotion} HP");
                        }

                    }

                }
                if (currentPlayer.health > 0)
                {
                    Console.Clear();
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine("             YOU HAVE WON!                   ");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("\n-----------------------------------------------------------------------");
                    Console.WriteLine($"| Congratulations {currentPlayer.name} you have slain the fierce orc        ");
                    Console.WriteLine("| Another door appears before you.                                    ");
                    Console.WriteLine("-----------------------------------------------------------------------");
                    Console.WriteLine("\n");
                    for (var i = 20; i >= 0; i--)
                    {
                        for (var j = 15; j >= 0; j--)
                        {
                            Console.Write("|" + " ");
                        }
                        Console.WriteLine(" ");

                    }
                    Console.WriteLine("You walk through it.....");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine("             YOU HAVE LOST!                   ");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("| The might Orc has defeated you! ");
                    Console.WriteLine("| Earth is devoured.              ");
                    Console.WriteLine("-----------------------------------");
                    System.Environment.Exit(0);
                }
                // Door 1, 3rd Boss Battle
                currentPlayer.score = 0;
                var honeyBadgerScore = 0;

                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("| You open the door and see a Honey Badger lying on a lily pad.");
                Console.WriteLine($"| Ahhh, {currentPlayer.name}. I see you have slain that dimwitted Orc.");
                Console.WriteLine("| Congratulations are in order, but let me warn you. I am far deadlier.");
                Console.WriteLine("| Me and you will face off to the death in game of, wait for it!");
                Console.WriteLine("| ROCK!");
                Console.WriteLine("| PAPER!");
                Console.WriteLine("| SCISSORS!");
                Console.WriteLine("-------------------------------------------------------------------------");


                while (currentPlayer.score != 3 && honeyBadgerScore != 3)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("=============================================================");
                    Console.WriteLine($"{currentPlayer.name} = {currentPlayer.score} | Honey Badger = {honeyBadgerScore}");
                    Console.WriteLine("=============================================================");
                    Console.WriteLine("[Please enter 'r' for (Rock) | 'p' for (Paper) | 's' for (Scissors)]");
                    Console.Write("> ");
                    var userChoice = Console.ReadLine();

                    var honeyBadgerChoice = random.Next(0, 3);

                    if (honeyBadgerChoice == 0)
                    {
                        Console.WriteLine("Honey Badger chooses rock.");

                        switch (userChoice)
                        {
                            case "r":
                                Console.WriteLine("This round is a draw.");
                                break;
                            case "p":
                                Console.WriteLine("You win this round!");
                                currentPlayer.score++;
                                break;
                            default:
                                Console.WriteLine("You lose this round!");
                                honeyBadgerScore++;
                                break;
                        }
                    }
                    else if (honeyBadgerChoice == 1)
                    {
                        Console.WriteLine("Honey Badger chooses paper.");

                        switch (userChoice)
                        {
                            case "r":
                                Console.WriteLine("You lose this round.");
                                honeyBadgerScore++;
                                break;
                            case "p":
                                Console.WriteLine("This round is a draw.");
                                break;
                            default:
                                Console.WriteLine("You win this round!");
                                currentPlayer.score++;
                                break;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Honey Badger chooses scissors.");

                        switch (userChoice)
                        {
                            case "r":
                                Console.WriteLine("You win this round.");
                                currentPlayer.score++;
                                break;
                            case "p":
                                Console.WriteLine("You lose this round.");
                                honeyBadgerScore++;
                                break;
                            default:
                                Console.WriteLine("This round is a draw.");
                                break;

                        }
                    }
                    
                }
                if (currentPlayer.score == 3)
                {
                    Console.Clear();
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine("             YOU HAVE WON!                   ");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("\n----------------------------------------------------------------------------");
                    Console.WriteLine($"| Congratulations {currentPlayer.name}, you have beat me fair and square.");
                    Console.WriteLine($"| I should of known you would be the one.");
                    Console.WriteLine("-----------------------------------------------------------------------------");

                    Console.WriteLine("********************************************************************************");
                    Console.WriteLine("| 'Celestial being appears'");
                    Console.WriteLine("| You have fought and conquered the mythical creatures which stood before you");
                    Console.WriteLine("| They challenged to see if you were worthy.");
                    Console.WriteLine($"| Congratulations {currentPlayer.name} you have saved Earth.");
                    Console.WriteLine("| 'You are teleported back to Earth.");
                    Console.WriteLine("********************************************************************************");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine("             YOU HAVE LOST!                   ");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("\n---------------------------------------------------------------");
                    Console.WriteLine($"It seems the Earth Champion {currentPlayer.name} has lost");
                    Console.WriteLine("Haha, who saw that coming.");
                    Console.WriteLine($"Okay I will give you one last chance {currentPlayer.name}.");
                    Console.WriteLine("Who wins in a fight between a Snake and a Honey Badger.");
                    Console.WriteLine("---------------------------------------------------------------");
                    Console.Write("> ");
                    var answer = Console.ReadLine();

                    if (answer.ToLower() == "honey badger")
                    {
                        Console.Clear();
                        Console.WriteLine("\n*********************************************");
                        Console.WriteLine("                  CORRECT!                   ");
                        Console.WriteLine("***********************************************");
                        Console.WriteLine("\n----------------------------------------------------------------------------");
                        Console.WriteLine($"| Congratulations {currentPlayer.name}, you have beat me fair and square.");
                        Console.WriteLine($"| I should of known you would be the one.");
                        Console.WriteLine("-----------------------------------------------------------------------------");

                        Console.WriteLine("\n********************************************************************************");
                        Console.WriteLine("| 'Celestial being appears'");
                        Console.WriteLine("| You have fought and conquered the mythical creatures which stood before you");
                        Console.WriteLine("| They challenged to see if you were worthy.");
                        Console.WriteLine($"| Congratulations {currentPlayer.name} you have saved Earth.");
                        Console.WriteLine("| 'You are teleported back to Earth.");
                        Console.WriteLine("********************************************************************************");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n*********************************************");
                        Console.WriteLine("              WRONG ANSWER!                   ");
                        Console.WriteLine("***********************************************");
                        Console.WriteLine("\n");
                        Console.WriteLine("-------------------------------------------------------");
                        Console.WriteLine("Errr, WRONG!");
                        Console.WriteLine("You should of considered your answer first.");
                        Console.WriteLine("YOU HAVE BEEN DEFEATED.");
                        Console.WriteLine("Earth is destroyed.");
                        Console.WriteLine("-------------------------------------------------------");
                        System.Environment.Exit(0);
                    }
                }


            } 
            else if (doorChoice.ToLower() == "two" || doorChoice == 2.ToString())
            {
                //Door 2, 1st Boss Battle
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("| You open the door slowly.                ");
                Console.WriteLine("| An Orc appears, sitting on a rock waiting");
                Console.WriteLine("| He looks at you with red glowing eyes.   ");
                Console.WriteLine("| He says: Prepare to fight!               ");
                Console.WriteLine("--------------------------------------------");
                // Users Health
                PlayerClass health = new PlayerClass();
                currentPlayer.health = 20;
                // Users Attack damage
                PlayerClass attack = new PlayerClass();
                currentPlayer.attack = 5;
                // Users Potion
                PlayerClass potion = new PlayerClass();
                currentPlayer.potion = 4;
                // Orcs Health
                EnemyOrc enemyHealth = new EnemyOrc();
                orc.enemyHealth = 10;
                // Orcs Attack damage 
                EnemyOrc enemyAttack = new EnemyOrc();
                orc.enemyAttack = 3;
                // Orcs potion
                EnemyOrc enemyPotion = new EnemyOrc();
                orc.enemyPotion = 2;
                // Orcs Actions in the battle with be of random
                Random orcRandom = new Random();
                // Orc Fight
                while (currentPlayer.health > 0 && orc.enemyHealth > 0)
                {
                    // Users Turn
                    Console.WriteLine("=========================");
                    Console.WriteLine($"{currentPlayer.name} = {currentPlayer.health} HP | Orc = {orc.enemyHealth} HP");
                    Console.WriteLine("=========================");
                    Console.WriteLine("--Your Turn--");
                    Console.WriteLine("Press [A] to attack or [H] to heal");
                    Console.WriteLine("--------------------");
                    Console.WriteLine("[(A)ttack | (H)eal]");
                    Console.WriteLine("--------------------");
                    Console.Write("> ");

                    var choice = Console.ReadLine();
                    if (choice.ToLower() == "a")
                    {
                        Console.Clear();
                        orc.enemyHealth -= currentPlayer.attack;
                        Console.WriteLine($"{currentPlayer.name} attacks the Orc! Orc takes ({currentPlayer.attack}) damage");
                    }
                    else
                    {
                        currentPlayer.health += currentPlayer.potion;
                        Console.WriteLine($"{currentPlayer.name} heals ({currentPlayer.potion}) HP");
                    }

                    // Orc's Turn
                    if (orc.enemyHealth > 0)
                    {
                        Console.WriteLine("--Orc's Turn--");
                        var orcChoice = orcRandom.Next(0, 2);

                        if (orc.enemyAttack == 0)
                        {
                            currentPlayer.health -= orc.enemyAttack;
                            Console.WriteLine($"The Orc attacks you and deals {orc.enemyAttack} damage!");
                        }
                        else
                        {
                            orc.enemyHealth += orc.enemyPotion;
                            Console.WriteLine($"The Orc has healed {orc.enemyPotion} HP");
                        }

                    }

                }
                if (currentPlayer.health > 0)
                {
                    Console.Clear();
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine("             YOU HAVE WON!                   ");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("\n-----------------------------------------------------------------------");
                    Console.WriteLine($"| Congratulations {currentPlayer.name} you have slain the fierce orc.         ");
                    Console.WriteLine("| Another large door appears before you.                                    ");
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine("\n");
                    for (var i = 20; i >= 0; i--)
                    {
                        for (var j = 15; j >= 0; j--)
                        {
                            Console.Write("|" + " ");
                        }
                        Console.WriteLine(" ");
                    }
                    Console.WriteLine("\n You walk through it.....");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine("             YOU HAVE LOST!                   ");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("\n-----------------------------------");
                    Console.WriteLine("| The might Orc has defeated you! ");
                    Console.WriteLine("| Earth is devoured.              ");
                    Console.WriteLine("-----------------------------------");
                }
                // Door 2, 2nd Boss Battle
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("| You open the door and a bright light blinds you, you walk through it cautiously                                                ");
                Console.WriteLine("| A Jack Rabbit sits on the tree flipping a coin continuosly, you approach                                                        ");
                Console.WriteLine($"| Jack Rabbit: 'Ahh {currentPlayer.name} champion of the Earth Realm' I see you have defeated the clumsy Orc ");
                Console.WriteLine("| (Nothing but silence while the Jack Rabbit eagerly flips his coin)                                                              ");
                Console.WriteLine($"| So {currentPlayer.name} the challenge before you is a game of chance. You have to beat me in coin flipping contest.            ");
                Console.WriteLine("| I will flip the coin 3 times, you have to guess Heads or Tails. My choice is opposite to your guess.                            ");
                Console.WriteLine("| The person with the most correct guesses WINS!                                                                                  ");
                Console.WriteLine("| Winner continues along the path, loser...(Jack Rabbit smiles eagerly). Well we know what happens....                            ");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------");

                // Declaring random variable for the coin toss
                var playerScore = 0;
                var jackRabbitScore = 0;
                while (playerScore != 3 && jackRabbitScore != 3)
                {
                    Random random = new Random();
                    Console.WriteLine("==========================================");
                    Console.WriteLine($" Your score = {playerScore} : Jack Rabbit score = {jackRabbitScore} ");
                    Console.WriteLine("==========================================");
                    Console.WriteLine("| Please enter 'T' for [Tails] or 'H' for [Heads] |");
                    Console.Write("> ");
                    var playerChoice = Console.ReadLine();
                    var coinFlip = random.Next(0, 2);

                    if (playerChoice.ToLower() == "h" && coinFlip == 0)
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("| Jack Rabbit has flipped the coin ");
                        Console.WriteLine("| You guessed correctly            ");
                        Console.WriteLine("------------------------------------");
                        playerScore++;
                    }
                    else if (playerChoice.ToLower() == "t" && coinFlip == 1)
                    {
                        Console.WriteLine("\n-----------------------------");
                        Console.WriteLine("| Jack Rabbit flips the coin ");
                        Console.WriteLine("| You guessed correctly      ");
                        Console.WriteLine("------------------------------");
                        playerScore++;
                    }
                    else
                    {
                        Console.WriteLine("\n---------------------------");
                        Console.WriteLine("| You guessed incorrectly ");
                        Console.WriteLine("---------------------------");
                        jackRabbitScore++;
                    }
                }
                if (jackRabbitScore == 3)
                {
                    Console.Clear();
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine("             YOU HAVE LOST!                   ");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("\n---------------------------------------------------------");
                    Console.WriteLine($"| I see luck is not on your side, {currentPlayer.name}.");
                    Console.WriteLine($"| How far can a Jack Rabbit jump {currentPlayer.name}? ");
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine("[Please type your answer below]");
                    Console.Write("> ");
                    var answerToJump = Console.ReadLine();
                    if (currentPlayer.name == "")
                    {
                        Console.Clear();
                        Console.WriteLine("\n*********************************************");
                        Console.WriteLine("                CORRECT!                   ");
                        Console.WriteLine("***********************************************");
                        Console.WriteLine("\n--------------------------------------------------");
                        Console.WriteLine("| Hmmm, I guess you caught onto my trick question ");
                        Console.WriteLine("| You may pass.                                   ");
                        Console.WriteLine("--------------------------------------------------");

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n*********************************************");
                        Console.WriteLine("             YOU HAVE LOST!                   ");
                        Console.WriteLine("***********************************************");
                        Console.WriteLine("\n----------------------------------");
                        Console.WriteLine("| Good answer, you may pass! ");
                        Console.WriteLine("----------------------------------");

                        
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine("             YOU HAVE WON!                   ");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("\n-------------------------------------------------------------------------");
                    Console.WriteLine($"Congratualtions {currentPlayer.name} you have defeated the Jack Rabbit!");
                    Console.WriteLine("A path reveals itself to you.");
                    Console.WriteLine("\n-------------------------------------------------------------------------");
                }
                // Last Boss Battle of Door 3
                currentPlayer.score = 0;
                var honeyBadgerScore = 0;

                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("| You follow the path and see a Honey Badger lying on a lily pad.");
                Console.WriteLine($"| Ahhh, {currentPlayer.name}. I see you have defeated the witty Jack Rabbit.");
                Console.WriteLine("| Welcome to my domain.");
                Console.WriteLine("| Me and you will face off to the death in game of, wait for it!");
                Console.WriteLine("| ROCK!");
                Console.WriteLine("| PAPER!");
                Console.WriteLine("| SCISSORS!");
                Console.WriteLine("-------------------------------------------------------------------------------");

                while (currentPlayer.score != 3 && honeyBadgerScore != 3)
                {
                    Random random = new Random();
                    Console.WriteLine("\n");
                    Console.WriteLine("=============================================================");
                    Console.WriteLine($"{currentPlayer.name} = {currentPlayer.score} | Honey Badger = {honeyBadgerScore}");
                    Console.WriteLine("=============================================================");
                    Console.WriteLine("[Please enter 'r' for (Rock) | 'p' for (Paper) | 's' for (Scissors)]");
                    Console.Write("> ");
                    var userChoice = Console.ReadLine();

                    var honeyBadgerChoice = random.Next(0, 3);

                    if (honeyBadgerChoice == 0)
                    {
                        Console.WriteLine("Honey Badger chooses rock.");

                        switch (userChoice)
                        {
                            case "r":
                                Console.WriteLine("This round is a draw.");
                                break;
                            case "p":
                                Console.WriteLine("You win this round!");
                                currentPlayer.score++;
                                break;
                            default:
                                Console.WriteLine("You lose this round!");
                                honeyBadgerScore++;
                                break;
                        }
                    }
                    else if (honeyBadgerChoice == 1)
                    {
                        Console.WriteLine("Honey Badger chooses paper.");

                        switch (userChoice)
                        {
                            case "r":
                                Console.WriteLine("You lose this round.");
                                honeyBadgerScore++;
                                break;
                            case "p":
                                Console.WriteLine("This round is a draw.");
                                break;
                            default:
                                Console.WriteLine("You win this round!");
                                currentPlayer.score++;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Honey Badger chooses scissors.");

                        switch (userChoice)
                        {
                            case "r":
                                Console.WriteLine("You win this round.");
                                currentPlayer.score++;
                                break;
                            case "p":
                                Console.WriteLine("You lose this round.");
                                honeyBadgerScore++;
                                break;
                            default:
                                Console.WriteLine("This round is a draw.");
                                break;

                        }
                    }
                }
                if (currentPlayer.score == 3)
                {
                    Console.Clear();
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine("             YOU HAVE WON!                   ");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("\n----------------------------------------------------------------------------");
                    Console.WriteLine($"Congratulations {currentPlayer.name}, you have beat me fair and square.");
                    Console.WriteLine($"[The Honey Badger waves and floats away on his lily pad].");
                    Console.WriteLine("-----------------------------------------------------------------------------");
                    Console.WriteLine("\n********************************************************************************");
                    Console.WriteLine("| 'Celestial being appears'");
                    Console.WriteLine("| You have fought and conquered the mythical creatures which stood before you");
                    Console.WriteLine("| They challenged to see if you were worthy.");
                    Console.WriteLine($"| Congratulations {currentPlayer.name} you have saved Earth.");
                    Console.WriteLine("| 'You are teleported back to Earth.");
                    Console.WriteLine("********************************************************************************");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine("             YOU HAVE LOST!                   ");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("\n---------------------------------------------------------------");
                    Console.WriteLine($"It seems the Earth Champion {currentPlayer.name} has lost");
                    Console.WriteLine("Haha, who saw that coming.");
                    Console.WriteLine($"Okay I will give you one last chance {currentPlayer.name}.");
                    Console.WriteLine("Who wins in a fight between a Snake and a Honey Badger.");
                    Console.WriteLine("---------------------------------------------------------------");
                    Console.Write("> ");
                    var answer = Console.ReadLine();

                    if (answer.ToLower() == "honey badger")
                    {
                        Console.Clear();                       
                        Console.WriteLine("\n*********************************************");
                        Console.WriteLine("              CORRECT!                   ");
                        Console.WriteLine("***********************************************");
                        Console.WriteLine("\n--------------------------------------------------------");
                        Console.WriteLine("| Of course it is me!");
                        Console.WriteLine($"| Congratulations {currentPlayer.name}!");
                        Console.WriteLine("| ' The Honey Badger floats away '");
                        Console.WriteLine("--------------------------------------------------------");
                        Console.WriteLine("\n********************************************************************************");
                        Console.WriteLine("| 'Celestial being appears'");
                        Console.WriteLine("| You have fought and conquered the mythical creatures which stood before you");
                        Console.WriteLine("| They challenged to see if you were worthy.");
                        Console.WriteLine($"| Congratulations {currentPlayer.name} you have saved Earth.");
                        Console.WriteLine("| 'You are teleported back to Earth.");
                        Console.WriteLine("********************************************************************************");
                    }
                    else
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("-------------------------------------------------------");
                        Console.WriteLine("Errr, WRONG!");
                        Console.WriteLine("You should of considered your answer first.");
                        Console.WriteLine("YOU HAVE BEEN DEFEATED.");
                        Console.WriteLine("Earth is destroyed.");
                        Console.WriteLine("-------------------------------------------------------");
                        System.Environment.Exit(0);
                    }
                }
            }
            else // Door 3
            {
                // Door 3, 1st Boss Battle
                Console.Clear();
                currentPlayer.score = 0;
                var honeyBadgerScore = 0;

                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine("| You open the door and see a Honey Badger lying on a lily pad.");
                Console.WriteLine($"| Ahhh, {currentPlayer.name}. I see you have chosen door number 3.");
                Console.WriteLine("| Welcome, welcome.");
                Console.WriteLine("| Me and you will face off to the death in game of, wait for it!");
                Console.WriteLine("| ROCK!");
                Console.WriteLine("| PAPER!");
                Console.WriteLine("| SCISSORS!");
                Console.WriteLine("---------------------------------------------------------------");


                while (currentPlayer.score != 3 && honeyBadgerScore != 3)
                {
                    Random random = new Random();
                    Console.WriteLine("\n");
                    Console.WriteLine("=============================================================");
                    Console.WriteLine($"{currentPlayer.name} = {currentPlayer.score} | Honey Badger = {honeyBadgerScore}");
                    Console.WriteLine("=============================================================");
                    Console.WriteLine("[Please enter 'r' for (Rock) | 'p' for (Paper) | 's' for (Scissors)]");
                    Console.Write("> ");
                    var userChoice = Console.ReadLine();

                    var honeyBadgerChoice = random.Next(0, 3);

                    if (honeyBadgerChoice == 0)
                    {
                        Console.WriteLine("Honey Badger chooses rock.");

                        switch (userChoice)
                        {
                            case "r":
                                Console.WriteLine("This round is a draw.");
                                break;
                            case "p":
                                Console.WriteLine("You win this round!");
                                currentPlayer.score++;
                                break;
                            default:
                                Console.WriteLine("You lose this round!");
                                honeyBadgerScore++;
                                break;
                        }
                    }
                    else if (honeyBadgerChoice == 1)
                    {
                        Console.WriteLine("Honey Badger chooses paper.");

                        switch (userChoice)
                        {
                            case "r":
                                Console.WriteLine("You lose this round.");
                                honeyBadgerScore++;
                                break;
                            case "p":
                                Console.WriteLine("This round is a draw.");
                                break;
                            default:
                                Console.WriteLine("You win this round!");
                                currentPlayer.score++;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Honey Badger chooses scissors.");

                        switch (userChoice)
                        {
                            case "r":
                                Console.WriteLine("You win this round.");
                                currentPlayer.score++;
                                break;
                            case "p":
                                Console.WriteLine("You lose this round.");
                                honeyBadgerScore++;
                                break;
                            default:
                                Console.WriteLine("This round is a draw.");
                                break;

                        }
                    }
                }

                if (currentPlayer.score == 3)
                {
                    Console.Clear();
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine("             YOU HAVE WON!                   ");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("\n----------------------------------------------------------------------------");
                    Console.WriteLine($"Congratulations {currentPlayer.name}, you have beat me fair and square.");
                    Console.WriteLine($"Continue along this path {currentPlayer.name} to face your next challenge.");
                    Console.WriteLine("-----------------------------------------------------------------------------");

                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine("             YOU HAVE LOST!                   ");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("\n---------------------------------------------------------------");
                    Console.WriteLine($"It seems the Earth Champion {currentPlayer.name} has lost");
                    Console.WriteLine("Haha, who saw that coming.");
                    Console.WriteLine($"Okay I will give you one last chance {currentPlayer.name}.");
                    Console.WriteLine("Who wins in a fight between a Snake and a Honey Badger.");
                    Console.WriteLine("---------------------------------------------------------------");
                    Console.Write("> ");
                    var answer = Console.ReadLine();

                    if (answer.ToLower() == "honey badger")
                    {
                        Console.Clear();
                        Console.WriteLine("\n*********************************************");
                        Console.WriteLine("              CORRECT!                   ");
                        Console.WriteLine("***********************************************");
                        Console.WriteLine("\n--------------------------------------------------------");
                        Console.WriteLine("Of course it is me!");
                        Console.WriteLine($"Well done {currentPlayer.name}.");
                        Console.WriteLine("--------------------------------------------------------");
                       
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n*********************************************");
                        Console.WriteLine("                 WRONG!                   ");
                        Console.WriteLine("***********************************************");
                        Console.WriteLine("\n-------------------------------------------------------");
                        Console.WriteLine("Errr, WRONG!");
                        Console.WriteLine("You should of considered your answer first.");
                        Console.WriteLine("YOU HAVE BEEN DEFEATED.");
                        Console.WriteLine("Earth is destroyed.");
                        Console.WriteLine("-------------------------------------------------------");
                        System.Environment.Exit(0);
                    }
              
                }
                // Door 3, 2nd Boss Battle
                Console.WriteLine("***********************************************");
                Console.WriteLine("| A misty path presents itself to you");
                Console.WriteLine("| You continue along the path laid before you.");
                Console.WriteLine("***********************************************");
                Console.WriteLine("\n");
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("| You walk slowly along the misty road.     ");
                Console.WriteLine("| A large silhouette appears before you.");
                Console.WriteLine("| An Orc presents itself, sitting on a rock waiting");
                Console.WriteLine("| He looks at you with red glowing eyes.   ");
                Console.WriteLine("| He says: Prepare to fight!               ");
                Console.WriteLine("----------------------------------------------------");

                // Users Health
                PlayerClass health = new PlayerClass();
                currentPlayer.health = 20;
                // Users Attack damage
                PlayerClass attack = new PlayerClass();
                currentPlayer.attack = 5;
                // Users Potion
                PlayerClass potion = new PlayerClass();
                currentPlayer.potion = 4;
                // Orcs Health
                EnemyOrc enemyHealth = new EnemyOrc();
                orc.enemyHealth = 10;
                // Orcs Attack damage 
                EnemyOrc enemyAttack = new EnemyOrc();
                orc.enemyAttack = 3;
                // Orcs potion
                EnemyOrc enemyPotion = new EnemyOrc();
                orc.enemyPotion = 2;
                // Orcs Actions in the battle with be of random
                Random orcRandom = new Random();
                // Orc Fight
                while (currentPlayer.health > 0 && orc.enemyHealth > 0)
                {
                    // Users Turn
                    Console.WriteLine("=========================");
                    Console.WriteLine($"{currentPlayer.name} = {currentPlayer.health} HP | Orc = {orc.enemyHealth} HP");
                    Console.WriteLine("=========================");
                    Console.WriteLine("--Your Turn--");
                    Console.WriteLine("Press [A] to attack or [H] to heal");
                    Console.WriteLine("--------------------");
                    Console.WriteLine("[(A)ttack | (H)eal]");
                    Console.WriteLine("--------------------");
                    Console.Write("> ");

                    var choice = Console.ReadLine();
                    if (choice.ToLower() == "a")
                    {
                        Console.Clear();
                        orc.enemyHealth -= currentPlayer.attack;
                        Console.WriteLine($"{currentPlayer.name} attacks the Orc! Orc takes ({currentPlayer.attack}) damage.");
                    }
                    else
                    {
                        currentPlayer.health += currentPlayer.potion;
                        Console.WriteLine($"{currentPlayer.name} heals ({currentPlayer.potion}) HP.");
                    }

                    // Orc's Turn
                    if (orc.enemyHealth > 0)
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("--Orc's Turn--");
                        var orcChoice = orcRandom.Next(0, 2);

                        if (orc.enemyAttack == 0)
                        {
                            currentPlayer.health -= orc.enemyAttack;
                            Console.WriteLine($"The Orc attacks you and deals {orc.enemyAttack} damage!");
                        }
                        else
                        {
                            orc.enemyHealth += orc.enemyPotion;
                            Console.WriteLine($"The Orc has healed {orc.enemyPotion} HP.");
                        }

                    }

                }
                if (currentPlayer.health > 0)
                {
                    Console.Clear();
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine("             YOU HAVE WON!                   ");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("-----------------------------------------------------------------------");
                    Console.WriteLine($"| Congratulations {currentPlayer.name} you have slain the fierce orc.         ");
                    Console.WriteLine("| The Orc fades away through the mist.                                   ");
                    Console.WriteLine("-----------------------------------------------------------------------");
                    
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine("             YOU HAVE LOST!                   ");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("| The mighty Orc has defeated you! ");
                    Console.WriteLine("| Earth is devoured.              ");
                    Console.WriteLine("-----------------------------------");
                    System.Environment.Exit(0);
                }
                // Door 3, 3rd Boss Battle
                Console.WriteLine("\n**************************************************");
                Console.WriteLine("| A large door presents itself to you");
                Console.WriteLine("**************************************************");
                Console.WriteLine("\n");
                for (var i = 20; i >= 0; i--)
                {
                    for (var j = 15; j >= 0; j--)
                    {
                        Console.Write("|" + " ");
                    }
                    Console.WriteLine(" ");

                }
                Console.WriteLine("[You open it with all your might]");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("| The door swings open with a mighty push.                                                 ");
                Console.WriteLine("| You look suspiciously and see a Jack Rabbit sitting on the tree flipping a coin continuosly.  ");
                Console.WriteLine(" [You approach]");
                Console.WriteLine($"| Jack Rabbit: 'Ahh {currentPlayer.name} champion of the Earth Realm' I see you have defeated those before me. ");
                Console.WriteLine("| (Nothing but silence while the Jack Rabbit eagerly flips his coin). Congratulations are in order.");
                Console.WriteLine($"| So {currentPlayer.name} the challenge before you is a game of chance. You have to beat me in coin flipping contest.            ");
                Console.WriteLine("| I will flip the coin 3 times, you have to guess Heads or Tails. My choice is opposite to your guess.                            ");
                Console.WriteLine("| The person with the most correct guesses WINS!                                                                                  ");
                Console.WriteLine("| Winner saves their planet, loser...(Jack Rabbit smiles eagerly). Well we know what happens....                            ");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------");

                var playerScore = 0;
                var jackRabbitScore = 0;
                while (playerScore != 3 && jackRabbitScore != 3)
                {
                    Random random = new Random();
                    Console.WriteLine("==========================================");
                    Console.WriteLine($" Your score = {playerScore} : Jack Rabbit score = {jackRabbitScore} ");
                    Console.WriteLine("==========================================");
                    Console.WriteLine("| Please enter 'T' for [Tails] or 'H' for [Heads] |");
                    Console.Write("> ");
                    var playerChoice = Console.ReadLine();
                    var coinFlip = random.Next(0, 2);

                    if (playerChoice.ToLower() == "h" && coinFlip == 0)
                    {
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("| Jack Rabbit has flipped the coin. ");
                        Console.WriteLine("| You guessed correctly.            ");
                        Console.WriteLine("------------------------------------");
                        playerScore++;
                    }
                    else if (playerChoice.ToLower() == "t" && coinFlip == 1)
                    {
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("| Jack Rabbit flips the coin. ");
                        Console.WriteLine("| You guessed correctly.      ");
                        Console.WriteLine("------------------------------");
                        playerScore++;
                    }
                    else
                    {
                        Console.WriteLine("---------------------------");
                        Console.WriteLine("| You guessed incorrectly. ");
                        Console.WriteLine("---------------------------");
                        jackRabbitScore++;
                    }
                }
                if (jackRabbitScore == 3)
                {
                    var answerToJump = "";
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine($"| I see luck is not on your side, {currentPlayer.name}.");
                    Console.WriteLine($"| How far can a Jack Rabbit jump {currentPlayer.name}? ");
                    Console.WriteLine("---------------------------------------------------------");
                    Console.Write("> ");
                    answerToJump = Console.ReadLine();
                    if (currentPlayer.name == "")
                    {
                        Console.Clear();
                        Console.WriteLine("\n*********************************************");
                        Console.WriteLine("                CORRECT!                   ");
                        Console.WriteLine("***********************************************");
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("| Hmmm, I guess you caught onto my trick question ");
                        Console.WriteLine($"| Congratulations {currentPlayer.name}!");
                        Console.WriteLine("| I knew you would be the one.");
                        Console.WriteLine("| [Jack Rabbit disappears].");
                        Console.WriteLine("--------------------------------------------------");
                        Console.WriteLine("\n********************************************************************************");
                        Console.WriteLine("| 'Celestial being appears'");
                        Console.WriteLine("| You have fought and conquered the mythical creatures which stood before you");
                        Console.WriteLine("| They challenged to see if you were worthy.");
                        Console.WriteLine($"| Congratulations {currentPlayer.name} you have saved Earth.");
                        Console.WriteLine("| 'You are teleported back to Earth.");
                        Console.WriteLine("********************************************************************************");

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n*********************************************");
                        Console.WriteLine("              CORRECT!                   ");
                        Console.WriteLine("***********************************************");
                        Console.WriteLine("\n---------------------------------------------------------------");
                        Console.WriteLine($"| I am not surprised {currentPlayer.name}! ");
                        Console.WriteLine("| ' The Jack Rabbit smiles and dissapears with a gust of wind' ");
                        Console.WriteLine("----------------------------------------------------------------");
                        Console.WriteLine("\n********************************************************************************");
                        Console.WriteLine("| 'Celestial being appears' ");
                        Console.WriteLine("| You have fought and conquered the mythical creatures which stood before you");
                        Console.WriteLine("| They challenged to see if you were worthy.");
                        Console.WriteLine($"| Congratulations {currentPlayer.name} you have saved Earth.");
                        Console.WriteLine("| 'You are teleported back to Earth.");
                        Console.WriteLine("********************************************************************************");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n*********************************************");
                    Console.WriteLine("              YOU HAVE WON!                   ");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("\n********************************************************************************");
                    Console.WriteLine("| 'Celestial being appears'");
                    Console.WriteLine("| You have fought and conquered the mythical creatures which stood before you");
                    Console.WriteLine("| They challenged to see if you were worthy.");
                    Console.WriteLine($"| Congratulations {currentPlayer.name} you have saved Earth.");
                    Console.WriteLine("| 'You are teleported back to Earth.");
                    Console.WriteLine("**********************************************************************************");
                }
            }
        }
    }

}