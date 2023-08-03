using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(CardActionsDetailsSO))]
public class CardActionsSOEditor: Editor
{
    private CustomEditorPresets customEditorPresets;

    private void OnEnable()
    {
        customEditorPresets = new CustomEditorPresets();
    }

    public override void OnInspectorGUI()
    {
        CardActionsDetailsSO cardActionDetails = (CardActionsDetailsSO)target;

        cardActionDetails.cardActionType = (CardActionType)EditorGUILayout
            .EnumPopup("Battlecry Ability", cardActionDetails.cardActionType);

        switch (cardActionDetails.cardActionType)
        {
            case CardActionType.DrawCard:
                DisplayDrawCardParameters(cardActionDetails);
                break;

            case CardActionType.SpawnCard:
                DisplaySpawnCardParameters(cardActionDetails);
                break;

            default: 
                break;
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(cardActionDetails);
        }
    }

    private void DisplayDrawCardParameters(CardActionsDetailsSO battlecryDetails)
    {
        EditorGUILayout.Space(5);
        customEditorPresets.DrawHeader("DRAW CARD PARAMETERS");

        battlecryDetails.amountOfCardsToDraw = EditorGUILayout
            .IntField("Amount Of Cards To Draw", battlecryDetails.amountOfCardsToDraw);
    }

    private void DisplaySpawnCardParameters(CardActionsDetailsSO battlecryDetails)
    {
        EditorGUILayout.Space(5);
        customEditorPresets.DrawHeader("SPAWN CARD PARAMETERS");

        EditorGUILayout.PropertyField(serializedObject.FindProperty("cardToSpawnDetailsList"));
        serializedObject.ApplyModifiedProperties();
    }
}