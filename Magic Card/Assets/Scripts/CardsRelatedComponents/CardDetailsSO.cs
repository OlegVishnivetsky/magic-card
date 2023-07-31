using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Cards/Card Details", fileName = "_CardDetails")]
public class CardDetailsSO : ScriptableObject
{
    public int damage;
    public int health;
    public int manaCost;

    public CardTier cardTier;
    public CardAbility cardAbility;
    public BattlecryDetailsSO battlecryDetailsSO;

    public string characterName;
    public string cardDescription;

    public Sprite characterAvatarSprite;
    public Sprite avatarBackgroundSprite;
}