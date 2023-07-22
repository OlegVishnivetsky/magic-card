using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/CardsCollection", fileName = "_CardsCollection")]
public class CardsCollectionSO : ScriptableObject
{
    public List<CardDetailsSO> cardList;
}