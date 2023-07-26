using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : SingletonMonobehaviour<SaveGameManager>
{
    private SaveSystem saveSystem;

    private void Start()
    {
        saveSystem = new SaveSystem();
    }
}