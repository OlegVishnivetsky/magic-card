using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Card))]
[RequireComponent(typeof(CanvasGroup))]
public class CardController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Card card;
    private CardHand cardHand;
    private Camera cameraCache;
    private CanvasGroup canvasGroup;

    private Vector2 draggedCardStartPosition;

    private void Awake()
    {
        cameraCache = Camera.main;

        card = GetComponent<Card>();
        canvasGroup = GetComponent<CanvasGroup>();
        cardHand = GetComponentInParent<CardHand>();

    }

    private void Start()
    {
        if (cardHand.GetCardDeck().isEnemyDeck)
        {
            GetComponent<CardUI>().HideCardUI();
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!IsAllowedToControlCard())
        {
            return;
        }

        canvasGroup.blocksRaycasts = false;

        if (card.GetComponent<PlacedCard>() != null)
        {
            draggedCardStartPosition = transform.localPosition;
        }
        else
        {
            draggedCardStartPosition = new Vector2(transform.localPosition.x, Settings.cardStandartYPosition);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsAllowedToControlCard())
        {
            return;
        }

        Vector3 mousePosition = cameraCache.ScreenToWorldPoint(eventData.position);
        mousePosition.z = 0;

        transform.position = mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!IsAllowedToControlCard())
        {
            return;
        }

        canvasGroup.blocksRaycasts = true;

        transform.localPosition = draggedCardStartPosition;
        draggedCardStartPosition = Vector2.zero;
    }

    private bool IsAllowedToControlCard()
    {
        if (GameFlowController.Instance.GetCurrentTurn() == Turn.EnemyTurn)
        {
            return false;
        }

        if (card.isEnemy)
        {
            return false;
        }

        return true;
    }

    //public void OnDrop(PointerEventData eventData)
    //{
    //    if (card.isPlaced)
    //    {
    //        Card cardToAttack = eventData.pointerDrag.GetComponent<Card>();

    //        if (!card.isEnemy)
    //        {
    //            return;
    //        }

    //        cardToAttack.AttackCard(card);        
    //    }
    //}
}