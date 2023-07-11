using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private CardDetailsSO cardDetails;
    [HideInInspector] public bool isPlaced;
    [HideInInspector] public bool isEnemy;
    public bool isCanAttack;

    private int health;

    private void OnEnable()
    {
        GameFlowController.OnTurnChanged += GameController_OnTurnChanged;
    }

    private void OnDisable()
    {
        GameFlowController.OnTurnChanged -= GameController_OnTurnChanged;
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

    private void GameController_OnTurnChanged(Turn turn)
    {
        if (isPlaced)
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

    public void AttackCard(Card target)
    {
        if (isCanAttack)
        {
            health -= target.GetCardDetails().damage;
            target.health -= cardDetails.damage;
            isCanAttack = false;

            if (health <= 0)
            {
                Destroy(gameObject);
            }

            if (target.health <= 0)
            {
                Destroy(target.gameObject);
            }

            if (target != null)
            {
                if (this != null)
                {
                    GetComponent<CardUI>().UpdateCardUI();
                }

                if (target != null)
                {
                    target.GetComponent<CardUI>().UpdateCardUI();
                }
            }
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