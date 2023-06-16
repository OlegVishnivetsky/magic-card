using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Card))]
public class CardUI : MonoBehaviour
{
    private Card card;

    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI manaCostText;
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
    }

    public void UpdateCardText()
    {
        if (damageText != null)
            damageText.text = card.GetCardDetails().damage.ToString();
        if (healthText != null)
            healthText.text = card.health.ToString();
        if (manaCostText != null)
            manaCostText.text = card.GetCardDetails().cost.ToString();
    }

    public void UpdateCardImages()
    {
        if (avatarImage != null && avatarBackgroundImage != null)
        {
            avatarImage.sprite = card.GetCardDetails().characterAvatarSprite;
            avatarBackgroundImage.sprite = card.GetCardDetails().avatarBackgroundSprite;
        }
    }

    private void UpdateCharacterName()
    {
        if (characterName != null)
            characterName.text = card.GetCardDetails().characterName;
    }

    public void HideCardUI()
    {
        avatarBackgroundImage.sprite = card.GetCardDetails().avatarBackgroundSprite;
        avatarImage.sprite = null;
        manaCostText.text = "";
        damageText.text = "";
        healthText.text = "";
        characterName.text = "";
    }
}