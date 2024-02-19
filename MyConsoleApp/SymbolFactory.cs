namespace MyConsoleApp;

using System;
using System.Collections.Generic;

public class SymbolFactory
{
    private static readonly Dictionary<string, string> Emojis = new Dictionary<string, string>
    {
        { "banana", "🍌" },
        { "strawberry", "🍓" },
        { "grape", "🍇" },
        { "apple", "🍏" },
        { "smile", "😃" }
    };

    private static readonly Dictionary<string, string> Displays = new Dictionary<string, string>
    {
        { "banana", "A" },
        { "strawberry", "B" },
        { "grape", "C" },
        { "apple", "D" },
        { "smile", "S" }
    };

    public static Symbol CreateSymbol(string value)
    {
        if (CanDisplayEmojis())
            return new EmojiSymbol(Displays[value], Emojis[value]);

        return new RegularSymbol(Displays[value]);
    }

    private static bool CanDisplayEmojis()
    {
        string[] args = Environment.GetCommandLineArgs();
        bool displayEmojis = true; // Default value
        for (int i = 1; i < args.Length; i++)
        {
            if (args[i] == "--no-emojis")
            {
                displayEmojis = false;
                break;
            }
        }
        return displayEmojis;
    }
}


public class EmojiSymbol : Symbol
{
    public EmojiSymbol(string logicalValue, string displayValue, string? description = null)
        : base(logicalValue, displayValue, description)
    {
    }
}

public class RegularSymbol : Symbol
{
    public RegularSymbol(string logicalValue, string? description = null)
        : base(logicalValue, " " + logicalValue, description)
    {
    }
}

