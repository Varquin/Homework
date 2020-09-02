using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using System.Linq;
using System.Drawing;

namespace LetsBreakIt
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int choice = 0;

        Main:
            Console.WriteLine("Welcome to the place you can do things");
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

            if (choice == 1)
            {
                DiceRoll();
                goto Main;
            }
            else if (choice == 2)
            {
                InBed();
                Console.WriteLine();
                goto Main;
            }
            else if (choice == 3)
            {
                int number = 0;

                Console.WriteLine();
            tryagain:
                Console.Write("Enter any number: ");
                input = Console.ReadLine();
                check = Int32.TryParse(input, out number);
                if (number > 0)
                {

                    Factorial(number);
                    Console.WriteLine();
                    goto Main;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must enter a number greater then 0.");
                    Console.WriteLine("Please try agian.");
                    Console.ResetColor();
                    goto tryagain;
                }
            }
            else if (choice == 4)
            {

                Slamit();
                goto Main;

            }
            else if (choice == 5)
            {
                Reverse();
                goto Main;
            }
            else if (choice == 6)
            {
                int howMany = 0;

                Console.WriteLine();
                Console.WriteLine("I heard you want to flip some coins");
            idiot:
                Console.Write("How many times do you want to flip the coin? ");
                input = Console.ReadLine();
                check = Int32.TryParse(input, out howMany);
                if (howMany > 0)
                {
                    Coinflip(howMany);
                    Console.WriteLine();
                    goto Main;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please dont be rude.");
                    Console.ResetColor();
                    goto idiot;
                }
            }
            else if (choice == 7)
            {
                Madlib();
                Console.WriteLine();
                goto Main;
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That's not an option.");
                Console.WriteLine();
                Console.ResetColor();
                goto Main;
            }
        }
        static void DiceRoll()
        {
            Random rnd = new Random();
            string input = "";
            int howMany = 0;
            int sides = 0;
        startover:
            string userinput = "";

            Console.WriteLine("Lests Roll Some Dice!");
            Console.WriteLine();
            Console.WriteLine();
        dongs:
            Console.Write("How many times do you want to roll? ");

            input = Console.ReadLine();
            bool check = Int32.TryParse(input, out howMany);

            if (howMany < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Really?");
                Console.ResetColor();
                goto dongs;
            }
        slongs:
            Console.Write("How many sides do you want your dice to have? ");

            input = Console.ReadLine();
            check = Int32.TryParse(input, out sides);


            if (sides <= 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The dice needs sides dumbass.");
                Console.ResetColor();
                goto slongs;
            }
            else if (sides == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no 3 sided die....");
                Console.ResetColor();
                goto slongs;
            }
            else if (sides == 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine("Dice dont have 2 sides so I guess I will flip a coin instead");
                Console.WriteLine();
                Console.ResetColor();
                Coinflip(howMany);
                goto bongs;
            }

            Console.WriteLine();
            for (int i = 0; i < howMany; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(rnd.Next(1, sides + 1));
                Console.ResetColor();
            }
        bongs:
            Console.WriteLine();
            Console.WriteLine("Play again?");
            Console.Write("Type Y to play again any other key to go to Main Menu ");

            userinput = Console.ReadLine().ToUpper();
            if (userinput == "Y")
            {
                goto startover;
            }
            else
            {
                return;
            }

        }
        static int Coinflip(int howMany)
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
            return results;
        }
        static string InBed()
        {
            string input = "";
            string joke = "";

            Console.WriteLine();
            Console.Write("Enter as phrase: ");
            input = Console.ReadLine();
            joke = input + " in bed!";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine(joke);
            Console.WriteLine();
            Console.ResetColor();
            return joke;
        }
        static double Factorial(int number)
        {
            double result = 1;
            while (number != 1)
            {
                result = result * number;
                number = number - 1;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("The factorial is " + result);
            Console.ResetColor();
            return result;
        }
        static string Madlib()
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

            story = "He " + verb1 + " his " + bodypart1 + " on my " + bodypart2 + ". Then I " + verb2 + " my " + bodypart3 + " all over your " + bodypart4 + ", fuck yea it feels "
                + adjective1 + ". ";

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine(story);
            Console.ResetColor();
            return story;
        }
        static string Slamit()
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
            return newPhrase;
        }
        static string Reverse()
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
            return newPhrase1;
        }
    }
}

