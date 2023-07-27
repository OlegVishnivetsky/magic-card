using System.Collections.Generic;
using UnityEngine;

public class CardHand : MonoBehaviour
{
    [SerializeField] private CardDeckSO deck;
    [SerializeField] private bool isHidden;

    [SerializeField] private List<CardDetailsSO> cardsFromDeckList;

    private int turnCount = 0;

    private void OnEnable()
    {
        StaticEventsHandler.OnTurnChanged += StaticEventsHandler_OnTurnChanged;
    }

    private void OnDisable()
    {
        StaticEventsHandler.OnTurnChanged -= StaticEventsHandler_OnTurnChanged;
    }

    private void Start()
    {
        for (int i = 0; i < deck.cards.Count; i++)
        {
            cardsFromDeckList.Add(deck.cards[i]);
        }

        SpawnStartingCards();
    }

    public CardDeckSO GetCardDeck()
    {
        return deck;
    }

    public void SetCardDeck(CardDeckSO cardDeck)
    {
        deck = cardDeck;
    }

    private void SpawnStartingCards()
    {
        TakeCertainAmountOfRandomCardFromDeck(Settings.startingNumberOfCards);
    }

    private void StaticEventsHandler_OnTurnChanged(Turn turn)
    {
        turnCount++;

        if (turnCount % 2 == 0)
        {
            turnCount = 0;
            TakeRandomCardFromDeck();
        }
    }

    public void TakeCertainAmountOfRandomCardFromDeck(int amount)
    {
        for (int i = 0; i <= amount; i++)
        {
            if (cardsFromDeckList.Count == 0)
            {
                break;
            }

            TakeRandomCardFromDeck();
        }
    }

    public void TakeCardFromDeckByIndex(int index)
    {
        if (!IsCanTakeCard())
        {
            return;
        }

        Card spawnedCard = Instantiate(GameResources.Instance.cardPrefab, transform);
        spawnedCard.SetCardDetails(cardsFromDeckList[index]);

        cardsFromDeckList.RemoveAt(index);

        if (deck.isEnemyDeck)
        {
            spawnedCard.isEnemy = true;
        }
    }

    public void TakeRandomCardFromDeck()
    {
        if (!IsCanTakeCard())
        {
            return;
        }

        int randomNumber = Random.Range(0, cardsFromDeckList.Count);

        Card spawnedCard = Instantiate(GameResources.Instance.cardPrefab, transform);
        spawnedCard.SetCardDetails(cardsFromDeckList[randomNumber]);

        cardsFromDeckList.RemoveAt(randomNumber);

        if (deck.isEnemyDeck)
        {
            spawnedCard.isEnemy = true;
        }
    }

    private bool IsCanTakeCard()
    {
        int numberOfCardsInHand = 0;

        if (cardsFromDeckList.Count == 0)
        {
            return false;
        }

        foreach (Card card in GetComponentsInChildren<Card>())
        {
            numberOfCardsInHand++;
        }

        if (numberOfCardsInHand >= Settings.maxNumberOfCardsInHand)
        {
            return false;
        }

        return true;
    }
}