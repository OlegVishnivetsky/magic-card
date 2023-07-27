using UnityEngine;

[RequireComponent(typeof(CardHealth))]
public class Card : MonoBehaviour
{
    [Header("CARD DETAILS")]
    [SerializeField] private CardDetailsSO cardDetails;

    [Header("MAIN COMPONENTS")]
    public CardHealth cardHealth;
    public CardAttack cardAttack;
    public CardSelector cardSelector;
    public CardController cardController;

    [HideInInspector] public DivineShield divineShield;

    public bool IsEnemy { get; set; }

    private void Start()
    {
        SetUpCardByCardType();
    }

    public CardDetailsSO GetCardDetails()
    {
        return cardDetails;
    }

    public void SetCardDetails(CardDetailsSO cardDetails)
    {
        this.cardDetails = cardDetails;
    }

    private void SetUpCardByCardType()
    {
        switch (cardDetails.cardType)
        {
            case CardType.Rush:
                cardAttack.IsCanAttack = true;
                break;

            case CardType.DivineShield:
                divineShield = gameObject.AddComponent<DivineShield>();
                divineShield.IsDivineShieldActive = true;
                break;

            default: 
                break;
        }
    }

    #region Validation

#if UNITY_EDITOR

    private void OnValidate()
    {
        if (cardDetails == null)
        {
            Debug.Log("Card details is null in " + gameObject.name);
        }
    }

#endif

    #endregion Validation
}