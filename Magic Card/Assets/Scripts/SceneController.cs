using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene(Settings.gameSceneSctring);
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(Settings.mainMenuSceneString);
    }

    public void LoadEditDeckScene()
    {
        SceneManager.LoadScene(Settings.editDeckScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
