using UnityEngine;
using UnityEngine.EventSystems;

[DisallowMultipleComponent]
[RequireComponent(typeof(Card))]
[RequireComponent(typeof(CanvasGroup))]
public class CardController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Card card;
    private Camera cameraCache;
    private CanvasGroup canvasGroup;

    private bool isCanDragPlacedCard;

    private Vector2 draggedCardStartPosition;

    private void Awake()
    {
        cameraCache = Camera.main;

        card = GetComponent<Card>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isCanDragPlacedCard = GetComponent<PlacedCard>() != null && !card.cardAttack.IsCanAttack;

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

        if (isCanDragPlacedCard)
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

        if (card.IsEnemy)
        {
            return false;
        }

        return true;
    }
}