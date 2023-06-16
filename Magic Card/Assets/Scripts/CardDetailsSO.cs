using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/CardDetails", fileName = "_CardDetails")]
public class CardDetailsSO : ScriptableObject
{
    public Card prefab;

    [Header("MAIN PARAMETERS")]
    public int damage;
    public int health;
    public int cost;
    public string characterName;

    [Header("UI")]
    public Sprite characterAvatarSprite;
    public Sprite avatarBackgroundSprite;
}