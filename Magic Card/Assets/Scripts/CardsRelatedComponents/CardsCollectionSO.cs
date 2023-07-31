using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Cards/Cards Collection", fileName = "_CardsCollection")]
public class CardsCollectionSO : ScriptableObject
{
    public List<CardDetailsSO> cardList;
}