using System;

namespace BullsAndCowsNew
{
    class Program
    {
        static void Main(string[] args)
        {
            Random someNumber = new Random();
            int random = someNumber.Next(1000, 9999);
            int attempts = 0;

            string randomToString = random.ToString();
            
            while (randomToString[0] == randomToString[1] ||
                 randomToString[0] == randomToString[2] ||
                 randomToString[0] == randomToString[3] ||
                 randomToString[1] == randomToString[2] ||
                 randomToString[1] == randomToString[3] ||
                 randomToString[2] == randomToString[3])
            {
                random = someNumber.Next(1000, 9999);
                randomToString = random.ToString();
            }
            int input = int.Parse(Console.ReadLine());

            string inputToString = input.ToString();

            while (randomToString != inputToString)
            {
                if (inputToString.Length <= 3)
                {
                    Console.WriteLine("Invalid number!");
                    inputToString = Console.ReadLine();
                    continue;
                }
                if (int.Parse(inputToString) < 1000 || int.Parse(inputToString) > 9999)
                {
                    Console.WriteLine("Invalid number!");
                    inputToString = Console.ReadLine();
                    continue;
                }
                if (inputToString[0] == inputToString[1] ||
                   inputToString[0] == inputToString[2] ||
                   inputToString[0] == inputToString[3] ||
                   inputToString[1] == inputToString[2] ||
                   inputToString[1] == inputToString[3] ||
                   inputToString[2] == inputToString[3])
                {
                    Console.WriteLine("Invalid number!");
                    inputToString = Console.ReadLine();
                    continue;
                }
                int counterCows = CounterCows(randomToString, inputToString);
                int counterBulls = CounterBulls(randomToString, inputToString);
                if (counterCows == 1 && counterBulls == 1)
                {
                    Console.WriteLine($"{counterCows} cow and {counterBulls} bull");
                    attempts++;
                }
                else if (counterCows != 1 && counterBulls == 1)
                {
                    Console.WriteLine($"{counterCows} cows and {counterBulls} bull");
                    attempts++;
                }
                else if (counterCows != 1 && counterBulls != 1)
                {
                    Console.WriteLine($"{counterCows} cows and {counterBulls} bulls");
                    attempts++;
                }
                else if (counterCows == 1 && counterBulls != 1)
                {
                    Console.WriteLine($"{counterCows} cow and {counterBulls} bulls");
                    attempts++;
                }

                inputToString = Console.ReadLine();
            }
            if (randomToString == inputToString)
            {
                Console.WriteLine("Correct!");
                Console.WriteLine($"{attempts} attempts");
            }
        }
        static int CounterCows(string randomToString, string inputToString)
        {
            int counter = 0;
            for (int i = 0; i < 4; i++)
            {
                if (randomToString.Contains(inputToString[i]) && randomToString[i] != inputToString[i])
                {
                    counter++;
                }
            }

            return counter;
        }
        static int CounterBulls(string randomToString, string inputToString)
        {
            int counter = 0;
            for (int i = 0; i < 4; i++)
            {
                if (randomToString[i] == inputToString[i])
                {
                    counter++;
                }
            }

            return counter;
        }
    }

}
