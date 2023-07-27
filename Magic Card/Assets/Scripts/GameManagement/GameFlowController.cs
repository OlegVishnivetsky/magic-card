using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFlowController : SingletonMonobehaviour<GameFlowController>
{
    [SerializeField] private Button endTurnButton;

    [SerializeField] private Card playerMainCard;
    [SerializeField] private Card enemyMainCard;

    public List<Card> playerPlacedCard;
    public List<Card> enemyPlacedCard;

    private Turn currentTurn = Turn.PlayerTurn;

    private void Start()
    {
        currentTurn = Turn.PlayerTurn;
    }

    public Turn GetCurrentTurn()
    {
        return currentTurn;
    }

    public void ChangeTurn()
    {
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
}