using UnityEngine;

[DisallowMultipleComponent]
public class Deathrattle : BaseCardActions
{
    private void OnEnable()
    {
        StaticEventsHandler.OnCardDestroyed += StaticEventsHandler_OnCardDestroyed;
    }

    private void OnDisable()
    {
        StaticEventsHandler.OnCardDestroyed -= StaticEventsHandler_OnCardDestroyed;
    }

    private void StaticEventsHandler_OnCardDestroyed(Card destroyedCard)
    {
        if (destroyedCard == card)
        {
            HandleDeathrattleAbilities();
        }
    }

    private void HandleDeathrattleAbilities()
    {
        switch (card.GetCardDetails().cardActionDetails.cardActionType)
        {
            case CardActionType.DrawCard:
                HandleDrawCardAction();
                break;

            case CardActionType.SpawnCard:
                HandleSpawnCardAction();
                break;

            default:
                break;
        }
    }
}