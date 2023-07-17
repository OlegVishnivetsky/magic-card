using UnityEngine;

[RequireComponent(typeof(CardSelector))]
[RequireComponent(typeof(CardController))]
public class Card : MonoBehaviour
{
    [SerializeField] private CardDetailsSO cardDetails;

    [HideInInspector] public bool isEnemy;

    [HideInInspector] public CardSelector cardSelector;
    [HideInInspector] public CardController cardController;

    public bool isCanAttack;

    private int health;

    private void Awake()
    {
        cardSelector = GetComponent<CardSelector>();
        cardController = GetComponent<CardController>();
    }

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
        health = cardDetails.health;

        if (cardDetails.cardType == CardType.Rush)
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
        isCanAttack = true;        
    }

    public CardDetailsSO GetCardDetails()
    {
        return cardDetails;
    }

    public void SetCardDetails(CardDetailsSO cardDetails)
    {
        this.cardDetails = cardDetails;
    }

    public void AttackCard(Card target)
    {
        if (!isCanAttack)
        {
            return;
        }

        health -= target.GetCardDetails().damage;
        target.DecreaseHealth(cardDetails.damage);

        GetComponent<CardUI>().UpdateCardText();
        target.GetComponent<CardUI>().UpdateCardText();

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