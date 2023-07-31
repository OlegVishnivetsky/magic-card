using UnityEditor;

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

        if (battlecryDetails.battlecryCardAbility == BattlecryCardAbility.DrawCard)
        {
            EditorGUILayout.Space(5);
            customEditorPresets.DrawHeader("DRAW CARD PARAMETERS");
            battlecryDetails.amountOfCardsToDraw = EditorGUILayout
                .IntField("Amount Of Cards To Draw", battlecryDetails.amountOfCardsToDraw);
        }
    }
}