using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPlacingCard : MonoBehaviour
{
    [Header("RIVALS STATS")]
    [SerializeField] private RivalsStats rivalsStats;
    [Header("TRANFORM COMPONENTS")]
    [SerializeField] private Transform enemyHandTransform;
    [SerializeField] private Transform enemyPlacedZoneTransform;
    [Header("PLACING FLOAT PARAMETERS")]
    [SerializeField] private float placingCardDelay = 1f;

    private int numberOfPlacedCards;

    private List<Card> cards = new List<Card>();

    private void OnEnable()
    {
        StaticEventsHandler.OnTurnChanged += Instance_OnTurnChanged;
    }

    private void OnDisable()
    {
        StaticEventsHandler.OnTurnChanged -= Instance_OnTurnChanged;
    }

    private void Start()
    {
        if (GameFlowController.Instance.GetCurrentTurn() == Turn.EnemyTurn)
            StartCoroutine(PlaceCardRoutine());
    }

    private void Instance_OnTurnChanged(Turn turn)
    {
        if (turn == Turn.EnemyTurn)
        {
            StartCoroutine(PlaceCardRoutine());
        }
    }

    private IEnumerator PlaceCardRoutine()
    {
        cards = enemyHandTransform.GetComponentsInChildren<Card>().ToList();
        
        for (int i = 0; i <= cards.Count - 1; i++)
        {
            if (rivalsStats.GetEnemyCurrentMana() - cards[i].GetCardDetails().manaCost >= 0)
            {
                yield return new WaitForSeconds(placingCardDelay);

                if (numberOfPlacedCards >= Settings.maxNumberOfPlacedCards)
                {
                    break;
                }

                rivalsStats.SpendEnemyMana(cards[i].GetCardDetails().manaCost);

                Card cardToPlace = cards[i];
                cardToPlace.transform.SetParent(enemyPlacedZoneTransform);
                cardToPlace.gameObject.AddComponent<PlacedCard>();
                cardToPlace.GetComponent<CardUI>().UpdateCardUI();

                cards.Remove(cardToPlace);
            }

            yield return null;
        }

        GameFlowController.Instance.ChangeTurn();
    }
}