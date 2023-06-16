using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, 
    IPointerClickHandler
{
    private Camera mainCamera;

    [SerializeField] private bool isStatic;
    [HideInInspector] public bool isPlaced = false;
    [SerializeField] private Image playerZone;
    
    private CardHand cardHand;

    private Vector2 draggedCardStartPosition;

    private void Awake()
    {
        mainCamera = Camera.main;
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
        if (isStatic) return;

        if (cardHand.GetCardDeck().isEnemyDeck)
        {
            return;
        }

        if (GameController.Instance.GetCurrentTurn() == 1)
        {
            return;
        }

        if (isPlaced)
        {
            return;
        }

        draggedCardStartPosition = GetComponent<RectTransform>().localPosition;
        draggedCardStartPosition.y = -510;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isStatic) return;

        if (cardHand.GetCardDeck().isEnemyDeck)
        {
            return;
        }

        if (GameController.Instance.GetCurrentTurn() == 1)
        {
            return;
        }

        if (isPlaced)
        {
            return;
        }

        GetComponent<CanvasGroup>().blocksRaycasts = false;

        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(eventData.position);
        mousePosition.z = 0;

        transform.position = mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isStatic) return;

        if (cardHand.GetCardDeck().isEnemyDeck)
        {
            return;
        }

        if (GameController.Instance.GetCurrentTurn() == 1)
        {
            return;
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;

        if (isPlaced)
        {
            return;
        }

        GetComponent<RectTransform>().localPosition = draggedCardStartPosition;
        draggedCardStartPosition = Vector2.zero;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isStatic) return;

        if (cardHand.GetCardDeck().isEnemyDeck)
        {
            return;
        }

        if (isPlaced)
        {
            return;
        }

        LeanTween.cancelAll();
        LeanTween.moveLocalY(eventData.pointerEnter.gameObject, -365, 0.1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isStatic) return;

        if (cardHand.GetCardDeck().isEnemyDeck)
        {
            return;
        }

        if (isPlaced)
        {
            return;
        }

        LeanTween.moveLocalY(eventData.pointerEnter.gameObject, -510, 0.1f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Card card = eventData.pointerCurrentRaycast.gameObject.GetComponent<Card>();


        if (card != null && isPlaced && GameController.Instance.GetCurrentTurn() == 0)
        {
            FindObjectOfType<CardBattle>().playerCard = card;
            GameController.OnPlayerChooseCardToAttack?.Invoke();
        }

        if (card != null)
        {
            if (card.isEnemy && GameController.Instance.GetCurrentTurn() == 0 && FindObjectOfType<CardBattle>().playerCard != null)
            {
                FindObjectOfType<CardBattle>().enemyCard = card;
                GameController.OnPlayerChooseCardToAttack?.Invoke();
            }
        }
    }
}