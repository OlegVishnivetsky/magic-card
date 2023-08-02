using System.Collections;
using UnityEngine;

public class EnemyAttackAI : MonoBehaviour
{
    [SerializeField] private float attackDelay;

    public void Attack()
    {
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        if (GameFlowController.Instance.playerPlacedCards.Count == 0)
        {
            GameFlowController.Instance.ChangeTurn();
            yield break;
        }

        Card playerCardToAttack = GameFlowController.Instance.playerPlacedCards[0];

        if (IsAnyTauntPlaced() != null)
        {
            playerCardToAttack = IsAnyTauntPlaced();
        }

        for (int i = 0; i < GameFlowController.Instance.enemyPlacedCards.Count; i++)
        {
            if (playerCardToAttack == null)
            {
                if (GameFlowController.Instance.playerPlacedCards.Count > 0)
                {
                    playerCardToAttack = GameFlowController.Instance.playerPlacedCards[0];
                }
                else
                {
                    continue;
                }
            }

            if (GameFlowController.Instance.enemyPlacedCards[i] == null)
            {
                continue;
            }

            yield return new WaitForSeconds(attackDelay);

            GameFlowController.Instance.enemyPlacedCards[i]
                .cardAttack.Attack(playerCardToAttack);

            yield return null;
        }

        GameFlowController.Instance.ChangeTurn();
    }

    private Card IsAnyTauntPlaced()
    {
        foreach (Card tauntCard in GameFlowController.Instance.playerPlacedCards)
        {
            if (tauntCard.GetCardDetails().cardAbility == CardAbility.Taunt)
            {
                return tauntCard;
            }
        }

        return null;
    }
}