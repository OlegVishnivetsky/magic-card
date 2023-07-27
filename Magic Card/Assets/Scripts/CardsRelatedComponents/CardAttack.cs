using UnityEngine;

[RequireComponent(typeof(Card))]
public class CardAttack : MonoBehaviour
{
    private Card card;

    private int damage;

    public bool IsCanAttack { get; set; }

    private void Awake()
    {
        card = GetComponent<Card>();
    }

    private void OnEnable()
    {
        StaticEventsHandler.OnTurnChanged += StaticEventsHandler_OnTurnChanged;
    }

    private void OnDisable()
    {
        StaticEventsHandler.OnTurnChanged -= StaticEventsHandler_OnTurnChanged;
    }

    private void Start()
    {
        damage = card.GetCardDetails().damage;
    }

    public int GetCardDamage()
    {
        return damage;
    }

    public void Attack(Card target)
    {
        if (!IsCanAttack)
        {
            return;
        }

        IsCanAttack = false;

        card.cardHealth.TakeDamage(target.cardAttack.GetCardDamage());
        target.cardHealth.TakeDamage(damage);

        if (target.cardHealth.GetCurrentHealth() <= 0)
        {
            target.cardHealth.DestroyCard();
        }

        if (card.cardHealth.GetCurrentHealth() <= 0)
        {
            card.cardHealth.DestroyCard();
        }
    }

    private void StaticEventsHandler_OnTurnChanged(Turn turn)
    {
        if (gameObject.GetComponent<PlacedCard>() != null)
        {
            IsCanAttack = true;
        }
    }
}