using UnityEngine;

public class GameResources : SingletonMonobehaviour<GameResources>
{
    [Header("CARD TEMPLATE PREFAB")]
    public Card cardPrefab;

    [Header("Card Placed Position Object")]
    public GameObject cardPlacedPositionObject;
}