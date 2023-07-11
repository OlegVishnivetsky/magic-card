using UnityEngine;

public class CardHand : MonoBehaviour
{
    [SerializeField] private CardDeckSO deck;
    [SerializeField] private int startingNumberOfCards;
    [SerializeField] private bool isHidden;

    private void Start()
    {
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
        for (int i = 0; i <= startingNumberOfCards; i++)
        {
            if (deck.cards.Count < i)
            {
                break;
            }

            Card spawnedCard = Instantiate(deck.cards[i].prefab, transform);
            spawnedCard.SetCardDetails(deck.cards[i]);

            if (deck.isEnemyDeck)
            {
                spawnedCard.isEnemy = true;
            }
        }
    }
}