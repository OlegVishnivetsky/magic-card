using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
enum Turn
{
    PlayerTurn,
    EnemyTurn
}

public class GameController : SingletonMonobehaviour<GameController>
{
    [SerializeField] private Button endTurnButton;
    [SerializeField] private GameObject winLosePanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private TextMeshProUGUI winLoseText; 

    [SerializeField] private Card playerMainCard;
    [SerializeField] private Card enemyMainCard;

    public List<Card> playerPlacedCard;
    public List<Card> enemyPlacedCard;

    private Turn currentTurn = Turn.PlayerTurn;
    public static event Action<int> OnTurnChanged;
    public static Action OnPlayerChooseCardToAttack;

    public int numberOfMoves;

    private void OnEnable()
    {
        CardBattle.OnAttack += CheckForPlayerAndEnemtHealth;
    }

    private void OnDisable()
    {
        CardBattle.OnAttack -= CheckForPlayerAndEnemtHealth;
    }

    private void Start()
    {
        numberOfMoves = 0;
        currentTurn = Turn.PlayerTurn;

        winLosePanel.transform.localScale = Vector3.zero;
        pausePanel.transform.localScale = Vector3.zero;
    }

    private void CheckForPlayerAndEnemtHealth()
    {
        if (playerMainCard.health <= 0)
        {
            // win
            winLoseText.text = "You Win!";
            winLosePanel.transform.LeanScale(Vector3.one, 0.2f).setEaseInCirc();
        }
        else if (enemyMainCard.health <= 0)
        {
            // lose
            winLoseText.text = "You Lose!";
            winLosePanel.transform.LeanScale(Vector3.one, 0.2f).setEaseInCirc();
        }
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

        numberOfMoves++;
        OnTurnChanged?.Invoke((int)currentTurn);
    }

    public int GetCurrentTurn()
    {
        return (int)currentTurn;
    }

    public void ShowPausePanel()
    {
        pausePanel.transform.LeanScale(Vector3.one, 0.2f).setEaseInCirc();
    }

    public void HidePausePanel()
    {
        pausePanel.transform.LeanScale(Vector3.zero, 0.2f).setEaseInCirc();
    }
}