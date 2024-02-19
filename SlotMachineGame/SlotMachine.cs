namespace SlotMachine;

using System;

internal class SlotMachine
{
    private readonly IOMgr ioMgr;
    private readonly int numberOfRows;
    private readonly int numberOfCols;
    private int numberOfLines;
    private readonly Board board;
    private readonly AccountMgr accountMgr;

    public SlotMachine()
    {
        ioMgr = IOMgr.GetInstance();
        numberOfRows = 3;
        numberOfCols = 3;
        numberOfLines = 0;
        board = new Board(numberOfRows, numberOfCols);
        accountMgr = new AccountMgr(board, ioMgr.GetDeposit());

        // Event handling would be different in C#, this needs to be adapted.
        // For the sake of example, I'll leave this part as a placeholder.
    }

    public void PlayRound()
    {
        numberOfLines = ioMgr.GetNumberOfLines();
        double maxBet = accountMgr.Balance / (numberOfLines + numberOfLines);
        double bet = ioMgr.GetBet(b => b > 0 && b <= maxBet);

        accountMgr.BeginRound(numberOfLines, bet);

        board.Spin();
        Console.WriteLine();
        ioMgr.PrintMsg(board.GetFormattedString());

        RoundResult roundPnl = accountMgr.CalcPnL();

        foreach (var winResult in roundPnl.WinsWithPnl)
        {
            ioMgr.PrintMsg($"in {winResult.Type} {winResult.Line} {ioMgr.FormatText($"you won {winResult.Pnl}$", "green")} on the symbol {winResult.Symbol.DisplayValue}");
        }

        foreach (var lossResult in roundPnl.LossesWithPnl)
        {
            ioMgr.PrintMsg($"in {lossResult.Type} {lossResult.Line} {ioMgr.FormatText($"you lost {lossResult.Pnl}$", "red")}");
        }

        ioMgr.PrintMsg($"{ioMgr.FormatText($"your profit/loss in this round is {roundPnl.RoundPnl}$", "yellow", true)}");
        ioMgr.PrintMsg("your balance is $" + roundPnl.UpdatedBalance);
    }

    public bool IsGameOver()
    {
        if (accountMgr.Balance <= 0)
        {
            ioMgr.PrintMsg("Game Over");
            return true;
        }
        return false;
    }

    public bool GetPlayAgain()
    {
        return ioMgr.GetPlayAgain();
    }
}

