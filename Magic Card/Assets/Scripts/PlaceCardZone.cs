using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceCardZone : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject playerDeck;
    [SerializeField] private TextMeshProUGUI manaText;
    private int currentMana = 10;
    private int cardPlaced = 0;
    private const int maxCardPlaced = 6;

    private void OnEnable()
    {
        GameController.OnTurnChanged += GameController_OnTurnChanged;
    }

    private void OnDisable()
    {
        GameController.OnTurnChanged -= GameController_OnTurnChanged;
    }

    private void Start()
    {
        manaText.text = $"{currentMana}";
    }

    public void OnDrop(PointerEventData eventData)
    {
        CardController dropedCard = eventData.pointerDrag.GetComponent<CardController>();
        Card card = eventData.pointerDrag.GetComponent<Card>();

        cardPlaced++;

        if (cardPlaced >= maxCardPlaced)
        {
            return;
        }

        if (currentMana - card.GetCardDetails().cost >= 0)
        {
            currentMana -= card.GetCardDetails().cost;
            manaText.text = $"{currentMana}";
        }
        else
        {
            return;
        }

        GameController.Instance.playerPlacedCard.Add(card);
        dropedCard.isPlaced = true;
        dropedCard.transform.SetParent(playerDeck.transform);
    }

    private void GameController_OnTurnChanged(int obj)
    {
        currentMana = 10;
        manaText.text = $"{currentMana}";
    }
}