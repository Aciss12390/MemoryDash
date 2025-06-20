using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalSummary : MonoBehaviour
{
    public TextMeshProUGUI statsText;

    void Start()
    {
        statsText.text = GenerateFullStats();
    }

    string GenerateFullStats()
    {
        int totalSteps = 0;
        int totalFails = 0;
        string result = "Your Performance:\n\n";

        for (int i = 0; i < GameStats.Instance.stepsPerLevel.Count; i++)
        {
            int level = i + 1;
            int steps = GameStats.Instance.stepsPerLevel[i];
            int fails = GameStats.Instance.failsPerLevel[i];
            result += $"Level {level}: {steps} steps, {fails} fails\n";
            totalSteps += steps;
            totalFails += fails;
        }

        result += $"\nYou have completed all levels in {totalSteps} steps with {totalFails} fails.";

        return result;
    }

    public void PlayAgain()
    {
        GameStats.Instance?.ResetStats();
        SceneManager.LoadScene("Level1");
    }

    public void GoToMainMenu()
    {
        GameStats.Instance?.ResetStats();
        SceneManager.LoadScene("MainMenu");
    }
}
