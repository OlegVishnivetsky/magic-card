using UnityEngine;
using UnityEngine.EventSystems;

public class PlacedCard : MonoBehaviour, IDropHandler
{
    private Card card;

    private void Awake()
    {
        card = GetComponent<Card>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Card pointerDragCard = eventData.pointerDrag.GetComponent<Card>();

        if (!pointerDragCard.isEnemy)
        {
            return;
        }

        card.AttackCard(pointerDragCard);
    }
}