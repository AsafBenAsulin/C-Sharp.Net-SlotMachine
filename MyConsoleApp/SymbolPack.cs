namespace MyConsoleApp;
using System;
using System.Collections.Generic;


public class SymbolPack
{
    private static SymbolPack? instance;
    private static readonly Dictionary<string, Func<Symbol>> SYMBOL_OBJECTS = new Dictionary<string, Func<Symbol>>
    {
        { "A", () => SymbolFactory.CreateSymbol("banana") },
        { "B", () => SymbolFactory.CreateSymbol("strawberry") },
        { "C", () => SymbolFactory.CreateSymbol("grape") },
        { "D", () => SymbolFactory.CreateSymbol("apple") }
    };

    private static readonly Dictionary<string, int> SYMBOLS_COUNT = new Dictionary<string, int>
    {
        { "A", 20 },
        { "B", 40 },
        { "C", 60 },
        { "D", 80 }
    };

    private readonly List<Symbol> symbols;

    private SymbolPack()
    {
        symbols = new List<Symbol>();
        foreach (var kvp in SYMBOLS_COUNT)
        {
            for (int i = 0; i < kvp.Value; i++)
            {
                symbols.Add(SYMBOL_OBJECTS[kvp.Key].Invoke());
            }
        }
    }

    public static SymbolPack GetInstance()
    {
        if (instance == null)
        {
            instance = new SymbolPack();
        }
        return instance;
    }

    public static int GetSymbolDollarValue(string symbol)
    {
        var SYMBOL_VALUES = new Dictionary<string, int>
        {
            { "A", 20 },
            { "B", 15 },
            { "C", 10 },
            { "D", 5 }
        };
        return SYMBOL_VALUES[symbol];
    }

    public List<Symbol> GetXRandomSymbols(int columnsNum)
    {
        var rowSymbols = new List<Symbol>(symbols);
        var random = new Random();
        var selectedSymbols = new List<Symbol>();

        for (int i = 0; i < columnsNum; i++)
        {
            int randomIndex = random.Next(rowSymbols.Count);
            selectedSymbols.Add(rowSymbols[randomIndex]);
            rowSymbols.RemoveAt(randomIndex);
        }

        return selectedSymbols;
    }
}
