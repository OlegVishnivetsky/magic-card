using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(CardDetailsSO))]
public class CardDetailsSOEditor : Editor
{
    private CustomEditorPresets customEditorPresets;

    private void OnEnable()
    {
        customEditorPresets = new CustomEditorPresets();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        CardDetailsSO cardDetails = (CardDetailsSO)target;

        customEditorPresets.DrawHeader("MAIN PARAMETERS");
        cardDetails.damage = EditorGUILayout.IntField("Damage", cardDetails.damage);
        cardDetails.health = EditorGUILayout.IntField("Health", cardDetails.health);
        cardDetails.manaCost = EditorGUILayout.IntField("Mana Cost", cardDetails.manaCost);

        EditorGUILayout.Space(10);
        cardDetails.cardTier = (CardTier)EditorGUILayout.EnumPopup("Card Tier", cardDetails.cardTier);
        cardDetails.cardAbility = (CardAbility)EditorGUILayout.EnumPopup("Card Ability", cardDetails.cardAbility);

        if (cardDetails.cardAbility == CardAbility.Battlecry)
        {
            EditorGUILayout.Space(5);
            customEditorPresets.DrawHeader("BATTLECRY PARAMETERS");
            cardDetails.battlecryDetailsSO = (BattlecryDetailsSO)EditorGUILayout.ObjectField("Battlecry Details",
                cardDetails.battlecryDetailsSO, typeof(ScriptableObject), false);
        }

        EditorGUILayout.Space(10);
        cardDetails.characterName = EditorGUILayout.TextField("Character Name", cardDetails.characterName);
        cardDetails.cardDescription = EditorGUILayout.TextField("Card Description", cardDetails.cardDescription);

        EditorGUILayout.Space(10);
        cardDetails.characterAvatarSprite = (Sprite)EditorGUILayout.ObjectField("Character Avatar",
            cardDetails.characterAvatarSprite, typeof(Sprite), false);
        cardDetails.avatarBackgroundSprite = (Sprite)EditorGUILayout.ObjectField("Avatar Background",
            cardDetails.avatarBackgroundSprite, typeof(Sprite), false);

        if (GUI.changed)
        {
            EditorUtility.SetDirty(cardDetails);
        }
    }
}