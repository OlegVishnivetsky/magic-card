using UnityEngine;
using UnityEngine.EventSystems;

public class CurrentDeckZone : MonoBehaviour, IDropHandler
{
    [SerializeField] private CardDeckSO playerDeck;
    [SerializeField] private Transform deckContentTransform;

    private void Start()
    {
        InstantiateCardsFromDeck();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Card card = eventData.pointerDrag.GetComponent<Card>();

        if (card != null)
        {
            playerDeck.cards.Add(card.GetCardDetails());
            InstantiateCard(card.GetCardDetails());
        }
    }

    private void InstantiateCardsFromDeck()
    {
        foreach (CardDetailsSO cardDetails in playerDeck.cards)
        {
            InstantiateCard(cardDetails);
        }
    }

    private void InstantiateCard(CardDetailsSO cardDetails)
    {
        Card cardObject = Instantiate(cardDetails.prefab, deckContentTransform);
        cardObject.SetCardDetails(cardDetails);

        Destroy(cardObject.GetComponent<CardSelector>());
        Destroy(cardObject.GetComponent<CardController>());
    }
}