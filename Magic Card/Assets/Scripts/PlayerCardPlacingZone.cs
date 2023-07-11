using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCardPlacingZone : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject playerDeck;

    public static event Action OnPlayerCardPlaced;

    private int cardPlaced = 0;
    private const int maxCardPlaced = 6;

    public void OnDrop(PointerEventData eventData)
    {
        Card dropedCard = eventData.pointerDrag.GetComponent<Card>();
        Card card = eventData.pointerDrag.GetComponent<Card>();

        cardPlaced++;

        if (cardPlaced >= maxCardPlaced)
        {
            return;
        }

        if (GameFlowController.Instance.GetCurrentMana() - card.GetCardDetails().manaCost >= 0 
            && !card.isPlaced)
        {
            GameFlowController.Instance.SetCurrentMana(GameFlowController.Instance.GetCurrentMana() 
                - card.GetCardDetails().manaCost);
        }
        else
        {
            return;
        }

        GameFlowController.Instance.playerPlacedCard.Add(card);

        OnPlayerCardPlaced?.Invoke();

        dropedCard.isPlaced = true;
        dropedCard.transform.SetParent(playerDeck.transform);
    }
}