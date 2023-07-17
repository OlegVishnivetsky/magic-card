using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSelector : MonoBehaviour, IPointerEnterHandler,
    IPointerExitHandler
{
    [SerializeField] private float mouseEnterTweenDuration = 0.1f;

    private Card card;

    private bool isSelectionActive = true;

    private void Awake()
    {
        card = GetComponent<Card>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!IsCardSelectable())
        {
            return;
        }

        transform.DOLocalMoveY(Settings.cardMouseEnterYPosition, mouseEnterTweenDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!IsCardSelectable())
        {
            return;
        }

        transform.DOLocalMoveY(Settings.cardStandartYPosition, mouseEnterTweenDuration);
    }

    public void DisableSelection()
    {
        isSelectionActive = false;
    }

    private bool IsCardSelectable()
    {
        if (!isSelectionActive)
        {
            return false;
        }

        if (card.isEnemy)
        {
            return false;
        }

        return true;
    }
}