using System;
using System.Collections.Generic;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArray = new int[0];
            numbersArray = ArrayGen();
            string[] stringArray = new string[5];
            List<int> numbersList = new List<int>();
            foreach (int num in numbersArray)
            {
                numbersList.Add(num);
            }
            PrintIt(numbersArray);
            Console.WriteLine("");
            ArraySum(numbersArray);
            Console.WriteLine("");
            ListAverage(numbersList);
            Console.WriteLine("");
            SortArray(numbersArray);
            Console.WriteLine("");
            MinList(numbersList);
            Console.WriteLine("");
            DoesExist(numbersArray);
            Console.WriteLine("");
            stringArray = StringArrayGen();
            Console.WriteLine("");
            ValueExist(stringArray);
            Console.WriteLine("");
            Longest(stringArray);
            Console.WriteLine("");
            StringIndex();
            Console.WriteLine("");
            ArrayIndex(numbersArray);
            Console.WriteLine("");
            History(numbersArray);



        }
        public static int[] ArrayGen()
        {
            string input;

            Console.WriteLine("How many numbers would you like in the array?");
            input = Console.ReadLine();
            bool check = Int32.TryParse(input, out int length);
            Console.WriteLine("What is the largest you would want those numbers to be?");
            input = Console.ReadLine();
            check = Int32.TryParse(input, out int size);

            int[] numbersArray = new int[length];
            Random rnd = new Random();
            for (int i = 0; i < numbersArray.Length; ++i)
                numbersArray[i] = rnd.Next(size + 1);

            return numbersArray;

        }
        static void ArraySum(int[] numbersArray)
        {
            int sum = 0;
            Array.ForEach(numbersArray, i => sum += i);

            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("The sum of the array is " + sum + ".");
            Console.ResetColor();
        }
        static void PrintIt(int[] numbersArray)
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Your array is:");
            foreach (var item in numbersArray)
            {
                Console.Write(" " + item.ToString());
            }
            Console.ResetColor();
        }
        static void ListAverage(List<int> numbersList)
        {
            int lngth = numbersList.Count;
            double sum = 0;
            foreach (int item in numbersList)
            {
                sum = sum + item;
            }
            double avg = sum / lngth;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("The average of your list is " + avg + ".");
            Console.ResetColor();
        }
        static void SortArray(int[] numbersArray)
        {
            int temp = 0;

            for (int i = 0; i <= numbersArray.Length - 1; i++)
            {
                for (int j = i + 1; j < numbersArray.Length; j++)
                {
                    if (numbersArray[i] > numbersArray[j])
                    {
                        temp = numbersArray[i];
                        numbersArray[i] = numbersArray[j];
                        numbersArray[j] = temp;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("This is the array from least to greatest:");
            foreach (var item in numbersArray)
            {
                Console.Write(" " + item);
            }
            Console.ResetColor();
        }
        static void MinList(List<int> numbersList)
        {
            int min = int.MaxValue;
            foreach (int numb in numbersList)
            {
                if (numb <= min)
                {
                    min = numb;
                }
            }
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("The smallest number in the list is " + min);
            Console.ResetColor();

        }
        static void DoesExist(int[] numbersArray)
        {
            bool containsNumber = false;
            Console.WriteLine("Enter an integer to see if it is in the array:");
            string input = Console.ReadLine();
            bool check = Int32.TryParse(input, out int value);

            foreach (int num in numbersArray)
            {
                if (num == value)
                {
                    containsNumber = true;
                    break;
                }

            }
            if (containsNumber == true)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(value + " exist in the array.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(value + " does not exist in the array.");
                Console.ResetColor();
            }
        }
        public static string[] StringArrayGen()
        {
            Console.WriteLine("We need 5 words.");
            string[] stringArray = new string[5];
            for (int i = 0; i < stringArray.Length; i++)
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter a word:");
                stringArray[i] = Console.ReadLine().ToLower();
            }
            return stringArray;
        }
        static void ValueExist(string[] stringArray)
        {
            bool containsValue = false;
            Console.WriteLine("");
            Console.WriteLine("Enter something you want to see if it is in the array:");
            string value = Console.ReadLine().ToLower();
            int count = 0;
            foreach (string word in stringArray)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == value[0])
                    {
                        for (int j = 0; j < value.Length; j++)
                        {
                            if (word[i + 1] == value[0 + j])
                            {
                                containsValue = true;
                                count++;
                            }

                        }
                    }

                }

            }
            if (containsValue == true)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(value + " exist in the array.");
                Console.WriteLine("And it is in there " + count + " times");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(value + " does not exist in the array.");
                Console.ResetColor();
            }
        }
        static void Longest(string[] stringArray)
        {
            string longest = "";
            foreach (string L in stringArray)
            {
                if (L.Length > longest.Length)
                {
                    longest = L;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("The longest word is " + longest + ".");
            Console.ResetColor();
        }
        static void StringIndex()
        {
            Console.WriteLine("Please Input a String");
            string test = Console.ReadLine();
            Console.WriteLine("Please enter what you want the index of:");
            string find = Console.ReadLine();
            int index = test.IndexOf(find);
            if (index != -1)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("The index of " + find + " is " + index);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("That does not exist.");
                Console.ResetColor();
            }
        }
        static void ArrayIndex(int[] numbersArray)
        {
            string input = "";
            Console.WriteLine("What number do you want the index of?");
            input = Console.ReadLine();
            bool check = Int32.TryParse(input, out int find);

            int index = Array.IndexOf(numbersArray, find);
            if (index != -1)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("The index of " + find + " is " + index + ".");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("That number does not exist.");
                Console.ResetColor();
            }
        }
        static void History(int[] numbersArray)
        {
            string input = "";
            Console.WriteLine("Type history if you want Array history if not program will exit.");
            input = Console.ReadLine().ToLower();
            if (input == "history")
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Your array is:");
                foreach (var item in numbersArray)
                {
                    Console.Write(" " + item.ToString());
                }
                Console.ResetColor();
                Console.WriteLine("");
            }
            else
            {  
            }
        }
        }
    }


    
    
    

