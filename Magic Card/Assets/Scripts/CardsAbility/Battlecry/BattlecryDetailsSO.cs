using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Cards Ability/Battlecry Details", fileName = "_BattlecryDetails")]
public class BattlecryDetailsSO : BaseScriptableObject
{
    public BattlecryCardAbility battlecryCardAbility;

    public int amountOfCardsToDraw;

    public CardDetailsSO cardToSpawnDetails;
}