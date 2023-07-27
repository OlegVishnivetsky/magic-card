using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSave : MonoBehaviour
{
    [SerializeField] private CardDetailsSO cardDetailsSO;
    [SerializeField] private CardDeckSO cardDeckSO;

    private void Start()
    {
        string json = JsonUtility.ToJson(cardDeckSO);

        Debug.Log(json);
    }
}