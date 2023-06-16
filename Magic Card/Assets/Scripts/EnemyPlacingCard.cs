using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlacingCard : MonoBehaviour
{
    [SerializeField] private List<Card> cards;
    [SerializeField] private GameObject enemyDeck;

    private void OnEnable()
    {
        GameController.OnTurnChanged += Instance_OnTurnChanged;
    }

    private void OnDisable()
    {
        GameController.OnTurnChanged -= Instance_OnTurnChanged;
    }

    private void Start()
    {
        if (GameController.Instance.GetCurrentTurn() == 1)
            StartCoroutine(PlaceCardRoutine());
    }

    private void Instance_OnTurnChanged(int turn)
    {
        if (turn == 1)
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
        cards[randomNumber].GetComponent<CardController>().isPlaced = true;
        cards[randomNumber].GetComponent<CardUI>().UpdateCardUI();

        GameController.Instance.enemyPlacedCard.Add(cards[randomNumber]);

        cards.RemoveAt(randomNumber);

        yield return new WaitForSeconds(2);

        StartCoroutine(AttackRoutine());

        GameController.Instance.ChangeTurn();
    }

    public IEnumerator AttackRoutine()
    {
        int randomPlayerCardNumber = Random.Range(0, GameController.Instance.playerPlacedCard.Count);
        int randomEnemyCardNumber = Random.Range(0, GameController.Instance.enemyPlacedCard.Count);

        if (GameController.Instance.enemyPlacedCard.Count == 0 || GameController.Instance.playerPlacedCard.Count == 0)
            yield break;

        Card enemyCard = GameController.Instance.enemyPlacedCard[randomEnemyCardNumber];
        Card playerCard = GameController.Instance.playerPlacedCard[randomPlayerCardNumber];

        enemyCard.AttackCard(playerCard);
        CardBattle.OnAttack?.Invoke();
    }
}