using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(CardUI))]
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
        switch (cardDetails.cardAbility)
        {
            case CardAbility.Rush:
                cardAttack.IsCanAttack = true;
                break;

            case CardAbility.DivineShield:
                divineShield = gameObject.AddComponent<DivineShield>();
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