using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackAI : MonoBehaviour
{
    [SerializeField] private float attackDelay;

    [SerializeField] private List<Card> enemyPlacedCards = new List<Card>();
    [SerializeField] private List<Card> playerPlacedCards = new List<Card>();

    private void OnEnable()
    {
        StaticEventsHandler.OnCardPlaced += StaticEventsHandler_OnCardPlaced;
    }

    private void OnDisable()
    {
        StaticEventsHandler.OnCardPlaced -= StaticEventsHandler_OnCardPlaced;
    }

    private void StaticEventsHandler_OnCardPlaced(Card placedCard)
    {
        if (placedCard.isEnemy)
        {
            enemyPlacedCards.Add(placedCard);
        }
        else
        {
            playerPlacedCards.Add(placedCard);
        }
    }

    public void Attack()
    {
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        if (playerPlacedCards.Count == 0)
        {
            GameFlowController.Instance.ChangeTurn();
            yield break;
        }

        for (int i = 0; i < enemyPlacedCards.Count; i++)
        {
            if (enemyPlacedCards[i] == null)
            {
                continue;
            }

            if (playerPlacedCards[0] == null)
            {
                continue;
            }

            yield return new WaitForSeconds(attackDelay);

            enemyPlacedCards[i].AttackCard(playerPlacedCards[0]);

            CheckForCardsExistence(i);

            yield return null;
        }

        GameFlowController.Instance.ChangeTurn();
    }

    private void CheckForCardsExistence(int index)
    {
        if (enemyPlacedCards[index] == null)
        {
            enemyPlacedCards.RemoveAt(index);
        }

        if (playerPlacedCards[0] == null)
        {
            playerPlacedCards.RemoveAt(0);
        }
    }
}