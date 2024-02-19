namespace SlotMachine;

internal class WinResult
{
    public int Line { get; set; }
    public Symbol Symbol { get; set; }
    public string Type { get; set; }
    public bool HasWin { get; set; }
    public double Pnl { get; set; }
}
