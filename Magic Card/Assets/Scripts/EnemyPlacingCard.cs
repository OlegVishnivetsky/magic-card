using System.Collections;
using UnityEngine;

public class EnemyPlacingCard : MonoBehaviour
{
    [SerializeField] private Transform enemyPlacedZoneTransform;

    private void OnEnable()
    {
        StaticEventsHandler.OnTurnChanged += Instance_OnTurnChanged;
    }

    private void OnDisable()
    {
        StaticEventsHandler.OnTurnChanged -= Instance_OnTurnChanged;
    }

    private void Start()
    {
        if (GameFlowController.Instance.GetCurrentTurn() == Turn.EnemyTurn)
            StartCoroutine(PlaceCardRoutine());
    }

    private void Instance_OnTurnChanged(Turn turn)
    {
        if (turn == Turn.EnemyTurn)
        {
            
        }
    }

    private IEnumerator PlaceCardRoutine()
    {
        yield return null;
    }
}