using TMPro;
using UnityEngine;

public class RivalsStatsUI : MonoBehaviour
{
    [Header("PLAYER TEXT COMPONENTS")]
    [SerializeField] private TextMeshProUGUI playerHealthText;
    [SerializeField] private TextMeshProUGUI playerManaText;

    [Header("ENEMY TEXT COMPONENTS")]
    [SerializeField] private TextMeshProUGUI enemyHealthText;
    [SerializeField] private TextMeshProUGUI enemyManaText;

    private void OnEnable()
    {
        StaticEventsHandler.OnPlayerAmountOfHealthChanged += StaticEventsHandler_OnPlayerAmountOfHealthChanged;
        StaticEventsHandler.OnPlayerAmountOfManaChanged += StaticEventsHandler_OnPlayerAmountOfManaChanged;

        StaticEventsHandler.OnEnemyAmountOfHealthChanged += StaticEventsHandler_OnEnemyAmountOfHealthChanged;
        StaticEventsHandler.OnEnemyAmountOfManaChanged += StaticEventsHandler_OnEnemyAmountOfManaChanged;
    }

    private void OnDisable()
    {
        StaticEventsHandler.OnPlayerAmountOfHealthChanged -= StaticEventsHandler_OnPlayerAmountOfHealthChanged;
        StaticEventsHandler.OnPlayerAmountOfManaChanged -= StaticEventsHandler_OnPlayerAmountOfManaChanged;

        StaticEventsHandler.OnEnemyAmountOfHealthChanged -= StaticEventsHandler_OnEnemyAmountOfHealthChanged;
        StaticEventsHandler.OnEnemyAmountOfManaChanged -= StaticEventsHandler_OnEnemyAmountOfManaChanged;
    }

    private void StaticEventsHandler_OnPlayerAmountOfHealthChanged(int currentHealth)
    {
        UpdatePlayerHealthText(currentHealth);
    }

    private void StaticEventsHandler_OnPlayerAmountOfManaChanged(int currentMana)
    {
        UpdatePlayerManaText(currentMana);
    }

    private void StaticEventsHandler_OnEnemyAmountOfHealthChanged(int currentHealth)
    {
        UpdateEnemyHealthText(currentHealth);
    }

    private void StaticEventsHandler_OnEnemyAmountOfManaChanged(int currentMana)
    {
        UpdateEnemyManaText(currentMana);
    }

    public void UpdatePlayerHealthText(int currentHealth)
    {
        playerHealthText.text = currentHealth.ToString();
    }

    public void UpdatePlayerManaText(int currentMana)
    {
        playerManaText.text = currentMana.ToString();
    }

    public void UpdateEnemyHealthText(int currentHealth)
    {
        enemyHealthText.text = currentHealth.ToString();
    }

    public void UpdateEnemyManaText(int currentMana)
    {
        enemyManaText.text = currentMana.ToString();
    }
}