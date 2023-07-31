using UnityEditor;
using UnityEngine;

public class CustomEditorPresets
{
    public GUIStyle headerStyle;

    public CustomEditorPresets()
    {
        headerStyle = new GUIStyle();
        headerStyle = new GUIStyle();
        headerStyle.fontStyle = FontStyle.Bold;
        headerStyle.alignment = TextAnchor.MiddleLeft;
        headerStyle.normal.textColor = Color.gray;
        headerStyle.fontSize = 15;
    }

    public void DrawHeader(string text)
    {
        EditorGUILayout.LabelField(text, headerStyle);
    }
}