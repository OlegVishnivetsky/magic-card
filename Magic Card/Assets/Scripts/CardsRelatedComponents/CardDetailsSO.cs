using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/CardDetails", fileName = "_CardDetails")]
public class CardDetailsSO : ScriptableObject
{
    public Card prefab;

    [Header("MAIN PARAMETERS")]
    public int damage;
    public int health;
    public int manaCost;

    [Space(10)]
    public CardTier cardTier;
    public CardType cardType;

    [Space(10)]
    public string characterName;
    public string cardDescription;

    [Header("UI")]
    public Sprite characterAvatarSprite;
    public Sprite avatarBackgroundSprite;
}