using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlacingCard : MonoBehaviour
{
    [SerializeField] private List<Card> cards;
    [SerializeField] private GameObject enemyDeck;

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
            StopAllCoroutines();
            StartCoroutine(PlaceCardRoutine());
        }
    }

    private IEnumerator PlaceCardRoutine()
    {
        yield return new WaitForSeconds(0.1f);

        foreach (Card card in GetComponentsInChildren<Card>())
        {
            cards.Add(card);
            yield return null;
        }

        int randomNumber = Random.Range(0, cards.Count);

        yield return new WaitForSeconds(2);

        cards[randomNumber].transform.SetParent(enemyDeck.transform);
        cards[randomNumber].GetComponent<CardUI>().UpdateCardUI();

        GameFlowController.Instance.enemyPlacedCard.Add(cards[randomNumber]);

        cards.RemoveAt(randomNumber);

        yield return new WaitForSeconds(2);

        StartCoroutine(AttackRoutine());

        GameFlowController.Instance.ChangeTurn();
    }

    public IEnumerator AttackRoutine()
    {
        int randomPlayerCardNumber = Random.Range(0, GameFlowController.Instance.playerPlacedCard.Count);
        int randomEnemyCardNumber = Random.Range(0, GameFlowController.Instance.enemyPlacedCard.Count);

        if (GameFlowController.Instance.enemyPlacedCard.Count == 0 || GameFlowController.Instance.playerPlacedCard.Count == 0)
            yield break;

        Card enemyCard = GameFlowController.Instance.enemyPlacedCard[randomEnemyCardNumber];
        Card playerCard = GameFlowController.Instance.playerPlacedCard[randomPlayerCardNumber];

        enemyCard.AttackCard(playerCard);
    }
}