using UnityEngine;

public class RivalsStats : MonoBehaviour
{
    private int playerCurrentMana;
    private int enemyCurrentMana;

    private int playerCurrentHealth;
    private int enemyCurrentHealth;

    private int playerMaxMana;
    private int enemyMaxMana;

    private void OnEnable()
    {
        StaticEventsHandler.OnTurnChanged += StaticEventsHandler_OnTurnChanged;
    }

    private void OnDisable()
    {
        StaticEventsHandler.OnTurnChanged -= StaticEventsHandler_OnTurnChanged;
    }

    private void Start()
    {
        playerCurrentMana = Settings.startingAmountOfRivalsMana;
        enemyCurrentMana = Settings.startingAmountOfRivalsMana;

        playerCurrentHealth = Settings.startingAmountOfRivalsHealth;
        enemyCurrentHealth = Settings.startingAmountOfRivalsHealth;

        playerMaxMana = Settings.startingAmountOfRivalsMana;
        enemyMaxMana = Settings.startingAmountOfRivalsMana;

        StaticEventsHandler.InvokePlayerAmountOfHealthChangedEvent(playerCurrentHealth);
        StaticEventsHandler.InvokePlayerAmountOfManaChangedEvent(playerCurrentMana);

        StaticEventsHandler.InvokeEnemyAmountOfHealthChangedEvent(enemyCurrentHealth);
        StaticEventsHandler.InvokeEnemyAmountOfManaChangedEvent(enemyCurrentMana);
    }

    public int GetPlayerCurrentMana()
    {
        return playerCurrentMana;
    }

    public int GetEnemyCurrentMana()
    {
        return enemyCurrentMana;
    }

    public void DamagePlayerHealth(int amount)
    {
        playerCurrentHealth -= amount;
        StaticEventsHandler.InvokePlayerAmountOfHealthChangedEvent(playerCurrentHealth);
    }

    public void DamageEnemyHealth(int amount)
    {
        enemyCurrentHealth -= amount;
        StaticEventsHandler.InvokeEnemyAmountOfHealthChangedEvent(enemyCurrentHealth);
    }

    public void SpendPlayerMana(int amount)
    {
        playerCurrentMana -= amount;
        StaticEventsHandler.InvokePlayerAmountOfManaChangedEvent(playerCurrentMana);
    }

    public void SpendEnemyMana(int amount)
    {
        enemyCurrentMana -= amount;
        StaticEventsHandler.InvokeEnemyAmountOfManaChangedEvent(enemyCurrentMana);
    }

    private void StaticEventsHandler_OnTurnChanged(Turn turn)
    {
        if (turn == Turn.PlayerTurn)
        {
            enemyMaxMana++;

            if (enemyMaxMana > Settings.maxAmountOfRivalsMana)
            {
                enemyMaxMana--;
            }

            ResetEnemyMana();
        }
        else
        {
            playerMaxMana++;

            if (playerMaxMana > Settings.maxAmountOfRivalsMana)
            {
                playerMaxMana--;
            }

            ResetPlayerMana();
        }
    }

    private void ResetPlayerMana()
    {
        playerCurrentMana = playerMaxMana;
        StaticEventsHandler.InvokePlayerAmountOfManaChangedEvent(playerCurrentMana);
    }

    private void ResetEnemyMana()
    {
        enemyCurrentMana = enemyMaxMana;
        StaticEventsHandler.InvokeEnemyAmountOfManaChangedEvent(enemyCurrentMana);
    }
}