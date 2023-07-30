using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(CardDetailsSO))]
public class CardDetailsSOEditor : Editor
{
    private GUIStyle headerStyle;

    private void OnEnable()
    {
        headerStyle = new GUIStyle();
        headerStyle.fontStyle = FontStyle.Bold;
        headerStyle.alignment = TextAnchor.MiddleLeft;
        headerStyle.normal.textColor = Color.gray;
        headerStyle.fontSize = 15;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        CardDetailsSO cardDetails = (CardDetailsSO)target;

        EditorGUILayout.LabelField("MAIN PARAMETERS", headerStyle);
        cardDetails.damage = EditorGUILayout.IntField("Damage", cardDetails.damage);
        cardDetails.health = EditorGUILayout.IntField("Health", cardDetails.health);
        cardDetails.manaCost = EditorGUILayout.IntField("Mana Cost", cardDetails.manaCost);

        EditorGUILayout.Space(10);
        cardDetails.cardTier = (CardTier)EditorGUILayout.EnumPopup("Card Tier", cardDetails.cardTier);
        cardDetails.cardAbility = (CardAbility)EditorGUILayout.EnumPopup("Card Ability", cardDetails.cardAbility);

        if (cardDetails.cardAbility == CardAbility.Battlecry)
        {
            cardDetails.battlecryCardAbility = (BattlecryCardAbility)EditorGUILayout
                .EnumPopup("Battlecry Card Ability", cardDetails.battlecryCardAbility);
        }

            EditorGUILayout.Space(10);
        cardDetails.characterName = EditorGUILayout.TextField("Character Name", cardDetails.characterName);
        cardDetails.cardDescription = EditorGUILayout.TextField("Card Description", cardDetails.cardDescription);

        EditorGUILayout.Space(10);
        cardDetails.characterAvatarSprite = (Sprite)EditorGUILayout.ObjectField("Character Avatar", 
            cardDetails.characterAvatarSprite,typeof(Sprite), false);
        cardDetails.avatarBackgroundSprite = (Sprite)EditorGUILayout.ObjectField("Avatar Background", 
            cardDetails.avatarBackgroundSprite,typeof(Sprite), false);

        if (GUI.changed)
        {
            EditorUtility.SetDirty(cardDetails);
        }
    }
}