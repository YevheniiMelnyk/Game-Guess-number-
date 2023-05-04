using GuessNumberNS;
internal class Program
{
    private static void Main(string[] args)
    {
        do
        {
            PlayGame();
            Console.WriteLine("\nPress any key to exit or 'y' to play again: ");
        } 
        while (Console.ReadKey(true).Key == ConsoleKey.Y);
    }

    private static void PlayGame()
    {
        GuessNumber gn = new();
        gn.IsInputValid();
        bool gameFinish = gn.IsGameFinish();

        while (!gameFinish)
        {
            gn.CheckUserNumber();
            gameFinish = gn.IsGameFinish();
        }

        Console.WriteLine("\nCongrats, you WIN!");
    }
}

