using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    private Card card;

    [Header("TEXT COMPONENTS")]
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI manaCostText;

    [Space(5)]
    [SerializeField] private TextMeshProUGUI cardTierText;
    [SerializeField] private TextMeshProUGUI cardTypeText;

    [Space(5)]
    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private TextMeshProUGUI cardDescriptionText;

    [Header("IMAGE COMPONENTS")]
    [SerializeField] private Image cardImage;
    [SerializeField] private Image avatarImage;
    [SerializeField] private Image avatarBackgroundImage;
    [SerializeField] private Image divineShieldImage;

    private void Awake()
    {
        card = GetComponent<Card>();
    }

    private void OnEnable()
    {
        StaticEventsHandler.OnCardPlaced += StaticEventsHandler_OnCardPlaced;
        card.cardHealth.OnCardHealthChanged += CardHealth_OnCardHealthChanged;
    }

    private void OnDisable()
    {
        StaticEventsHandler.OnCardPlaced -= StaticEventsHandler_OnCardPlaced;
        card.cardHealth.OnCardHealthChanged -= CardHealth_OnCardHealthChanged;
    }

    private void Start()
    {
        if (card.IsEnemy)
        {
            HideCardUI();
        }
        else
        {
            UpdateCardUI();
        }

        HideDivineShieldImage();
    }

    private void CardHealth_OnCardHealthChanged(int currentHealth)
    {
        UpdateCardStatsTexts();
        HideDivineShieldImage();
    }

    private void StaticEventsHandler_OnCardPlaced(Card placedCard)
    {
        if (placedCard == card)
        {
            ShowDivineShieldImage();
        }

        if (placedCard == card && card.IsEnemy)
        {
            UpdateCardUI();
        }
    }

    public void UpdateCardUI()
    {
        HideCardUI();
        UpdateCardOtherTexts();
        UpdateCardNameAndDescriptionTexts();
        UpdateCardStatsTexts();
        UpdateCardImages();
        SetCardColorByTier();     
    }

    public void UpdateCardOtherTexts()
    {
        if (cardTypeText != null)
            cardTypeText.text = Enum.GetName(typeof(CardAbilityType), card.GetCardDetails().cardAbility);
        if (cardTierText != null)
            cardTierText.text = Enum.GetName(typeof(CardTier), card.GetCardDetails().cardTier);
    }

    public void UpdateCardNameAndDescriptionTexts()
    {
        if (characterNameText != null)
            characterNameText.text = card.GetCardDetails().characterName;
        if (cardDescriptionText != null)
            cardDescriptionText.text = card.GetCardDetails().cardDescription;
    }

    public void UpdateCardStatsTexts()
    {
        if (damageText != null)
            damageText.text = card.GetCardDetails().damage.ToString();
        if (healthText != null)
            healthText.text = card.cardHealth.GetCurrentHealth().ToString();
        if (manaCostText != null)
            manaCostText.text = card.GetCardDetails().manaCost.ToString();
    }

    public void UpdateCardImages()
    {
        if (avatarImage != null && avatarBackgroundImage != null)
        {
            avatarImage.sprite = card.GetCardDetails().characterAvatarSprite;
            avatarBackgroundImage.sprite = card.GetCardDetails().avatarBackgroundSprite;
        }
    }

    public void HideCardUI()
    {
        avatarBackgroundImage.sprite = card.GetCardDetails().avatarBackgroundSprite;
        avatarImage.sprite = null;

        manaCostText.text = "";
        damageText.text = "";
        healthText.text = "";
        characterNameText.text = "";
        cardDescriptionText.text = "";
        cardTypeText.text = "";
    }

    public void ShowDivineShieldImage()
    {
        if (card.divineShield != null)
        {
            divineShieldImage.gameObject.SetActive(true);
        }
    }

    public void HideDivineShieldImage()
    {
        if(card.divineShield != null)
        {
            divineShieldImage.gameObject.SetActive(false);
        }
    }

    private void SetCardColorByTier()
    {
        switch (card.GetCardDetails().cardTier)
        {
            case CardTier.S:
                cardImage.color = Settings.cardSTierColor;
                break;

            case CardTier.A:
                cardImage.color = Settings.cardATierColor;
                break;

            case CardTier.B:
                cardImage.color = Settings.cardBTierColor;
                break;

            case CardTier.C:
                cardImage.color = Settings.cardCTierColor;
                break;

            case CardTier.D:
                cardImage.color = Settings.cardDTierColor;
                break;
        }
    }
}