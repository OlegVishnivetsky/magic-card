using UnityEngine;

[System.Serializable]
public class Card : MonoBehaviour
{
    [SerializeField] private CardDetailsSO cardDetails;

    public CardSelector cardSelector;
    public CardController cardController;

    [HideInInspector] public bool isEnemy;
    [HideInInspector] public bool isCanAttack;

    private int health;

    private void OnEnable()
    {
        StaticEventsHandler.OnTurnChanged += GameController_OnTurnChanged;
    }

    private void OnDisable()
    {
        StaticEventsHandler.OnTurnChanged -= GameController_OnTurnChanged;
    }

    private void Start()
    {
        health = cardDetails.cardData.health;

        if (cardDetails.cardData.cardType == CardType.Rush)
        {
            isCanAttack = true;
        }
        else
        {
            isCanAttack = false;
        }
    }

    public int GetCardHealth()
    {
        return health;
    }

    public void DecreaseHealth(int damage)
    {
        health -= damage;
    }

    private void GameController_OnTurnChanged(Turn turn)
    {
        if (gameObject.GetComponent<PlacedCard>() != null)
        {
            isCanAttack = true;
        }
    }

    public CardDetailsSO GetCardDetails()
    {
        return cardDetails;
    }

    public void SetCardDetails(CardDetailsSO cardDetails)
    {
        this.cardDetails = cardDetails;
    }

    public void SetCardDetailsData(CardDetailsData cardDetailsData)
    {
        this.cardDetails.cardData = cardDetailsData;
    }

    public void AttackCard(Card target)
    {
        if (!isCanAttack)
        {
            return;
        }

        health -= target.GetCardDetails().cardData.damage;
        target.DecreaseHealth(cardDetails.cardData.damage);

        GetComponent<CardUI>().UpdateCardText();
        target.GetComponent<CardUI>().UpdateCardText();

        isCanAttack = false;

        if (target.GetCardHealth() <= 0)
        {
            Destroy(target.gameObject);
        }

        if (health <= 0)
        {
            Destroy(gameObject);
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