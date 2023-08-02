using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [Header("CARDS COLLECTION")]
    [SerializeField] private CardsCollectionSO allCardsCollection;

    [Header("DECKS")]
    [SerializeField] private CardDeckSO playerDeck;
    [SerializeField] private CardDeckSO enemyDeck;

    private static bool isDeckLoadedOnStart = false;

    private List<string> savedCardCharacterNames = new List<string>();

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (!isDeckLoadedOnStart)
        {
            isDeckLoadedOnStart = true;
            LoadPlayerAndEnemyDecks();
        }
    }

    private void OnApplicationQuit()
    {
        SavePlayerAndEnemyDecks();
    }

    public void SavePlayerAndEnemyDecks()
    {
        SaveDeck(playerDeck, Settings.playerDeckSavingKey);
        SaveDeck(enemyDeck, Settings.enemyDeckSavingKey);
    }

    public void LoadPlayerAndEnemyDecks()
    {
        LoadDeck(playerDeck, Settings.playerDeckSavingKey);
        LoadDeck(enemyDeck, Settings.enemyDeckSavingKey);
    }

    public void SaveDeck(CardDeckSO cardDeckToSave, string key)
    {
        savedCardCharacterNames.Clear();

        foreach (CardDetailsSO card in cardDeckToSave.cards)
        {
            savedCardCharacterNames.Add(card.characterName);
        }

        string path = Application.persistentDataPath + "/saves/" + key;
        string json = JsonConvert.SerializeObject(savedCardCharacterNames, Formatting.Indented);

        File.WriteAllText(path, json);
    }

    public void LoadDeck(CardDeckSO cardDeckLoadTo, string key)
    {
        string path = Application.persistentDataPath + "/saves/" + key;

        if (!File.Exists(path))
        {
            return;
        }

        string json = File.ReadAllText(path);

        cardDeckLoadTo.cards.Clear();

        savedCardCharacterNames = JsonConvert.DeserializeObject<List<string>>(json);

        foreach (string cardName in savedCardCharacterNames)
        {
            foreach (CardDetailsSO card in allCardsCollection.cardList)
            {
                if (card.characterName == cardName)
                {
                    cardDeckLoadTo.cards.Add(card);
                }
            }
        }
    }
}