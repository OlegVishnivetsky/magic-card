using TMPro;
using UnityEngine;

public class RivalsStatsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI manaText;

    private void OnEnable()
    {
        GameFlowController.OnAmountOfManaChanched += UpdateManaText;
    }

    private void OnDisable()
    {
        GameFlowController.OnAmountOfManaChanched -= UpdateManaText;
    }

    private void UpdateManaText(int currentMana)
    {
        manaText.text = $"{currentMana}";
    }
}