namespace SlotMachine;

internal class RoundResult
{
    public List<WinResult> WinsWithPnl { get; set; }
    public List<WinResult> LossesWithPnl { get; set; }
    public double RoundPnl { get; set; }
    public double UpdatedBalance { get; set; }
}
