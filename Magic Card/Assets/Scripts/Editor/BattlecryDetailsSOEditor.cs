using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(BattlecryDetailsSO))]
public class BattlecryDetailsSOEditor : Editor
{
    private CustomEditorPresets customEditorPresets;

    private void OnEnable()
    {
        customEditorPresets = new CustomEditorPresets();
    }

    public override void OnInspectorGUI()
    {
        BattlecryDetailsSO battlecryDetails = (BattlecryDetailsSO)target;

        battlecryDetails.battlecryCardAbility = (BattlecryCardAbility)EditorGUILayout
            .EnumPopup("Battlecry Ability", battlecryDetails.battlecryCardAbility);

        switch (battlecryDetails.battlecryCardAbility)
        {
            case BattlecryCardAbility.DrawCard:
                EditorGUILayout.Space(5);
                customEditorPresets.DrawHeader("DRAW CARD PARAMETERS");
                battlecryDetails.amountOfCardsToDraw = EditorGUILayout
                    .IntField("Amount Of Cards To Draw", battlecryDetails.amountOfCardsToDraw);
                break;

            case BattlecryCardAbility.SpawnCard:
                EditorGUILayout.Space(5);
                customEditorPresets.DrawHeader("SPAWN CARD PARAMETERS");
                battlecryDetails.cardToSpawnDetails = (CardDetailsSO)EditorGUILayout.ObjectField("Card To Spawn Details", 
                    battlecryDetails.cardToSpawnDetails, typeof(ScriptableObject), false);
                break;

            default: 
                break;
        }
    }
}