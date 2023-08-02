using UnityEngine;

public class BaseScriptableObject : ScriptableObject
{
    public virtual void OnEnable()
    {
        hideFlags = HideFlags.DontUnloadUnusedAsset;
    }
}