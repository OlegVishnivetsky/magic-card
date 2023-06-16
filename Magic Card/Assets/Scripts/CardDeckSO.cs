using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/CardDeck", fileName = "_CardDeck")]
public class CardDeckSO : ScriptableObject
{
    [Header("DECK")]
    public List<CardDetailsSO> cards;
    public bool isEnemyDeck = false;
}