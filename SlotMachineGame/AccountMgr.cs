namespace SlotMachine;

using System.Collections.Generic;
using System.Linq;

internal class AccountMgr
{

    private readonly Board board;
    private int numberOfLines;
    private double bet;

    public double Balance { get; set; }

    public AccountMgr(Board board, double balance)
    {
        Balance = balance;
        this.board = board;
        numberOfLines = 0;
        bet = 0;
    }

    public void BeginRound(int numberOfLines, double bet)
    {
        this.numberOfLines = numberOfLines;
        this.bet = bet;
    }

    public RoundResult CalcPnL()
    {
        var winsAndLosses = board.CheckWins(numberOfLines);

        var winsWithPnl = winsAndLosses
            .Where(o => o.HasWin)
            .Select(o => new WinResult
            {
                Line = o.Line,
                Symbol = o.Symbol,
                Type = o.Type,
                HasWin = o.HasWin,
                Pnl = bet * (SymbolPack.GetSymbolDollarValue(o.Symbol.LogicalValue) + 1)
            })
            .ToList();

        var lossWithPnl = winsAndLosses
            .Where(o => !o.HasWin)
            .Select(o => new WinResult
            {
                Line = o.Line,
                Symbol = o.Symbol,
                Type = o.Type,
                HasWin = o.HasWin,
                Pnl = -bet
            })
            .ToList();

        var roundWinsPnl = winsWithPnl.Sum(o => o.Pnl);
        var roundLossesPnl = lossWithPnl.Sum(o => o.Pnl);

        var totalPnl = roundLossesPnl + roundWinsPnl;

        Balance += totalPnl;

        return new RoundResult
        {
            WinsWithPnl = winsWithPnl,
            LossesWithPnl = lossWithPnl,
            RoundPnl = totalPnl,
            UpdatedBalance = Balance
        };
    }
}

