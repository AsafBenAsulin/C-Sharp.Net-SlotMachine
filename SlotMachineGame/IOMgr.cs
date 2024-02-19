namespace SlotMachine;

using System;

internal class IOMgr
{
    private static IOMgr instance;


    private IOMgr()
    {

    }

    public static IOMgr GetInstance()
    {
        if (instance == null)
        {
            instance = new IOMgr();
        }
        return instance;
    }

    public void PrintMsg(string msg)
    {
        Console.WriteLine(msg);
    }

    public string FormatText(string text, string color, bool isBold = false)
    {
        if (!Console.IsOutputRedirected)
        {
            if (color == "green")
                Console.ForegroundColor = ConsoleColor.Green;
            else if (color == "red")
                Console.ForegroundColor = ConsoleColor.Red;
            else if (color == "yellow")
                Console.ForegroundColor = ConsoleColor.Yellow;

            if (isBold)
                Console.Write("\x1b[1m");

            Console.Write(text);
            Console.ResetColor();
        }
        return text;
    }

    public double GetDeposit()
    {
        while (true)
        {
            Console.Write("Enter a deposit amount[100]: ");
            string depositAmountInput = Console.ReadLine();
            if (string.IsNullOrEmpty(depositAmountInput))
                depositAmountInput = "100";

            if (double.TryParse(depositAmountInput, out double depositAmount) && depositAmount > 0)
            {
                PrintMsg("Your initial balance is $" + depositAmount);
                return depositAmount;
            }

            PrintMsg("Invalid deposit amount, try again");
        }
    }

    public int GetNumberOfLines()
    {
        while (true)
        {
            Console.Write("Enter number of lines (1-3) [3]: ");
            string linesInput = Console.ReadLine();
            if (string.IsNullOrEmpty(linesInput))
                linesInput = "3";

            if (int.TryParse(linesInput, out int numberOfLines) && numberOfLines > 0 && numberOfLines <= 3)
            {
                PrintMsg("You are betting on " + numberOfLines + " lines");
                return numberOfLines;
            }

            PrintMsg("Invalid number of lines, try again");
        }
    }

    public double GetBet(Func<double, bool> validationFunc)
    {
        while (true)
        {
            Console.Write("Enter the bet per line [$5]: ");
            string betInput = Console.ReadLine();
            if (string.IsNullOrEmpty(betInput))
                betInput = "5";

            if (double.TryParse(betInput, out double bet) && validationFunc(bet))
            {
                PrintMsg("Your bet is $" + bet + " per line");
                return bet;
            }

            PrintMsg("Invalid bet amount");
        }
    }

    public bool GetPlayAgain()
    {
        while (true)
        {
            Console.Write("Do you want to play again (y/n) [y]? ");
            string playAgainInput = Console.ReadLine();
            if (string.IsNullOrEmpty(playAgainInput))
                playAgainInput = "y";

            if (playAgainInput.Equals("y", StringComparison.OrdinalIgnoreCase))
                return true;
            else if (playAgainInput.Equals("n", StringComparison.OrdinalIgnoreCase))
                return false;
        }
    }
}

