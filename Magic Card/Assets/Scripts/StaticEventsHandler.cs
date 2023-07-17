using System;

public static class StaticEventsHandler
{
    public static event Action<Turn> OnTurnChanged;

    public static void InvokeTurnChangedEvent(Turn turn)
    {
        OnTurnChanged?.Invoke(turn);
    }

    public static event Action OnPlayerWon;

    public static void InvokePlayerWonEvent()
    {
        OnPlayerWon?.Invoke();
    }

    public static event Action OnPlayerLose;

    public static void InvokePlayerLoseEvent()
    {
        OnPlayerLose?.Invoke();
    }

    public static event Action<int> OnAmountOfManaChanched;

    public static void InvokeAmountOfManaChangedEvent(int amount)
    {
        OnAmountOfManaChanched?.Invoke(amount);
    }
}