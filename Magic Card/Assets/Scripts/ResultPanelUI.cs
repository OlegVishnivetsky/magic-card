using DG.Tweening;
using TMPro;
using UnityEngine;

public class ResultPanelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winLoseText;

    private void OnEnable()
    {
        StaticEventsHandler.OnPlayerWon += ShowWinReslut;
        StaticEventsHandler.OnPlayerLose += ShowLoseReslut;
    }

    private void OnDisable()
    {
        StaticEventsHandler.OnPlayerWon -= ShowWinReslut;
        StaticEventsHandler.OnPlayerLose -= ShowLoseReslut;
    }

    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    private void ShowWinReslut()
    {
        winLoseText.text = "You Win!";
        transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.InCirc);
    }

    private void ShowLoseReslut()
    {
        winLoseText.text = "You Lose!";
        transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.InCirc);
    }
}