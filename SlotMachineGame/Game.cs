namespace SlotMachine;

using System;

public class Game
{
    public void Start()
    {
        var gameMachine = CreateGameMachine();

        while (true)
        {
            gameMachine.PlayRound();

            if (gameMachine.IsGameOver())
            {
                break;
            }

            if (!gameMachine.GetPlayAgain())
            {
                break;
            }
        }
    }

    private SlotMachine CreateGameMachine()
    {
        return new SlotMachine();
    }
}
