using UnityEngine;

public class CardPlacedPositionUI : MonoBehaviour
{
    private Card card;

    private GameObject cardPlacedPositionUIObject;

    private void Awake()
    {
        card = GetComponent<Card>();
    }

    private void OnEnable()
    {
        card.OnCardDragged += Card_OnCardDragged;
    }

    private void OnDisable()
    {
        card.OnCardDragged -= Card_OnCardDragged;
    }

    private void OnDestroy()
    {
        Destroy(cardPlacedPositionUIObject);
    }

    private void Card_OnCardDragged(bool isDragged)
    {
        if (isDragged)
        {
            cardPlacedPositionUIObject = Instantiate(GameResources.Instance.cardPlacedPositionObject, 
                CardSpawner.Instance.GetPlayerPlacedZoneTransform());
        }
        else
        {
            Destroy(cardPlacedPositionUIObject);
        }
    }
}