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

    public static event Action<int> OnPlayerAmountOfHealthChanged;

    public static void InvokePlayerAmountOfHealthChangedEvent(int currentHealth)
    {
        OnPlayerAmountOfHealthChanged?.Invoke(currentHealth);
    }

    public static event Action<int> OnEnemyAmountOfHealthChanged;

    public static void InvokeEnemyAmountOfHealthChangedEvent(int currentHealth)
    {
        OnEnemyAmountOfHealthChanged?.Invoke(currentHealth);
    }

    public static event Action<int> OnPlayerAmountOfManaChanged;

    public static void InvokePlayerAmountOfManaChangedEvent(int currentMana)
    {
        OnPlayerAmountOfManaChanged?.Invoke(currentMana);
    }

    public static event Action<int> OnEnemyAmountOfManaChanged;

    public static void InvokeEnemyAmountOfManaChangedEvent(int currentMana)
    {
        OnEnemyAmountOfManaChanged?.Invoke(currentMana);
    }

    public static event Action<Card> OnCardPlaced;

    public static void InvokeCardPlacedEvent(Card placedCard)
    {
        OnCardPlaced?.Invoke(placedCard);
    }
}