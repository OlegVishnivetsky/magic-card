using TMPro;
using UnityEngine;

public class RivalsStatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI manaText;

    private void OnEnable()
    {
        StaticEventsHandler.OnAmountOfManaChanched += UpdateManaText;
    }

    private void OnDisable()
    {
        StaticEventsHandler.OnAmountOfManaChanched -= UpdateManaText;
    }

    private void UpdateManaText(int currentMana)
    {
        manaText.text = $"{currentMana}";
    }
}