using UnityEngine;
using TMPro;

public class CurrentDeckZoneUI : MonoBehaviour
{
    [Header("CURRENT DECK ZONE")]
    [SerializeField] private CurrentDeckZone currentDeckZone;
    [Header("TEXT COMPONENTS")]
    [SerializeField] private TextMeshProUGUI currentDeckToEditText;

    private void OnEnable()
    {
        currentDeckZone.OnCurrentDeckToEditChanged += CurrentDeckZone_OnCurrentDeckToEditChanged;
    }

    private void OnDisable()
    {
        currentDeckZone.OnCurrentDeckToEditChanged -= CurrentDeckZone_OnCurrentDeckToEditChanged;
    }

    private void CurrentDeckZone_OnCurrentDeckToEditChanged(bool isEnemyDeck)
    {
        if (isEnemyDeck)
        {
            UpdateCurrentDeckToEditText("Enemy Deck");
        }
        else
        {
            UpdateCurrentDeckToEditText("Player Deck");
        }
    }

    private void UpdateCurrentDeckToEditText(string text)
    {
        currentDeckToEditText.text = text;
    }
}