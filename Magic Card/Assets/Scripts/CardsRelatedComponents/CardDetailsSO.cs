using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Cards/Card Details", fileName = "_CardDetails")]
public class CardDetailsSO : BaseScriptableObject
{
    public int damage;
    public int health;
    public int manaCost;

    public CardTier cardTier;
    public CardAbilityType cardAbility;
    public CardActionsDetailsSO cardActionDetails;

    public string characterName;
    public string cardDescription;

    public Sprite characterAvatarSprite;
    public Sprite avatarBackgroundSprite;
}