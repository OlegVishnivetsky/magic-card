using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPlacingCard : MonoBehaviour
{
    [Header("MAIN COMPONENTS")]
    [SerializeField] private RivalsStats rivalsStats;
    [SerializeField] private EnemyAttackAI enemyAttackAI;

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
        {
            StartCoroutine(PlaceCardRoutine());
        }
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
            CheckForNumberOfPlacedCards();

            if (rivalsStats.GetEnemyCurrentMana() - cards[i].GetCardDetails().cardData.manaCost >= 0)
            {
                yield return new WaitForSeconds(placingCardDelay);

                if (numberOfPlacedCards >= Settings.maxNumberOfPlacedCards)
                {
                    break;
                }

                rivalsStats.SpendEnemyMana(cards[i].GetCardDetails().cardData.manaCost);

                Card cardToPlace = cards[i];
                cardToPlace.transform.SetParent(enemyPlacedZoneTransform);
                cardToPlace.gameObject.AddComponent<PlacedCard>();
                cardToPlace.GetComponent<CardUI>().UpdateCardUI();

                StaticEventsHandler.InvokeCardPlacedEvent(cardToPlace);

                cards.Remove(cardToPlace);
            }

            yield return null;
        }

        enemyAttackAI.Attack();
    }

    private void CheckForNumberOfPlacedCards()
    {
        numberOfPlacedCards = enemyPlacedZoneTransform.GetComponentsInChildren<PlacedCard>().ToList().Count;
    }
}