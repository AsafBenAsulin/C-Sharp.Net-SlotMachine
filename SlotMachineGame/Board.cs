namespace SlotMachine;

using System;
using System.Collections.Generic;

internal class Board
{

    private readonly SymbolPack symbolPack;

    public int RowsNum { get; }
    public List<List<Symbol>> Rows { get; }
    public int ColumnsNum { get; }
    public Board(int rowsNum, int columnsNum)
    {
        RowsNum = rowsNum;
        ColumnsNum = columnsNum;
        symbolPack = SymbolPack.GetInstance();

        Rows = new List<List<Symbol>>();
        for (int i = 0; i < rowsNum; i++)
        {
            Rows.Add(new List<Symbol>());
            for (int j = 0; j < columnsNum; j++)
            {
                Rows[i].Add(symbolPack.GetXRandomSymbols(1)[0]);
            }
        }
    }

    public void Spin()
    {
        const int spinNum = 10_000;
        for (int i = 0; i < spinNum; i++)
        {
            _Spin();
            // Event emitter would be handled differently in C#
        }
    }

    private void _Spin()
    {
        for (int i = 0; i < RowsNum; i++)
        {
            Rows[i] = symbolPack.GetXRandomSymbols(ColumnsNum);
        }
    }

    public string GetFormattedString()
    {
        string res = "";
        foreach (var row in Rows)
        {
            res += string.Join(" | ", row.ConvertAll(symbol => symbol.DisplayValue)) + "\n";
        }
        return res;
    }

    public List<WinResult> CheckWins(int numberOfLines)
    {
        List<WinResult> res = new List<WinResult>();
        List<IWinChecker> winCheckers = WinCheckerFactory.CreateWinCheckers();
        for (int i = 0; i < numberOfLines && i < winCheckers.Count; i++)
        {
            res.AddRange(winCheckers[i].CheckWins(this));
        }
        return res;
    }
}

