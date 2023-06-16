using System;
using UnityEngine;


public class CardBattle : MonoBehaviour 
{
    public Card playerCard;
    public Card enemyCard;

    public static Action OnAttack;

    private void OnEnable()
    {
        GameController.OnPlayerChooseCardToAttack += PlayerAttack;
    }

    private void OnDisable()
    {
        GameController.OnPlayerChooseCardToAttack -= PlayerAttack;
    }

    private void PlayerAttack()
    {
        if (playerCard != null && enemyCard != null)
        {
            if (!playerCard.isCanAttack)
            {
                playerCard = null; 
                enemyCard = null;
                return;
            }

            playerCard.health -= enemyCard.GetCardDetails().damage;
            enemyCard.health -= playerCard.GetCardDetails().damage;

            OnAttack?.Invoke();

            if (playerCard.health <= 0 && playerCard != null)
            {
                Destroy(playerCard.gameObject);
                playerCard = null;
            }
            
            if (enemyCard.health <= 0)
            {
                Destroy(enemyCard.gameObject);
                enemyCard = null;
            }

            if (playerCard != null)
            {
                playerCard.GetComponent<CardUI>().UpdateCardUI();
            }

            if (enemyCard != null)
            {
                enemyCard.GetComponent<CardUI>().UpdateCardUI();
            }

            playerCard.isCanAttack = false;
            playerCard = null;
            enemyCard = null;
        }
    }
}