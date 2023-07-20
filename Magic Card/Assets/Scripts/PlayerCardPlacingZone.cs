using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCardPlacingZone : MonoBehaviour, IDropHandler
{
    [SerializeField] private RivalsStats rivalsStats;
    [SerializeField] private Transform playerDeckTransfrom;

    private int numberOfPlacedCards = 0;

    public void OnDrop(PointerEventData eventData)
    {
        if (numberOfPlacedCards >= Settings.maxNumberOfPlacedCards)
        {
            return;
        }

        Card card = eventData.pointerDrag.GetComponent<Card>();

        if (rivalsStats.GetPlayerCurrentMana() - card.GetCardDetails().manaCost < 0)
        {
            return;
        }

        rivalsStats.SpendPlayerMana(card.GetCardDetails().manaCost);

        card.cardSelector.DisableSelection();
        card.gameObject.AddComponent<PlacedCard>();
        card.transform.SetParent(playerDeckTransfrom);

        StaticEventsHandler.InvokeCardPlacedEvent(card);

        numberOfPlacedCards++;
    }
}