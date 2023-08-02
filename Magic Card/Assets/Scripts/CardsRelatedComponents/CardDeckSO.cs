using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Cards/Card Deck", fileName = "_CardDeck")]
public class CardDeckSO : BaseScriptableObject
{
    [Header("DECK")]
    public List<CardDetailsSO> cards;

    public bool isEnemyDeck = false;
}