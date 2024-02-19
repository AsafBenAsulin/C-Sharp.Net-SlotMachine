namespace SlotMachine;
using System.Collections.Generic;
internal class ColWinChecker : IWinChecker
{
    public List<WinResult> CheckWins(Board board)
    {
        List<WinResult> results = new List<WinResult>();

        for (int i = 0; i < board.ColumnsNum; i++)
        {
            List<Symbol> col = new List<Symbol>();
            foreach (var row in board.Rows)
            {
                col.Add(row[i]);
            }
            Symbol firstSymbol = col[0];
            if (col.TrueForAll(symbol => symbol.LogicalValue == firstSymbol.LogicalValue))
            {
                results.Add(new WinResult { Line = i + 1, Symbol = firstSymbol, Type = "Col", HasWin = true });
            }
            else
            {
                results.Add(new WinResult { Line = i + 1, Symbol = null, Type = "Col", HasWin = false });
            }
        }
        return results;
    }
}
