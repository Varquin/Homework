using System;
using System.Linq;
namespace LetsPlay
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                MainMenu();
            } 
            while (ContinueApp());
        }
        static void MainMenu()
        {
            string input = "";
            int choice = 0;

            Console.WriteLine();
            Console.WriteLine("Welcome to the Place of Things");
            Console.WriteLine();
            Console.WriteLine("1 - Dice Roller");
            Console.WriteLine("2 - 'in bed' joke");
            Console.WriteLine("3 - Factorial Calculator");
            Console.WriteLine("4 - Lets obfuscate yo shit");
            Console.WriteLine("5 - Decoder");
            Console.WriteLine("6 - Coin Flipper");
            Console.WriteLine("7 - NSFW Madlib");
            Console.WriteLine();
            input = Console.ReadLine();
            bool check = Int32.TryParse(input, out choice);
            switch (choice)
            {
                case 1:
                    DiceRoll();
                    break;
                case 2:
                    InBed();
                    break;
                case 3:
                    Factorial();
                    break;
                case 4:
                    Slamit();
                    break;
                case 5:
                    Reverse();
                    break;
                case 6:
                    int howMany = 0;
                    howMany = GetHowMany();
                    Coinflip(howMany);
                    break;
                case 7:
                    Madlib();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please choose from the list");
                    Console.ResetColor();
                    break;
            }
        }

        static void Coinflip(int howMany)
        {
            Random Rand = new Random();
            int heads = 0;
            int tails = 0;
            int results = 0;

            for (int i = 0; i < howMany; i++)
            {
                results = Rand.Next(0, 2);
                if (results == 1)
                {
                    heads++;
                }
                else
                {
                    tails++;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("Heads was flipped {0} times.", heads);
            Console.WriteLine("Tails was flipped {0} times.", tails);
            Console.WriteLine();
            Console.WriteLine("Thanks for playing.");
            Console.ResetColor();
        }
        static void InBed()
        {
            string input = "";
            string joke = "";

            Console.WriteLine();
            Console.Write("Enter as phrase: ");
            input = Console.ReadLine();
            joke = input.Trim() + " in bed!";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine(joke);
            Console.WriteLine();
            Console.ResetColor();
        }
        static void Madlib()
        {
            string story;
            string verb1;
            string verb2;
            string bodypart1;
            string bodypart2;
            string bodypart3;
            string bodypart4;
            string adjective1;

            Console.Write("Please enter a verb ending in s: ");
            verb1 = Console.ReadLine();
            Console.Write("Please enter a verb: ");
            verb2 = Console.ReadLine();
            Console.Write("Please enter a bodypart: ");
            bodypart1 = Console.ReadLine();
            Console.Write("Please enter another bodypart: ");
            bodypart2 = Console.ReadLine();
            Console.Write("Please enter another bodypart: ");
            bodypart3 = Console.ReadLine();
            Console.Write("Please enter another bodypart: ");
            bodypart4 = Console.ReadLine();
            Console.Write("Please enter an adjective: ");
            adjective1 = Console.ReadLine();
            Console.Write("Please enter an adjective: ");
            Console.WriteLine();

            story = "He " + verb1.Trim() + " his " + bodypart1.Trim() + " on my " + bodypart2.Trim() + ". Then I " + verb2.Trim() + " my " + bodypart3.Trim() + " all over your " + bodypart4.Trim() + ", fuck yea it feels "
                + adjective1.Trim() + ". ";

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine(story);
            Console.ResetColor();
        }
        static void Slamit()
        {
            string phrase = "";

            Console.WriteLine();
            Console.Write("Enter a phase: ");
            phrase = Console.ReadLine();
            string newPhrase = new string(phrase.Select(replace => (char)(replace + 1)).ToArray());
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine(newPhrase);
            Console.WriteLine();
            Console.WriteLine("If you want to see what this says please copy it and paste it in option 5 of the main menu.");
            Console.WriteLine();
            Console.ResetColor();
        }
        static void Reverse()
        {
            string phrase1 = "";

            Console.WriteLine();
            Console.Write("Please paste the text: ");
            phrase1 = Console.ReadLine();
            string newPhrase1 = new string(phrase1.Select(replace => (char)(replace + -1)).ToArray());
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine(newPhrase1);
            Console.WriteLine();
            Console.ResetColor();
        }
        #region DiceRoll
        static void DiceRoll()
        {
            Random rnd = new Random();
            int howMany = 0;
            int sides = 0;

            Console.WriteLine("Lests Roll Some Dice!");
            Console.WriteLine();
            Console.WriteLine();
            howMany = GetHowMany();
            sides = GetSides(howMany);
            Console.WriteLine();
            LetsRoll(howMany, sides);
        }

        static int GetHowMany()
        {
            string input = "";
            int howMany = 0;

            Console.WriteLine();
            Console.Write("How many? ");
            input = Console.ReadLine();
            bool check = Int32.TryParse(input, out howMany);
            if (howMany < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Really?");
                Console.ResetColor();
                howMany = GetHowMany();
            }

            return howMany;
        }
        static int GetSides(int howMany)
        {
            string input = "";
            int sides = 0;

            Console.WriteLine("How many sides do you want your dice to have?");
            input = Console.ReadLine();
            bool check = Int32.TryParse(input, out sides);

            if (sides <= 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The dice needs sides dumbass.");
                Console.ResetColor();
                sides = GetSides(howMany);
            }
            else if (sides == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no 3 sided die....");
                Console.ResetColor();
                sides = GetSides(howMany);
            }
            else if (sides == 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine("Dice dont have 2 sides so I guess I will flip a coin instead");
                Console.WriteLine();
                Console.ResetColor();
                Coinflip(howMany);
                MainMenu();
            }
            return sides;
        }
        static void LetsRoll(int howMany, int sides)
        {
            Random rnd = new Random();

            for (int i = 0; i < howMany; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(rnd.Next(1, sides + 1));
                Console.ResetColor();
            }
            return;
        }
        #endregion
        #region Factorial
        static void Factorial()
        {
            int result = 1;
            int number = 0;

            number = GetNumber();

            while (number != 1)
            {
                result = result * number;
                number = number - 1;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("The factorial is " + result);
            Console.ResetColor();
        }

        static int GetNumber()
        {
            int number = 0;
            string input = "";

            Console.Write("Enter any number: ");
            input = Console.ReadLine();
            bool check = Int32.TryParse(input, out number);
            if (number < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You must enter a number greater then 0.");
                Console.WriteLine("Please try agian.");
                Console.ResetColor();
                number = GetNumber();
            }
            return number;
        }
        #endregion
        static bool ContinueApp()
        {
            bool playApp = true;
            Console.WriteLine("Presss any key to return to main menu or hit esc to exit.");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                playApp = false;
            }
            return playApp;
        }
    }
}
