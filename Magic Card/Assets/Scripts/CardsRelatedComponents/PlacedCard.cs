using UnityEngine;
using UnityEngine.EventSystems;

public class PlacedCard : MonoBehaviour, IEndDragHandler
{
    [SerializeField] private Card card;

    private void Awake()
    {
        card = GetComponent<Card>();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (card.isEnemy)
        {
            return;
        }

        if (eventData.pointerCurrentRaycast.gameObject.GetComponent<Card>() != null)
        {
            Card cardToAttack = eventData.pointerCurrentRaycast.gameObject.GetComponent<Card>();

            if (cardToAttack.isEnemy)
            {
                card.AttackCard(cardToAttack);
                cardToAttack = null;
            }
        }
    }
}