using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private CardDetailsSO cardDetails;
    public int health;
    public bool isEnemy;
    public bool isCanAttack;

    private void Awake()
    {
        health = cardDetails.health;
    }

    private void OnEnable()
    {
        GameController.OnTurnChanged += GameController_OnTurnChanged;
    }

    private void OnDisable()
    {
        GameController.OnTurnChanged -= GameController_OnTurnChanged;
    }

    private void GameController_OnTurnChanged(int obj)
    {
        if (GetComponent<CardController>() != null) 
        {
            if (GetComponent<CardController>().isPlaced)
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