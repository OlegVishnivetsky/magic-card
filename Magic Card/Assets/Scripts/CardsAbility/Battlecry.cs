using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Card))]
public class Battlecry : MonoBehaviour
{
    private Card card;

    private void Awake()
    {
        card = GetComponent<Card>();
    }

    private void OnEnable()
    {
        StaticEventsHandler.OnCardPlaced += StaticEventsHandler_OnCardPlaced;
    }

    private void OnDisable()
    {
        StaticEventsHandler.OnCardPlaced += StaticEventsHandler_OnCardPlaced;
    }

    private void StaticEventsHandler_OnCardPlaced(Card placedCard)
    {
        HandleBattlecryAbilities();
        HandleBattlecryAbilities();
        HandleBattlecryAbilities();
        HandleBattlecryAbilities();
    }

    private void HandleBattlecryAbilities()
    {
        switch (card.GetCardDetails().battlecryCardAbility)
        {
            case BattlecryCardAbility.DrawCard:
                HandleBattlecryDrawCardAbility();
                break;

            default:
                break;
        }
    }

    private void HandleBattlecryDrawCardAbility()
    {
        if (card.IsEnemy)
        {
            GameFlowController.Instance.GetEnemyHand().TakeRandomCardFromDeck();
        }
        else
        {
            GameFlowController.Instance.GetPlayerHand().TakeRandomCardFromDeck();
        }
    }
}