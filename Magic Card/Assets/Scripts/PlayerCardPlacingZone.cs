using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCardPlacingZone : MonoBehaviour, IDropHandler
{
    [SerializeField] private Transform playerDeckTransfrom;

    private int numberOfPlacedCards = 0;

    public void OnDrop(PointerEventData eventData)
    {
        if (numberOfPlacedCards >= Settings.maxNumberOfPlacedCards)
        {
            return;
        }

        Card card = eventData.pointerDrag.GetComponent<Card>();

        card.cardSelector.DisableSelection();
        card.gameObject.AddComponent<PlacedCard>();
        card.transform.SetParent(playerDeckTransfrom);

        numberOfPlacedCards++;
    }
}