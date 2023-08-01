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
        if (placedCard == card)
        {
            HandleBattlecryAbilities();
        }
    }

    private void HandleBattlecryAbilities()
    {
        switch (card.GetCardDetails().battlecryDetailsSO.battlecryCardAbility)
        {
            case BattlecryCardAbility.DrawCard:
                HandleBattlecryDrawCardAbility();
                break;

            case BattlecryCardAbility.SpawnCard:
                HandleBattlecrySpawnCardAbility();
                break;

            default:
                break;
        }
    }

    private void HandleBattlecryDrawCardAbility()
    {
        if (card.IsEnemy)
        {
            GameFlowController.Instance.GetEnemyHand()
                .TakeCertainAmountOfRandomCardFromDeck(card.GetCardDetails().battlecryDetailsSO.amountOfCardsToDraw);
        }
        else
        {
            GameFlowController.Instance.GetPlayerHand()
                .TakeCertainAmountOfRandomCardFromDeck(card.GetCardDetails().battlecryDetailsSO.amountOfCardsToDraw);
        }
    }

    private void HandleBattlecrySpawnCardAbility()
    {
        CardSpawner.Instance
            .CreateAndPlaceCard(card.GetCardDetails().battlecryDetailsSO.cardToSpawnDetails, card.IsEnemy);
    }
}