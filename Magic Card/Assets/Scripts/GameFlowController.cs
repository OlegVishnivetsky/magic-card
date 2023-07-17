using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlowController : SingletonMonobehaviour<GameFlowController>
{
    [SerializeField] private Button endTurnButton;
    public Canvas canvas;

    [SerializeField] private Card playerMainCard;
    [SerializeField] private Card enemyMainCard;

    [SerializeField] private int startingAmountOfMana;

    private int maxMana = 1;
    private int currentMana;

    public List<Card> playerPlacedCard;
    public List<Card> enemyPlacedCard;

    private Turn currentTurn = Turn.PlayerTurn;

    private void Start()
    {
        maxMana = startingAmountOfMana;
        currentMana = startingAmountOfMana;

        currentTurn = Turn.PlayerTurn;
    }

    public int GetMaxMana()
    {
        return maxMana;
    }

    public void SetMaxMana(int value)
    {
        maxMana = value;
    }

    public int GetCurrentMana()
    {
        return currentMana;
    }

    public void SetCurrentMana(int value)
    {
        currentMana = value;
        StaticEventsHandler.InvokeAmountOfManaChangedEvent(currentMana);
    }

    public Turn GetCurrentTurn()
    {
        return currentTurn;
    }

    private void CheckForPlayerAndEnemtHealth()
    {
        //if (playerMainCard.GetCardHealth() <= 0)
        //{
        //    OnPlayerLose?.Invoke();
        //}
        //else if (enemyMainCard.GetCardHealth() <= 0)
        //{
        //    OnPlayerWon?.Invoke();
        //}
    }

    public void ChangeTurn()
    {
        IncreaseMaxMana();

        if (currentTurn == Turn.PlayerTurn)
        {
            currentTurn = Turn.EnemyTurn;
            endTurnButton.interactable = false;
        }
        else if (currentTurn == Turn.EnemyTurn)
        {
            currentTurn = Turn.PlayerTurn;
            endTurnButton.interactable = true;
        }

        StaticEventsHandler.InvokeTurnChangedEvent(currentTurn);
    }

    private void IncreaseMaxMana()
    {
        currentMana = maxMana;
        StaticEventsHandler.InvokeAmountOfManaChangedEvent(maxMana);

        if (maxMana < 10 && GameFlowController.Instance.GetCurrentTurn() == Turn.PlayerTurn)
        {
            maxMana++;
        }
    }
}