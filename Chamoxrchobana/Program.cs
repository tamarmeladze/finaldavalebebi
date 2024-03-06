using System.Linq.Expressions;

namespace Chamoxrchobana
{
    internal class Program
    {
        static void Main(string[] args)

        {
            List<string> words = new()
        {
            "apple", "banana", "orange", "grape", "kiwi",
            "strawberry", "pineapple", "blueberry", "peach", "watermelon"
        };

            Random random = new Random();
            string wordtoguess = words[random.Next(0, words.Count)];
            char[] guessedword = new char[wordtoguess.Length];
            for (int i = 0; i < guessedword.Length; i++)
            {
                guessedword[i] = '-';
            }
            int tries = 6;
            List<char> guessedletters = new();
            while (tries > 0)
            {
                try {
                    Console.WriteLine("word:" + string.Join(" ", guessedword));
                    Console.WriteLine("tries left:" + tries);
                    Console.WriteLine("guess a letter");
                    char guesslet = char.Parse(Console.ReadLine());
                    if (guessedletters.Contains(guesslet))
                    {
                        Console.WriteLine("letter already guessed, try again");
                        continue;
                    }
                    guessedletters.Add(guesslet);
                    if (wordtoguess.Contains(guesslet))
                    {
                        for (int i = 0; i < wordtoguess.Length; i++)
                        {
                            if (wordtoguess[i] == guesslet)
                            {
                                guessedword[i] = guesslet;
                            }
                        }
                    }
                    else
                    { tries--; }
                    if (string.Join("", guessedword) == wordtoguess)
                    {
                        Console.WriteLine("you guesses the word: " + wordtoguess);
                        break;
                    }
                }
                catch (FormatException) { Console.WriteLine("invalid input , enter one digit"); }
                if (tries == 0)
                { Console.WriteLine("you have no tries, the word was : " + wordtoguess); }
            } }
                 
        }
    }
