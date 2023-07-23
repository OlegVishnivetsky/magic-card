using UnityEngine;
using UnityEngine.EventSystems;

public class EditDeckCardsZone : MonoBehaviour, IDropHandler
{
    [Header("CARDS")]
    [SerializeField] private CardsCollectionSO cardsCollection;

    [Header("OTHER COMPONENTS")]
    [SerializeField] private CurrentDeckZone currentDeckZone;
    [SerializeField] private Transform cardsTransform;

    private void Start()
    {
        InstantiateCardsCollection();
    }

    private void InstantiateCardsCollection()
    {
        foreach (CardDetailsSO cardDetails in cardsCollection.cardList)
        {
            Card cardObject = Instantiate(cardDetails.prefab, cardsTransform);
            cardObject.SetCardDetails(cardDetails);
            cardObject.gameObject.AddComponent<CardForEditDeckController>();

            Destroy(cardObject.GetComponent<CardSelector>());
            Destroy(cardObject.GetComponent<CardController>());
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Card cardToRemove = eventData.pointerDrag.GetComponent<Card>();

        if (cardToRemove != null)
        {
            currentDeckZone.RemoveCardFromCurrentDeck(cardToRemove);
        }
    }
}