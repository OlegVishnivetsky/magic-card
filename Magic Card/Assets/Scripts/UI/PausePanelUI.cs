using DG.Tweening;
using UnityEngine;

public class PausePanelUI : MonoBehaviour
{
    [SerializeField] private Ease ease;

    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    public void ShowPausePanel()
    {
        transform.DOScale(Vector3.one, 0.2f).SetEase(ease);
    }

    public void HidePausePanel()
    {
        transform.DOScale(Vector3.zero, 0.2f).SetEase(ease);
    }
}