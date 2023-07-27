using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Card))]
public class CardUI : MonoBehaviour
{
    private Card card;

    [Header("TEXT COMPONENTS")]
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI cardTierText;
    [SerializeField] private TextMeshProUGUI manaCostText;
    [SerializeField] private TextMeshProUGUI characterNameText;
    [SerializeField] private TextMeshProUGUI cardTypeText;
    [SerializeField] private TextMeshProUGUI cardDescriptionText;

    [Header("IMAGE COMPONENTS")]
    [SerializeField] private Image cardImage;
    [SerializeField] private Image avatarImage;
    [SerializeField] private Image avatarBackgroundImage;

    private void Awake()
    {
        card = GetComponent<Card>();
    }

    private void Start()
    {
        UpdateCardUI();
    }

    public void UpdateCardUI()
    {
        UpdateCardText();
        UpdateCharacterName();
        UpdateCardImages();
        SetCardColorByTier();
    }

    public void UpdateCardText()
    {
        if (damageText != null)
            damageText.text = card.GetCardDetails().damage.ToString();
        if (healthText != null)
            healthText.text = card.GetCardHealth().ToString();
        if (manaCostText != null)
            manaCostText.text = card.GetCardDetails().manaCost.ToString();
        if (cardTypeText != null)
            cardTypeText.text = Enum.GetName(typeof(CardType), card.GetCardDetails().cardType);
        if (cardTierText != null)
            cardTierText.text = Enum.GetName(typeof(CardTier), card.GetCardDetails().cardTier);
        if (cardDescriptionText != null)
            cardDescriptionText.text = card.GetCardDetails().cardDescription;
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

    private void UpdateCharacterName()
    {
        if (characterNameText != null)
            characterNameText.text = card.GetCardDetails().characterName;
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