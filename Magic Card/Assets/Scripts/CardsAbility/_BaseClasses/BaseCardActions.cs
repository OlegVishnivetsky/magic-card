public abstract class BaseCardActions : CardAbility
{
    protected Card card;

    protected virtual void Awake()
    {
        card = GetComponent<Card>();
    }

    protected void HandleDrawCardAction()
    {
        if (card.IsEnemy)
        {
            GameFlowController.Instance.GetEnemyHand()
                .TakeCertainAmountOfRandomCardFromDeck(card.GetCardDetails().cardActionDetails.amountOfCardsToDraw);
        }
        else
        {
            GameFlowController.Instance.GetPlayerHand()
                .TakeCertainAmountOfRandomCardFromDeck(card.GetCardDetails().cardActionDetails.amountOfCardsToDraw);
        }
    }

    protected void HandleSpawnCardAction()
    {
        foreach (CardDetailsSO cardToSpawnDetails in card.GetCardDetails().cardActionDetails.cardToSpawnDetailsList)
        {
            CardSpawner.Instance.CreateAndPlaceCard(cardToSpawnDetails, card.IsEnemy);
        }
    }
}