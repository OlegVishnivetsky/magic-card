using UnityEngine;

public class CardSpawner : SingletonMonobehaviour<CardSpawner>
{
    [Header("PLACED ZONE TRANSFORM COMPONENTS")]
    [SerializeField] private Transform playerPlacedZoneTransform;
    [SerializeField] private Transform enemyPlacedZoneTransform;

    public Transform GetPlayerPlacedZoneTransform()
    {
        return playerPlacedZoneTransform;
    }

    public Transform GetEnemyPlacedZoneTransform()
    {
        return enemyPlacedZoneTransform;
    }

    public void CreateAndPlaceCard(CardDetailsSO cardDetails, bool isEnemy)
    {
        Card spawnedCard = Instantiate(GameResources.Instance.cardPrefab);
        spawnedCard.SetCardDetails(cardDetails);
        Destroy(spawnedCard.GetComponent<CardPlacedPositionUI>());

        if (isEnemy)
        {
            PlaceEnemyCard(spawnedCard);
        }
        else
        {
            PlacePlayerCard(spawnedCard);
        }
    }

    public Card PlaceEnemyCard(Card cardToPlace)
    {
        return PlaceCard(cardToPlace, enemyPlacedZoneTransform);
    }

    public Card PlacePlayerCard(Card cardToPlace)
    {
        Destroy(cardToPlace.GetComponent<CardPlacedPositionUI>());
        return PlaceCard(cardToPlace, playerPlacedZoneTransform);
    }

    private Card PlaceCard(Card cardToPlace, Transform placedZoneTransform)
    {
        cardToPlace.transform.SetParent(placedZoneTransform);
        cardToPlace.gameObject.AddComponent<PlacedCard>();
        cardToPlace.cardSelector.DisableSelection();
        cardToPlace.transform.localScale = Vector3.one;

        StaticEventsHandler.InvokeCardPlacedEvent(cardToPlace);

        return cardToPlace;
    }
}