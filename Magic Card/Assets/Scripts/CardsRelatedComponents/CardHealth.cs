using System;
using UnityEngine;

[RequireComponent(typeof(Card))]
public class CardHealth : MonoBehaviour
{
    private Card card;

    private int currentHealth;

    public event Action<int> OnCardHealthChanged;

    private void Awake()
    {
        card = GetComponent<Card>();
    }

    private void Start()
    {
        SetUpCurrentHealth();
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        if (card.divineShield != null)
        {
            OnCardHealthChanged?.Invoke(currentHealth);
            Destroy(card.divineShield);
            return;
        }

        currentHealth -= damageAmount;
        OnCardHealthChanged?.Invoke(currentHealth);
    }

    public void DestroyCard()
    {
        StaticEventsHandler.InvokeCardDestroyedEvent(card);
        Destroy(card.gameObject);
    }

    private void SetUpCurrentHealth()
    {
        currentHealth = card.GetCardDetails().health;
        OnCardHealthChanged?.Invoke(currentHealth);
    }
}