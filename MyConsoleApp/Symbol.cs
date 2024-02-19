namespace MyConsoleApp;

public class Symbol
{
    public string LogicalValue { get; }
    public string DisplayValue { get; }
    public string Description { get; }

    public Symbol(string logicalValue, string displayValue, string? description = null)
    {
        LogicalValue = logicalValue;
        DisplayValue = displayValue;
        Description = description ?? $"This is a symbol with display value {displayValue} and logical value {logicalValue}";
    }
}
