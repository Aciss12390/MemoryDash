using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
