using UnityEngine;

public class EditDeckCardsZone : MonoBehaviour
{
    [Header("CARDS")]
    [SerializeField] private CardsCollectionSO cardsCollection;

    [Header("TRANSFORM COMPONENTS")]
    [SerializeField] private Transform cardsTransform;

    private void Start()
    {
        InstantiateCardsCollection();
    }

    private void InstantiateCardsCollection()
    {
        foreach (CardDetailsSO cardDetails in cardsCollection.cardList)
        {
            Card cardObject = Instantiate(cardDetails.prefab, cardsTransform);
            cardObject.SetCardDetails(cardDetails);
            cardObject.gameObject.AddComponent<CardForEditDeckController>();

            Destroy(cardObject.GetComponent<CardSelector>());
            Destroy(cardObject.GetComponent<CardController>());
        }
    }
}