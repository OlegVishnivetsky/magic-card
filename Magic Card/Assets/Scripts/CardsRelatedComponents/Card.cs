using System;
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

    [HideInInspector] public Taunt taunt;
    [HideInInspector] public DivineShield divineShield;

    public event Action<bool> OnCardDragged;

    private bool isDragged;

    public bool IsDragged
    {
        get
        {
            return isDragged;
        }
        set
        {
            if (isDragged != value)
            {
                isDragged = value;

                OnCardDragged?.Invoke(IsDragged);
            }
        }
    }

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
            case CardAbilityType.Rush:
                cardAttack.IsCanAttack = true;
                break;

            case CardAbilityType.DivineShield:
                divineShield = gameObject.AddComponent<DivineShield>();
                break;

            case CardAbilityType.Battlecry:
                gameObject.AddComponent<Battlecry>();
                break;

            case CardAbilityType.Taunt:
                taunt = gameObject.AddComponent<Taunt>();
                break;

            case CardAbilityType.Deathrattle:
                gameObject.AddComponent<Deathrattle>();
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