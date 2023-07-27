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
        if (!IsAllowedToEndDrag())
        {
            return;
        }

        if (eventData.pointerCurrentRaycast.gameObject.TryGetComponent(out Card pointerCurrentCard))
        {
            Card cardToAttack = pointerCurrentCard;

            if (cardToAttack.isEnemy)
            {
                if (IsAnyTauntPlaced())
                {
                    if (cardToAttack.GetCardDetails().cardType != CardType.Taunt)
                    {
                        return;
                    }
                }

                card.AttackCard(cardToAttack);
            }
        }
    }

    private bool IsAllowedToEndDrag()
    {
        if (card.isEnemy)
        {
            return false;
        }

        if (!card.isCanAttack)
        {
            return false;
        }

        return true;
    }

    private bool IsAnyTauntPlaced()
    {
        foreach (Card card in GameFlowController.Instance.enemyPlacedCard)
        {
            if (card.GetCardDetails().cardType == CardType.Taunt)
            {
                return true;
            }
        }

        return false;
    }
}