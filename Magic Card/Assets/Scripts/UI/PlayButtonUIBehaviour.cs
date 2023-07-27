using UnityEngine;
using UnityEngine.UI;

public class PlayButtonUIBehaviour : MonoBehaviour
{
    [Header("BUTTON COMPONENT")]
    [SerializeField] private Button playButton;

    [Header("RIVALS DECKS")]
    [SerializeField] private CardDeckSO playerDeck;
    [SerializeField] private CardDeckSO enemyDeck;

    [Header("SCENE CONTROLLER")]
    [SerializeField] private SceneController sceneController;

    private void Start()
    {
        playButton.onClick.AddListener(PlayButton_OnClick);
    }

    private void PlayButton_OnClick()
    {
        if (playerDeck.cards.Count == 0 || enemyDeck.cards.Count == 0)
        {
            return;
        }

        sceneController.LoadGameScene();
    }
}