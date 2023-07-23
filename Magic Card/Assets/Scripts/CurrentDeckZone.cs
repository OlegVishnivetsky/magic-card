using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CurrentDeckZone : MonoBehaviour, IDropHandler
{
    [Header("DECKS")]
    [SerializeField] private CardDeckSO playerDeck;
    [SerializeField] private CardDeckSO enemyDeck;

    [Header("TRANSFORM COMPONENTS")]
    [SerializeField] private Transform deckContentTransform;

    private List<Card> spawnedCardsFromDeck = new List<Card>();

    private CardDeckSO currentDeckToEdit;

    public event Action<bool> OnCurrentDeckToEditChanged;

    private void Start()
    {
        SetCurrentDeckAndInstantiateCardsFromPlayerDeck();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Card card = eventData.pointerDrag.GetComponent<Card>();

        if (card != null)
        {
            currentDeckToEdit.cards.Add(card.GetCardDetails());
            InstantiateCard(card.GetCardDetails());
        }
    }

    public void SetCurrentDeckAndInstantiateCardsFromPlayerDeck()
    {
        currentDeckToEdit = playerDeck;

        OnCurrentDeckToEditChanged?.Invoke(currentDeckToEdit.isEnemyDeck);

        RemoveAllSpawnedCardsFromDeck();
        InstantiateCardsFromDeck(currentDeckToEdit);
    }

    public void SetCurrentDeckAndInstantiateCardsFromEnemyDeck()
    {
        currentDeckToEdit = enemyDeck;

        OnCurrentDeckToEditChanged?.Invoke(currentDeckToEdit.isEnemyDeck);

        RemoveAllSpawnedCardsFromDeck();
        InstantiateCardsFromDeck(currentDeckToEdit);
    }

    private void InstantiateCardsFromDeck(CardDeckSO cardDeck)
    {
        foreach (CardDetailsSO cardDetails in cardDeck.cards)
        {
            InstantiateCard(cardDetails);
        }
    }

    private void InstantiateCard(CardDetailsSO cardDetails)
    {
        Card cardObject = Instantiate(cardDetails.prefab, deckContentTransform);
        cardObject.SetCardDetails(cardDetails);

        Destroy(cardObject.GetComponent<CardSelector>());
        Destroy(cardObject.GetComponent<CardController>());

        spawnedCardsFromDeck.Add(cardObject);
    }

    private void RemoveAllSpawnedCardsFromDeck()
    {
        foreach (Card card in spawnedCardsFromDeck)
        {
            Destroy(card.gameObject);
        }

        spawnedCardsFromDeck.Clear();
    }
}