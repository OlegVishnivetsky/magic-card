using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Card Actions", fileName = "_CardActionsDetails")]
public class CardActionsDetailsSO : BaseScriptableObject
{
    public CardActionType cardActionType;

    public int amountOfCardsToDraw;

    public List<CardDetailsSO> cardToSpawnDetailsList;
}