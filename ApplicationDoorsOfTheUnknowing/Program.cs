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
            DoorsOfUnknowing(); // Challenge for the user
            FinalScenario();
        }
        public static void GameStart()
        {
            // Display the introduction messages
            Console.WriteLine("[ You have been teleported to a strange cosmic realm.]");
            Console.WriteLine("[ You are greeted by a Celestial Being, its Aura frightens you but you trust it.]");
            Console.WriteLine("[ Celestial Being: What is thy name Earth being?]                                 ");
            Console.WriteLine("[ Please enter your name:] ");
            Console.Write("> ");

            // Get the player's name, ensuring it's valid
            currentPlayer.Name = GetValidName();

            // Display a welcome message with the player's name
            Console.Clear();
            Console.WriteLine($"[ {currentPlayer.Name} ?]");
            Console.WriteLine($"[ Ahhh {currentPlayer.Name} the protector of the Earth Realm.]");
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
            Console.WriteLine($"\n[ {cosmicDweller}: I have summoned you here today as the champion of your realm.]");
            Console.WriteLine($"[ {currentPlayer.Name}, you have a great challenge ahead of you.]");
            Console.WriteLine("[ Do you accept what lies ahead?]");
            Console.WriteLine("\n[ Please type: (Yes) to continue or (No) to be transported back to Earth]");
            Console.Write("> ");

            var choice = Console.ReadLine().ToLower();

            if (choice == "yes")
            {
                Console.Clear();
                Console.WriteLine("[ I expect nothing less than the champion of the Earth Realm.]");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"[ Goodbye {currentPlayer.Name}.]");
                Console.WriteLine("[ You have been transported back to Earth. Another champion has been chosen in your place.]");
                System.Environment.Exit(0);
            }

            // Provide an explanation of the game if the user choose "yes."
            Console.WriteLine($"[ {cosmicDweller}: You are in the cosmic realm of the unknowing.]");
            Console.WriteLine("[ Earth is in grave danger of being destroyed. You will have a series of three doors in front of you.]");
            Console.WriteLine("[ Each door will have a challenge behind it.]");
            Console.WriteLine("[ The challenge difficulty varies, thus, meaning it is left to chance as to what you will face behind these doors.]");
            Console.WriteLine("[ You need to complete each challenge successfully in order to save Earth.]");
            Console.WriteLine($"[ Godspeed {currentPlayer.Name}.]");
        }


        // Three doors with tasks of random probability behind it.
        public static void DoorsOfUnknowing()
        {
            var validChoice = false;

            do
            {
                Console.WriteLine("[ Please choose one of the three doors.]");
                DoorsImage();
                Console.Write(" [Door 1 = [one] | [1]");
                Console.Write(" [Door 2 = [two] | [2]");
                Console.Write(" [Door 3 = [three] | [3]");
                Console.WriteLine("\n[ Please type your option below:]");
                Console.Write("> ");
                var doorChoice = Console.ReadLine().ToLower();

                switch (doorChoice)
                {
                    case "one":
                    case "1":
                        // Door 1
                        Door1();
                        validChoice = true;
                        break;
                    case "two":
                    case "2":
                        // Door 2
                        Door2();
                        validChoice = true;
                        break;
                    case "three":
                    case "3":
                        // Door 3
                        Door3();
                        validChoice = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose one of the doors.");
                        break;
                }
            } while (!validChoice);
        }
        private static void DoorsImage()
        {
            Console.WriteLine("\n");
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
        public static void Door1()
        {
            // Door 1, 1st Boss
            JackRabbitChallenge();

            // Door 1, 2nd Boss Battle
            OrcChallenge();

            // Door 1, 3rd Boss Battle
            HoneyBadgerChallenge();
        }
        public static void Door2()
        {
            //Door 2, 1st Boss Battle
            OrcChallenge();

            // Door 2, 2nd Boss Battle
            HoneyBadgerChallenge();

            // Door 2, 3rd Boss Battle
            JackRabbitChallenge();
        }
        public static void Door3()
        {
            // Door 3, 1st Boss Battle
            HoneyBadgerChallenge();

            // Door 3, 2nd Boss Battle
            OrcChallenge();

            // Door 3, 3rd Boss Battle
            JackRabbitChallenge();
        }

        // JackRabbit
        public static void JackRabbitChallenge()
        {
            JackRabbitClass.Explanation(currentPlayer);

            var playerScore = 0;
            var jackRabbitScore = 0;

            const int scoreThreshold = 3;
            Random random = new();

            while (playerScore < scoreThreshold && jackRabbitScore < scoreThreshold)
            {
                DisplayGameStatusJack(playerScore, jackRabbitScore);
                Console.WriteLine("[ Please enter 'T' for (Tails) or 'H' for (Heads)]");
                Console.Write("> ");
                var playerChoice = Console.ReadLine().ToLower();
                int coinFlip = random.Next(0, 2);

                var coinChoice = (coinFlip == 0) ? "H" : "T"; // Determine Jack Rabbit's choice

                if ((playerChoice.Equals(coinChoice, StringComparison.OrdinalIgnoreCase) ||
                    playerChoice.Equals(coinChoice, StringComparison.OrdinalIgnoreCase)))
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
                HanldeLossScenarioJack();
                string answerToJump;
                bool isNumeric;
                Console.WriteLine("[ Please type your answer:]");
                Console.Write("> ");
                answerToJump = Console.ReadLine();
                isNumeric = int.TryParse(answerToJump, out int number);


                if (currentPlayer.Name == string.Empty)
                {
                    Console.WriteLine("[ Hmmm, I guess you caught onto my trick question.]");
                    Console.WriteLine("[ You may pass.]");
                }
                else if (isNumeric)
                {
                    Console.WriteLine("[ You are correct, you may pass!]");
                }
                else
                {
                    Console.WriteLine("[ That's not correct! ]");
                    Console.WriteLine($"[You lose {currentPlayer.Name}!");
                    System.Environment.Exit(0); 
                }
            }
            HandleWinScenarioDoor();
        }
        private static void DoorImage()
        {
            for (int i = 10; i >= 0; i--)
            {
                for (int j = 5; j >= 0; j--)
                {
                    Console.Write("|" + " ");
                }
                Console.WriteLine("");
            }
        }
        private static void DisplayGameStatusJack(int playerScore, int jackRabbitScore)
        {
            Console.WriteLine($"\n[ Your score = {playerScore} : Jack Rabbit score = {jackRabbitScore} ]");
        }
        private static void HandleWinScenarioDoor()
        {
            Console.Clear();
            Console.WriteLine(" YOU HAVE WON! ");
            Console.WriteLine("\n");
            Console.WriteLine($"[ Congratulations {currentPlayer.Name}, you have defeated the enemy!]");
            Console.WriteLine("[ A large door appears before you.]");
            Console.WriteLine("\n");
            DoorImage();
        }
        private static void HanldeLossScenarioJack()
        {
            Console.Clear();
            Console.WriteLine(" YOU HAVE LOST! ");
            Console.WriteLine($"[ I see luck is not on your side, {currentPlayer.Name}.]");
            Console.WriteLine("[ Let me ask you this.]");
            Console.WriteLine($"[ How far can a Jack Rabbit jump {currentPlayer.Name}?]");
        }


        // Orc
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
            while (currentPlayer.Health > 0 && orc.Health > 0)
            {
                DisplayFightStatusOrc();

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
                if (orc.Health > 0)
                {
                    PerformOrcAction(orcRandom);
                }
            }

            // Handle the game result
            if (currentPlayer.Health > 0)
            {
                HandleWinScenarioOrc();
            }
            else
            {
                HandleLossScenarioOrc();
            }
        }

        private static void InitializePlayerAttributes()
        {
            // Initialize player's attributes
            currentPlayer.Health = 20;
            currentPlayer.Attack = 5;
            currentPlayer.Potion = 4;
        }

        private static void InitializeOrcAttributes()
        {
            // Initialize Orc's attributes
            orc.Health = 10;
            orc.EnemyAttack = 3;
            orc.EnemyPotion = 2;
        }


        private static void DisplayFightStatusOrc()
        {
            Console.WriteLine($"[ {currentPlayer.Name} = {currentPlayer.Health} HP | Orc = {orc.Health} HP]");
        }

        private static void PerformPlayerAttack()
        {
            Console.Clear();
            orc.Health -= currentPlayer.Attack;
            Console.WriteLine($"[ {currentPlayer.Name} attacks the Orc! Orc takes ({currentPlayer.Attack}) damage]");
        }

        private static void PerformPlayerHeal()
        {
            Console.Clear();
            currentPlayer.Health += currentPlayer.Potion;
            Console.WriteLine($"[ {currentPlayer.Name} heals ({currentPlayer.Potion}) HP]");
        }

        private static void PerformOrcAction(Random orcRandom)
        {
            Console.WriteLine("\n--Orc's Turn--");
            var orcChoice = orcRandom.Next(0, 2);

            if (orcChoice == 0)
            {
                currentPlayer.Health -= orc.EnemyAttack;
                Console.WriteLine($"[ The Orc attacks you and deals {orc.EnemyAttack} damage!]");
            }
            else
            {
                orc.Health += orc.EnemyPotion;
                Console.WriteLine($"The Orc has healed {orc.EnemyPotion} HP");
            }
        }

        private static void HandleWinScenarioOrc()
        {
            Console.Clear();
            Console.WriteLine(" YOU HAVE WON!");
            Console.WriteLine($"[ Congratulations {currentPlayer.Name} you have slain the fierce orc.]");
            Console.WriteLine("[ Another door appears before you. ]");
            Console.WriteLine("\n");
            DoorImage();
            Console.WriteLine("You walk through it.....");
        }

        private static void HandleLossScenarioOrc()
        {
            Console.Clear();
            Console.WriteLine(" YOU HAVE LOST! ");
            Console.WriteLine("[ You have been destroyed!");
            Console.WriteLine("[ Earth is devoured.              ");
            System.Environment.Exit(0);
        }

        // HoneyBadger

        private static void HoneyBadgerChallenge()
        {
            InitializeScoresHon();

            Random honRandom = new();

            DisplayIntroductionHon();

            while (currentPlayer.Score != 3 && honeyBadger.Score != 3)
            {
                DisplayGameStatusHon();

                Console.WriteLine("\n[Please enter 'r' for (Rock) | 'p' for (Paper) | 's' for (Scissors)]");
                Console.Write("> ");
                var userChoice = Console.ReadLine();

                var honeyBadgerChoice = honRandom.Next(0, 3);

                PerformRound(userChoice, honeyBadgerChoice);
            }

            HandleGameResult();
        }

        private static void InitializeScoresHon()
        {
            currentPlayer.Score = 0;
            honeyBadger.Score = 0;
        }

        private static void DisplayIntroductionHon()
        {
            Console.WriteLine("[ You open the door and see a Honey Badger lying on a lily pad.]");
            Console.WriteLine($"[ Ahhh, {currentPlayer.Name}. I see you have slain the creature before me.]");
            Console.WriteLine("[ Congratulations are in order, but let me warn you. I am far deadlier.]");
            Console.WriteLine("[ Me and you will face off to the death in a game of, wait for it!]");
            Console.WriteLine("[ ROCK!]");
            Console.WriteLine("[ PAPER!]");
            Console.WriteLine("[ SCISSORS!]");
        }

        private static void DisplayGameStatusHon()
        {
            Console.WriteLine($"[ {currentPlayer.Name} = {currentPlayer.Score} | Honey Badger = {honeyBadger.Score}.]");
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
                currentPlayer.Score++;
            }
            else
            {
                Console.WriteLine("You lose this round!");
                honeyBadger.Score++;
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
            if (currentPlayer.Score == 3)
            {
                HandleWinScenarioHon();
            }
            else
            {
                HandleLossScenarioFinal();
            }
        }

        private static void HandleWinScenarioHon()
        {
            Console.Clear();
            Console.WriteLine(" YOU HAVE WON!");
            Console.WriteLine($"[ Congratulations {currentPlayer.Name}, you have beat me fair and square.]");
            Console.WriteLine($"[ I should have known you would be the one.]");
        }

        private static void HandleLossScenarioFinal()
        {
            Console.Clear();
            Console.WriteLine(" YOU HAVE LOST! ");
            Console.WriteLine($"[ It seems the Earth Champion {currentPlayer.Name} has lost]");
            Console.WriteLine("Haha, who saw that coming.");
            Console.WriteLine($"Okay, I will give you one last chance, {currentPlayer.Name}.");
            Console.WriteLine("Who wins in a fight between a Snake and a Honey Badger.");
            Console.Write("> ");
            var answer = Console.ReadLine();

            if (answer.ToLower() == "honey badger")
            {
                HandleWinScenarioHon();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(" WRONG ANSWER!");
                Console.WriteLine("\n");
                Console.WriteLine("[ Errr, WRONG!]");
                Console.WriteLine("[ You should have considered your answer first.]");
                Console.WriteLine(" YOU HAVE BEEN DEFEATED!");
                Console.WriteLine("[ Earth is destroyed.]");
                System.Environment.Exit(0);
            }
        }
        private static void FinalScenario()
        {
            Console.Clear();
            Console.WriteLine($"[ {cosmicDweller} appears.]");
            Console.WriteLine("[ You have fought and conquered the mythical creatures which stood before you.]");
            Console.WriteLine("[ They challenged to see if you were worthy.]");
            Console.WriteLine($"[ Congratulations {currentPlayer.Name}, you have saved Earth.]");
            Console.WriteLine("[ You are teleported back to Earth.]");
        }
    }

}