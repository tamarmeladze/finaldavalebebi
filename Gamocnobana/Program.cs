namespace Gamocnobana
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("You have to guess number, first choose the level of game");
            Console.WriteLine("press 'e' - easy game 1-25 numbers, 'm' - medium game with 1-50numbers;   'h' - hard game 1-100 numbers!");
            char choice = char.Parse(Console.ReadLine());
            if (choice != 'e' && choice != 'm' && choice != 'h')
            {
                Console.WriteLine("press correct character 'e','m' or 'h'");

            }
            int minnumber = 1;
            int maxnumber = 100;
            if (choice == 'e')
            {
                maxnumber = 25;
            }
            else if (choice == 'm')
            {
                maxnumber = 50;
            }
            Console.WriteLine("start guessing the number");
            Random random = new Random();
            int numbertoguess = random.Next(minnumber, maxnumber);
            int tries = 10;

            while (tries > 0)
            {
                if (int.TryParse(Console.ReadLine(), out int guess))
                {
                    if (guess == numbertoguess)
                    {
                        Console.WriteLine("You Guessed the number !Game Over!");
                        break;
                    }
                    else if (guess < numbertoguess)
                    {
                        Console.WriteLine("try higher number");

                    }
                    else
                    {
                        Console.WriteLine("try lower number");
                    }
                    tries--;
                }

            }
            if (tries == 0)
            { Console.WriteLine($"sorry,you lose, the number was {numbertoguess}"); }
        }
    }
}
