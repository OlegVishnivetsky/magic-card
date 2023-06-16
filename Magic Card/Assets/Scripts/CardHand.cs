using UnityEngine;

public class CardHand : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private CardDeckSO deck;
    [SerializeField] private Vector2 spawnPosition;
    [SerializeField] private float offset;
    [SerializeField] private bool isHidden;

    private float previousXPosition = 0f;

    private void Start()
    {
        SpawnCards();
    }

    public CardDeckSO GetCardDeck()
    {
        return deck;
    }

    public void SetCardDeck(CardDeckSO cardDeck)
    {
        this.deck = cardDeck;
    }

    private void SpawnCards()
    {
        foreach (var card in deck.cards)
        {
            Card spawnedCard = Instantiate(card.prefab, this.transform);
            spawnedCard.SetCardDetails(card);

            if (deck.isEnemyDeck)
            {
                spawnedCard.isEnemy = true;
            }

            RectTransform rect = spawnedCard.GetComponent<RectTransform>();

            rect.localPosition = spawnPosition;

            if (previousXPosition != 0f)
            {
                rect.localPosition = new Vector3(previousXPosition + offset, rect.localPosition.y, 0);
            }
            else
            {
                rect.localPosition = new Vector3(rect.localPosition.x + offset, rect.localPosition.y, 0);
            }

            previousXPosition = rect.localPosition.x;
        }

        offset = 0;
    }
}