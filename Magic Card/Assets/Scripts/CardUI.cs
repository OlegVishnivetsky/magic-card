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
            damageText.text = card.GetCardDetails().cardData.damage.ToString();
        if (healthText != null)
            healthText.text = card.GetCardHealth().ToString();
        if (manaCostText != null)
            manaCostText.text = card.GetCardDetails().cardData.manaCost.ToString();
        if (cardTypeText != null)
            cardTypeText.text = Enum.GetName(typeof(CardType), card.GetCardDetails().cardData.cardType);
        if (cardTierText != null)
            cardTierText.text = Enum.GetName(typeof(CardTier), card.GetCardDetails().cardData.cardTier);
        if (cardDescriptionText != null)
            cardDescriptionText.text = card.GetCardDetails().cardData.cardDescription;
    }

    public void UpdateCardImages()
    {
        if (avatarImage != null && avatarBackgroundImage != null)
        {
            avatarImage.sprite = Resources.Load<Sprite>(card.GetCardDetails().cardData.characterAvatarSpritePath);
            avatarBackgroundImage.sprite = Resources.Load<Sprite>(card.GetCardDetails().cardData.avatarBackgroundSpritePath);
        }
    }

    public void HideCardUI()
    {
        avatarBackgroundImage.sprite = Resources.Load<Sprite>(card.GetCardDetails().cardData.avatarBackgroundSpritePath);
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
            characterNameText.text = card.GetCardDetails().cardData.characterName;
    }

    private void SetCardColorByTier()
    {
        switch (card.GetCardDetails().cardData.cardTier)
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