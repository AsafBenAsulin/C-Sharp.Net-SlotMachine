namespace SlotMachine;
using System.Collections.Generic;
internal class RowWinChecker : IWinChecker
{
    public List<WinResult> CheckWins(Board board)
    {
        List<WinResult> results = new List<WinResult>();

        for (int i = 0; i < board.RowsNum; i++)
        {
            List<Symbol> row = board.Rows[i];
            Symbol firstSymbol = row[0];
            if (row.TrueForAll(symbol => symbol.LogicalValue == firstSymbol.LogicalValue))
            {
                results.Add(new WinResult { Line = i + 1, Symbol = firstSymbol, Type = "Row", HasWin = true });
            }
            else
            {
                results.Add(new WinResult { Line = i + 1, Symbol = null, Type = "Row", HasWin = false });
            }
        }
        return results;
    }
}
