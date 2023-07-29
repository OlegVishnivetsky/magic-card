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

            if (cardToAttack.IsEnemy)
            {
                if (IsAnyTauntPlaced())
                {
                    if (cardToAttack.GetCardDetails().cardType != CardType.Taunt)
                    {
                        return;
                    }
                }

                card.cardAttack.Attack(cardToAttack);
            }
        }
    }

    private bool IsAllowedToEndDrag()
    {
        if (card.IsEnemy)
        {
            return false;
        }

        if (!card.cardAttack.IsCanAttack)
        {
            return false;
        }

        return true;
    }

    private bool IsAnyTauntPlaced()
    {
        foreach (Card card in GameFlowController.Instance.enemyPlacedCards)
        {
            if (card.GetCardDetails().cardType == CardType.Taunt)
            {
                return true;
            }
        }

        return false;
    }
}