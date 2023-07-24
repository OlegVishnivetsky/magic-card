using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardForEditDeckController : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;

    private CanvasGroup canvasGroup;
    private Camera cameraCache;
    private Vector3 draggedCardStartPosition;

    private EditDeckCardsZone editDeckCardsZone;

    private void Awake()
    {
        cameraCache = Camera.main;

        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        GetNewGridLayoutGroupComponent();
    }

    public void SetEditDeckCardsZone(EditDeckCardsZone editDeckCardsZone)
    {
        this.editDeckCardsZone = editDeckCardsZone;
    }

    public void GetNewGridLayoutGroupComponent()
    {
        gridLayoutGroup = GetComponentInParent<GridLayoutGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        draggedCardStartPosition = transform.localPosition;
        transform.SetParent(canvas.transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePosition = cameraCache.ScreenToWorldPoint(eventData.position);
        mousePosition.z = 0;

        transform.position = mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (editDeckCardsZone != null)
        {
            editDeckCardsZone.ResetCardsSort();
        }

        canvasGroup.blocksRaycasts = true;

        transform.SetParent(gridLayoutGroup.transform);
        transform.localPosition = draggedCardStartPosition;
        draggedCardStartPosition = Vector2.zero;
    }
}