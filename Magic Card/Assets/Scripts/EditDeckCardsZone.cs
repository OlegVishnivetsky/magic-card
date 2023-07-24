using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EditDeckCardsZone : MonoBehaviour, IDropHandler
{
    [Header("CARDS")]
    [SerializeField] private CardsCollectionSO cardsCollection;

    [Header("OTHER COMPONENTS")]
    [SerializeField] private CurrentDeckZone currentDeckZone;
    [SerializeField] private Transform cardsTransform;

    [Header("SORT PARAMETERS")]
    [SerializeField] private SortType sortType;
    [SerializeField] private SortingOrderType sortingOrderType;

    private SortHelper sortHelper;

    private List<CardDetailsSO> cardDetailsList = new List<CardDetailsSO>();
    private List<Card> cards = new List<Card>();

    private void Start()
    {
        sortHelper = new SortHelper();

        InstantiateCardsCollection();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Card cardToRemove = eventData.pointerDrag.GetComponent<Card>();

        if (cardToRemove != null)
        {
            if (cards.Contains(cardToRemove))
            {
                return;
            }

            currentDeckZone.RemoveCardFromCurrentDeck(cardToRemove);
        }
    }

    public void ResetCardsSort()
    {
        RemoveAllSpawnedCards();
        InstantiateCardsCollection();
    }

    private void InstantiateCardsCollection()
    {
        foreach (CardDetailsSO cardDetails in cardsCollection.cardList)
        {
            cardDetailsList.Add(cardDetails);
        }

        sortHelper.SortCardListBySortType(cardDetailsList, sortType, sortingOrderType);

        foreach (CardDetailsSO cardDetails in cardDetailsList)
        {
            Card cardObject = Instantiate(cardDetails.prefab, cardsTransform);
            cardObject.SetCardDetails(cardDetails);
            cardObject.gameObject.AddComponent<CardForEditDeckController>().SetEditDeckCardsZone(this);

            cards.Add(cardObject);

            Destroy(cardObject.GetComponent<CardSelector>());
            Destroy(cardObject.GetComponent<CardController>());
        }
    }

    private void RemoveAllSpawnedCards()
    {
        foreach (Card card in cards)
        {
            Destroy(card.gameObject);
        }

        cardDetailsList.Clear();
        cards.Clear();
    }
}