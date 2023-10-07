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
        public static JackRabbitClass jackRabbit = new();
        public static Orc orc = new();
        public static HoneyBadger honeyBadger = new();



        const string cosmicDweller = "Celestial Being";

        static void Main(string[] args)
        {
            Console.WriteLine("..........................");
            Console.WriteLine("| Doors Of The Unknowing |");
            Console.WriteLine("..........................");

            GameStart();
            TheChallengeAhead();
            DoorsOfUnknowing(Doors, JackRabbitChallenge, OrcChallenge, HoneyBadgerChallenge); // Challenge for the user
        }
        public static void GameStart()
        {
            // Display the introduction messages
            Console.WriteLine("[ You have been teleported to a strange cosmic realm.]");
            Console.WriteLine("[ You are greeted by a Celestial Being, its Aura frightens you but you trust it.]");
            Console.WriteLine("[ Celestial Being: What is thy name Earth being?]                                 ");
            Console.WriteLine(" [ Please enter your name:] ");
            Console.Write("> ");

            // Get the player's name, ensuring it's valid
            currentPlayer.name = GetValidName();

                // Display a welcome message with the player's name
                Console.Clear();
                Console.WriteLine($"[ {currentPlayer.name} ?]");
                Console.WriteLine($"[ Ahhh {currentPlayer.name} the protector of the Earth Realm.]");
        }

        // Get a valid name from the player
        public static string GetValidName()
        {
            var playerName = Console.ReadLine();

            // Keep asking for a valid name until one is provided
            while (string.IsNullOrWhiteSpace(playerName) || !IsNameValid(playerName))
            {
                Console.WriteLine("[ Please enter a valid name]");
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

            // Provide an explanation of the game if the user choose "yes."
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"|{cosmicDweller}: You are in the cosmic realm of the unknowing.                                                 ");
            Console.WriteLine("| Earth is in grave danger of being destroyed. You will have a series of three doors in front of you.          ");
            Console.WriteLine("| Each door will have a challenge behind it.                                                                       ");
            Console.WriteLine("| The challenge difficulty varies, thus, meaning it is left to chance as to what you will face behind these doors. ");
            Console.WriteLine("| You need to complete each challenge successfully in order to save Earth                                          ");
            Console.WriteLine($"| Godspeed {currentPlayer.name}                                                                                 ");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
        }
  

        // Three doors with tasks of random probability behind it.
        public static void DoorsOfUnknowing(Action doors, Action jackChal, Action orcChal, Action honChal)
        {
            Console.WriteLine("***************************************");
            Console.WriteLine("| Please choose one of the three doors.");
            Console.WriteLine("***************************************");
            doors();
            Console.Write("[Door 1 = [one] | [1].]");
            Console.Write("[Door 2 = [two] | [2].]");
            Console.Write("[Door 3 = [three] | [3].]");
            Console.WriteLine("\n[Please type your option below:]");
            Console.Write("> ");
            var doorChoice = Console.ReadLine();

            
            if (doorChoice.ToLower() == "one" || doorChoice == "1")
            {
                Console.Clear();
                // Door 1, 1st Boss
                jackChal();

                // Door 1, 2nd Boss Battle
                orcChal();

                // Door 1, 3rd Boss Battle
                honChal();


            } 
            else if (doorChoice.ToLower() == "two" || doorChoice == "2")
            {
                //Door 2, 1st Boss Battle
                orcChal();

                // Door 2, 2nd Boss Battle
                honChal();

                // Door 2, 3rd Boss Battle
                jackChal();
            }
            else // Door 3
            {
                // Door 3, 1st Boss Battle
                honChal();

                // Door 3, 2nd Boss Battle
                orcChal();
                
                // Door 3, 3rd Boss Battle
                jackChal();
            }
        }
        private static void Doors()
        {
            // Displays doors
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

        // JackRabbit
        public static void JackRabbitChallenge()
        {
            JackRabbitClass.Explanation(currentPlayer);

            var playerScore = 0;
            var jackRabbitScore = 0;

            const int scoreThreshold = 3;
            Random random = new();

            DisplayGameStatusJack(playerScore, jackRabbitScore);

            while (playerScore < scoreThreshold && jackRabbitScore < scoreThreshold)
            {
                Console.WriteLine($"[ Your score = {playerScore} : Jack Rabbit score = {jackRabbitScore}]");
                Console.WriteLine("[ Please enter 'T' for (Tails) or 'H' for (Heads)]");
                Console.Write("> ");
                var playerChoice = Console.ReadLine();
                int coinFlip = random.Next(0, 2);

                if ((playerChoice.Equals("H", StringComparison.OrdinalIgnoreCase) || 
                    playerChoice.Equals("T", StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("[ Jack Rabbit has flipped the coin.]");
                    Console.WriteLine("[ You guessed correctly !]");
                    playerScore++;
                }
                else
                {
                    Console.WriteLine("[ You guessed incorrectly.]");
                    jackRabbitScore++;
                }
            }

            if (jackRabbitScore == scoreThreshold)
            {
                Console.Clear();
                Console.WriteLine("\n*********************************************");
                Console.WriteLine("             YOU HAVE LOST!                   ");
                Console.WriteLine("***********************************************");
                Console.WriteLine($"[ I see luck is not on your side, {currentPlayer.name}.]");
                Console.WriteLine("[ Let me ask you this.]");
                Console.WriteLine($"[ How far can a Jack Rabbit jump {currentPlayer.name}?]");
                string answerToJump;
                int number;
                bool isNumeric;
                    Console.WriteLine("[ Please type your answer:]");
                    Console.Write("> ");
                    answerToJump = Console.ReadLine();
                    isNumeric = int.TryParse(answerToJump, out number)


                    if (currentPlayer.name == String.Empty)
                    {
                        Console.WriteLine("[ Hmmm, I guess you caught onto my trick question.]");
                        Console.WriteLine("[ You may pass.]");
                    }
                    else if(isNumeric)
                    {
                        Console.WriteLine("[ You are correct, you may pass!]");
                    }
                    else
                    {
                        Console.WriteLine("[ That's not correct, try again.]");
                    }
            }

            Console.Clear();
            Console.WriteLine(" YOU HAVE WON! ");
            Console.WriteLine("\n");
            Console.WriteLine($"[ Congratulations {currentPlayer.name}, you have defeated the Jack Rabbit!]");
            Console.WriteLine("[ A large door appears before you.]");
            Console.WriteLine("\n");
            Door();
        }
        private static void Door()
        {
            for (int i = 20; i >= 0; i--)
            {
                for (int j = 15; j >= 0; j--)
                {
                    Console.Write("|" + " ");
                }
                Console.WriteLine("");
            }
        }
        public static void DisplayGameStatusJack(int playerScore, int jackRabbitScore)
        {
            Console.WriteLine($" [Your score = {playerScore} : Jack Rabbit score = {jackRabbitScore} ]");
        }

        //Orc
        public static void OrcChallenge()
        {
            Console.WriteLine("[ You proceed to the door in front of you.]");
            Console.WriteLine("[ You open the door slowly.]");
            Console.WriteLine("[ An Orc appears, sitting on a rock waiting.]");
            Console.WriteLine("[ He looks at you with red glowing eyes.]");
            Console.WriteLine("[ He says: Prepare to fight!]");

            // Initialize player and enemy attributes
            InitializePlayerAttributes();
            InitializeOrcAttributes();

            // Random number generator for Orc's actions
            Random orcRandom = new();

            // Orc Fight
            while (currentPlayer.health > 0 && orc.health > 0)
            {
                DisplayFightStatus();

                Console.WriteLine("\n--Your Turn--");
                Console.WriteLine("Press [A] to attack or [H] to heal");
                Console.WriteLine("--------------------");
                Console.WriteLine("[(A)ttack | (H)eal]");
                Console.WriteLine("--------------------");
                Console.Write("> ");
                var choice = Console.ReadLine().ToLower();
                if (choice == "a")
                {
                    PerformPlayerAttack();
                }
                else if (choice == "h")
                {
                    PerformPlayerHeal();
                }

                // Orc's Turn
                if (orc.health > 0)
                {
                    PerformOrcAction(orcRandom);
                }
            }

            // Handle the game result
            if (currentPlayer.health > 0)
            {
                HandleWinScenario();
            }
            else
            {
                HandleLossScenario();
            }
        }

        private static void InitializePlayerAttributes()
        {
            // Initialize player's attributes
            currentPlayer.health = 20;
            currentPlayer.attack = 5;
            currentPlayer.potion = 4;
        }

        private static void InitializeOrcAttributes()
        {
            // Initialize Orc's attributes
            orc.health = 10;
            orc.enemyAttack = 3;
            orc.enemyPotion = 2;
        }


        private static void DisplayFightStatus()
        {
            Console.WriteLine($"[ {currentPlayer.name} = {currentPlayer.health} HP | Orc = {orc.health} HP]");
        }

        private static void PerformPlayerAttack()
        {
            Console.Clear();
            orc.health -= currentPlayer.attack;
            Console.WriteLine($"[ {currentPlayer.name} attacks the Orc! Orc takes ({currentPlayer.attack}) damage]");
        }

        private static void PerformPlayerHeal()
        {
            Console.Clear();
            currentPlayer.health += currentPlayer.potion;
            Console.WriteLine($"[ {currentPlayer.name} heals ({currentPlayer.potion}) HP]");
        }

        private static void PerformOrcAction(Random orcRandom)
        {
            Console.WriteLine("\n--Orc's Turn--");
            var orcChoice = orcRandom.Next(0, 2);

            if (orcChoice == 0)
            {
                currentPlayer.health -= orc.enemyAttack;
                Console.WriteLine($"[ The Orc attacks you and deals {orc.enemyAttack} damage!]");
            }
            else
            {
                orc.health += orc.enemyPotion;
                Console.WriteLine($"The Orc has healed {orc.enemyPotion} HP");
            }
        }

        private static void HandleWinScenarioOrc()
        {
            Console.Clear();
            Console.WriteLine(" YOU HAVE WON!");
            Console.WriteLine($"[ Congratulations {currentPlayer.name} you have slain the fierce orc.]");
            Console.WriteLine("[ Another door appears before you. ]");
            Console.WriteLine("\n");
            Door();
            Console.WriteLine("You walk through it.....");
        }

        private static void HandleLossScenarioOrc()
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

        // HoneyBadger

        private static void HoneyBadgerChallenge()
        {
            InitializeScores();

            Random honRandom = new();

            DisplayIntroduction();

            while (currentPlayer.score != 3 && honeyBadger.score != 3)
            {
                DisplayGameStatus();

                Console.WriteLine("\n[Please enter 'r' for (Rock) | 'p' for (Paper) | 's' for (Scissors)]");
                Console.Write("> ");
                var userChoice = Console.ReadLine();

                int honeyBadgerChoice = honRandom.Next(0, 3);

                PerformRound(userChoice, honeyBadgerChoice);
            }

            HandleGameResult();
        }

        private static void InitializeScores()
        {
            currentPlayer.score = 0;
            honeyBadger.score = 0;
        }

        private static void DisplayIntroduction()
        {
            Console.WriteLine("[ You open the door and see a Honey Badger lying on a lily pad.]");
            Console.WriteLine($"[ Ahhh, {currentPlayer.name}. I see you have slain that dimwitted Orc.]");
            Console.WriteLine("[ Congratulations are in order, but let me warn you. I am far deadlier.]");
            Console.WriteLine("[ Me and you will face off to the death in a game of, wait for it!]");
            Console.WriteLine("[ ROCK!]");
            Console.WriteLine("[ PAPER!]");
            Console.WriteLine("[ SCISSORS!]");
        }

        private static void DisplayGameStatus()
        {
            Console.WriteLine($"[ {currentPlayer.name} = {currentPlayer.score} | Honey Badger = {honeyBadger.score}.]");
        }

        private static void PerformRound(string userChoice, int honeyBadgerChoice)
        {
            Console.WriteLine($"\nHoney Badger chooses {GetChoiceName(honeyBadgerChoice)}.");

            switch (userChoice.ToLower())
            {
                case "r":
                    HandleChoice('r', honeyBadgerChoice);
                    break;
                case "p":
                    HandleChoice('p', honeyBadgerChoice);
                    break;
                case "s":
                    HandleChoice('s', honeyBadgerChoice);
                    break;
                default:
                    Console.WriteLine("{ Invalid choice. Try again.}");
                    break;
            }
        }

        private static void HandleChoice(char userChoice, int honeyBadgerChoice)
        {
            if (userChoice == GetChoiceName(honeyBadgerChoice))
            {
                Console.WriteLine("[ This round is a draw.]");
            }
            else if ((userChoice == 'r' && GetChoiceName(honeyBadgerChoice) == 's') ||
                     (userChoice == 'p' && GetChoiceName(honeyBadgerChoice) == 'r') ||
                     (userChoice == 's' && GetChoiceName(honeyBadgerChoice) == 'p'))
            {
                Console.WriteLine("You win this round!");
                currentPlayer.score++;
            }
            else
            {
                Console.WriteLine("You lose this round!");
                honeyBadger.score++;
            }
        }

        private static char GetChoiceName(int choice) // switch expression
        {
            return choice switch
            {
                0 => 'r',
                1 => 'p',
                2 => 's',
                _ => ' ',
            };
        }

        private static void HandleGameResult()
        {
            if (currentPlayer.score == 3)
            {
                HandleWinScenario();
            }
            else
            {
                HandleLossScenario();
            }
        }

        private static void HandleWinScenario()
        {
            Console.Clear();
            Console.WriteLine("\n*********************************************");
            Console.WriteLine("             YOU HAVE WON!                   ");
            Console.WriteLine("***********************************************");
            Console.WriteLine("\n----------------------------------------------------------------------------");
            Console.WriteLine($"| Congratulations {currentPlayer.name}, you have beat me fair and square.");
            Console.WriteLine($"| I should have known you would be the one.");
            Console.WriteLine("-----------------------------------------------------------------------------");

            Console.WriteLine("********************************************************************************");
            Console.WriteLine("| 'Celestial being appears'");
            Console.WriteLine("| You have fought and conquered the mythical creatures which stood before you");
            Console.WriteLine("| They challenged to see if you were worthy.");
            Console.WriteLine($"| Congratulations {currentPlayer.name}, you have saved Earth.");
            Console.WriteLine("| 'You are teleported back to Earth.");
            Console.WriteLine("********************************************************************************");
        }

        private static void HandleLossScenario()
        {
            Console.Clear();
            Console.WriteLine("\n*********************************************");
            Console.WriteLine("             YOU HAVE LOST!                   ");
            Console.WriteLine("***********************************************");
            Console.WriteLine("\n---------------------------------------------------------------");
            Console.WriteLine($"It seems the Earth Champion {currentPlayer.name} has lost");
            Console.WriteLine("Haha, who saw that coming.");
            Console.WriteLine($"Okay, I will give you one last chance, {currentPlayer.name}.");
            Console.WriteLine("Who wins in a fight between a Snake and a Honey Badger.");
            Console.WriteLine("---------------------------------------------------------------");
            Console.Write("> ");
            var answer = Console.ReadLine();

            if (answer.ToLower() == "honey badger")
            {
                HandleWinScenario();
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
                Console.WriteLine("You should have considered your answer first.");
                Console.WriteLine("YOU HAVE BEEN DEFEATED.");
                Console.WriteLine("Earth is destroyed.");
                Console.WriteLine("-------------------------------------------------------");
                System.Environment.Exit(0);
            }
        }
    }

}