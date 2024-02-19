namespace SlotMachine;

internal interface IWinChecker
{
    List<WinResult> CheckWins(Board board);
}

internal class WinCheckerFactory
{
    public static List<IWinChecker> CreateWinCheckers()
    {
        return new List<IWinChecker> { new RowWinChecker(), new ColWinChecker() };
    }
}
