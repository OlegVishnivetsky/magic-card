using UnityEngine;

public class TestSaving : MonoBehaviour
{
    private Card card;

    private SaveSystem saveSystem;

    private void OnEnable()
    {
        StaticEventsHandler.OnCardPlaced += StaticEventsHandler_OnCardPlaced;
    }

    private void OnDisable()
    {
        StaticEventsHandler.OnCardPlaced += StaticEventsHandler_OnCardPlaced;
    }

    private void Start()
    {
        saveSystem = new SaveSystem();
        saveSystem.Initialize();
    }

    private void StaticEventsHandler_OnCardPlaced(Card card)
    {
        this.card = card;

        this.card.GetCardDetails().cardData.damage = 5;

        string json = saveSystem.GetJsonFromData(card.GetCardDetails().cardData);

        saveSystem.Save(json, "cardData");

        CardDetailsData cardDetailsData = saveSystem.Load<CardDetailsData>("cardData");

        this.card.SetCardDetailsData(cardDetailsData);
        this.card.GetComponent<CardUI>().UpdateCardUI();
    }
}