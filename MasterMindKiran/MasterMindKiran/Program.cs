using System.Text.RegularExpressions;

namespace MasterMindKiran
{
    internal class Program
    {
        static Random rand = new Random();

        static void Main(string[] args)
        {
            int guessesAllowed = 10;
            string answer = GenerateCombination();

            Console.WriteLine("Welcome to Master Mind!");
            Console.WriteLine("\n");
            Console.WriteLine("Enter four digits between 1 and 6 to guess the combination:");

            string userGuess = GetUserGuess();

            while (answer != userGuess)
            {
                Console.Clear();
                if (--guessesAllowed < 1)
                {
                    Console.WriteLine("Out of tries!  Better luck next time!");
                    return;
                }
                Console.WriteLine("Your guess wasnt quite right: " + userGuess);
                Console.WriteLine($"Here is a hint: {GenerateHints(answer, userGuess)}");
                Console.WriteLine("Guess Again:");
                userGuess = GetUserGuess();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You win!!!");
            Console.ForegroundColor = ConsoleColor.White;

        }

        static string GenerateHints(string answer, string guess)
        {
            string hint = "";
            for (int i = 0; i < 4; i++)
            {
                if (answer[i] == guess[i])
                {
                    hint += "+";
                    continue;
                }
                if (Regex.IsMatch(answer, guess[i].ToString()))
                {
                    hint += "-";
                    continue;
                }
                hint += " ";
            }
            return $"[{hint}]";
        }

        static string GenerateCombination()
        {
            string ans = "";
            for (int i = 0; i < 4; i++)
            {
                ans += RandomNum();
            }
            return ans;
        }

        static string GetUserGuess()
        {
            string? userGuess = Console.ReadLine();
            while (string.IsNullOrEmpty(userGuess) || userGuess.Length != 4 || !int.TryParse(userGuess, out var num))
            {
                Console.Clear();
                Console.WriteLine("Incorrect format.  Please enter four digits in the format ####");

                userGuess = Console.ReadLine();
            }
            return userGuess;
        }

        static int RandomNum()
        {
            return (int)rand.NextInt64(1, 7);
        }
    }
}