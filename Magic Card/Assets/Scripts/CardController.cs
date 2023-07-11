using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler,
    IPointerExitHandler, IDropHandler
{
    private Camera cameraCache;

    [SerializeField] private bool isStatic;
    [SerializeField] private Image playerZone;

    private Card card;
    private CardHand cardHand;

    private Vector2 draggedCardStartPosition;

    private void Awake()
    {
        cameraCache = Camera.main;
        card = GetComponent<Card>();
        cardHand = GetComponentInParent<CardHand>();
    }

    private void Start()
    {
        if (!isStatic)
        {
            if (cardHand.GetCardDeck().isEnemyDeck)
            {
                GetComponent<CardUI>().HideCardUI();
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!IsCanDragCard())
        {
            return;
        }

        draggedCardStartPosition = GetComponent<RectTransform>().localPosition;

        if (!card.isPlaced)
        {
            draggedCardStartPosition.y = Settings.cardStandartYPosition;
        }
        else
        {
            draggedCardStartPosition.y = 0f;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsCanDragCard())
        {
            return;
        }

        GetComponent<CanvasGroup>().blocksRaycasts = false;

        Vector3 mousePosition = cameraCache.ScreenToWorldPoint(eventData.position);
        mousePosition.z = 0;

        transform.position = mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!IsCanDragCard())
        {
            return;
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;

        GetComponent<RectTransform>().localPosition = draggedCardStartPosition;
        draggedCardStartPosition = Vector2.zero;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!IsCardCanBeExamined())
        {
            return;
        }

        transform.DOLocalMoveY(Settings.cardMouseEnterYPosition, 0.1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!IsCardCanBeExamined())
        {
            return;
        }

        transform.DOLocalMoveY(Settings.cardStandartYPosition, 0.1f);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (card.isPlaced)
        {
            Card cardToAttack = eventData.pointerDrag.GetComponent<Card>();

            if (!card.isEnemy)
            {
                return;
            }

            cardToAttack.AttackCard(card);
            GameFlowController.Instance.InvokeOnCardAttackedEvent();          
        }
    }

    private bool IsCanDragCard()
    {
        if (isStatic)
        {
            return false;
        }

        if (cardHand.GetCardDeck().isEnemyDeck)
        {
            return false;
        }

        if (GameFlowController.Instance.GetCurrentTurn() == Turn.EnemyTurn)
        {
            return false;
        }

        return true;
    }

    private bool IsCardCanBeExamined()
    {
        if (isStatic)
        {
            return false;
        }

        if (cardHand.GetCardDeck().isEnemyDeck)
        {
            return false;
        }

        if (card.isPlaced)
        {
            return false;
        }

        return true;
    }
}