using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCardPlacingZone : MonoBehaviour, IDropHandler
{
    [SerializeField] private RivalsStats rivalsStats;

    private int numberOfPlacedCards = 0;

    public void OnDrop(PointerEventData eventData)
    {
        CheckForNumberOfPlacedCards();

        if (numberOfPlacedCards >= Settings.maxNumberOfPlacedCards)
        {
            return;
        }

        if (GameFlowController.Instance.GetCurrentTurn() == Turn.EnemyTurn)
        {
            return;
        }

        Card card = eventData.pointerDrag.GetComponent<Card>();

        if (card.GetComponent<PlacedCard>() != null)
        {
            return;
        }

        if (rivalsStats.GetPlayerCurrentMana() - card.GetCardDetails().manaCost < 0)
        {
            return;
        }

        rivalsStats.SpendPlayerMana(card.GetCardDetails().manaCost);

        CardSpawner.Instance.PlacePlayerCard(card);

        numberOfPlacedCards++;
    }

    private void CheckForNumberOfPlacedCards()
    {
        numberOfPlacedCards = transform.GetComponentsInChildren<PlacedCard>().ToList().Count;
    }
}