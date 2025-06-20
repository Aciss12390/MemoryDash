using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject winCanvas;

    void Start()
    {
        gameOverCanvas.SetActive(false);
        winCanvas.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 1f;
        gameOverCanvas.SetActive(true);
        FindFirstObjectByType<PlayerController>().LockMovement();
        GameStats.Instance?.RecordFail();
    }

    public void Win()
    {
        Time.timeScale = 1f;
        winCanvas.SetActive(true);
        FindFirstObjectByType<PlayerController>().LockMovement();
        GameStats.Instance?.LevelCompleted();
        Invoke("ShowLevelStats", 2f);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UnlockPlayerMovement()
    {
        PlayerController player = FindFirstObjectByType<PlayerController>();
        if (player != null)
        {
            player.UnlockMovement();
        }
    }

    public void LoadStatsScreen()
    {
        SceneManager.LoadScene("LevelSummary");
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        if (currentSceneIndex + 1 < totalScenes)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}