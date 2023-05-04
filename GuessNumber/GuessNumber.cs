namespace GuessNumberNS
{
    public class GuessNumber
    {
        private int _userNumber;
        private int _applicationNumber;

        public GuessNumber()
        {
            Random random = new();
            _applicationNumber = _applicationNumber == 0 ? random.Next(0, 101) : _applicationNumber;
        }

        public bool IsGameFinish()
        {
            if (_userNumber == _applicationNumber)
            {
                _applicationNumber = 0;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CheckUserNumber()
        {
            string str = _userNumber > _applicationNumber ? "greater" : "less";

            Console.WriteLine();
            Console.Write($"Your number {str} then application number. ");
            IsInputValid();
        }

        public void IsInputValid()
        {
            int userInput;
            Console.Write("Enter a number (from 1 to 100): ");
            string str = Console.ReadLine();
            bool res = int.TryParse(str, out userInput);

            while (!res || userInput <= 0 || userInput > 100)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid input. Please enter a valid number (from 1 to 100): ");
                Console.ResetColor();

                str = Console.ReadLine();
                res = int.TryParse(str, out userInput);
            }

            _userNumber = userInput;
        }

        public int GetUserNumber()
        {
            return _userNumber;
        }

        public int GetApplicationNumber()
        {
            return _applicationNumber;
        }
    }
}
