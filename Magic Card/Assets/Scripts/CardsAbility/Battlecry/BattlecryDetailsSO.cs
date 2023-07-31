using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Cards Ability/Battlecry Details", fileName = "_BattlecryDetails")]
public class BattlecryDetailsSO : ScriptableObject
{
    public BattlecryCardAbility battlecryCardAbility;

    public int amountOfCardsToDraw;
}