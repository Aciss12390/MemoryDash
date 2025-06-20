using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSummary : MonoBehaviour
{
    public TextMeshProUGUI stepsText;
    public TextMeshProUGUI failsText;

    void Start()
    {
        int lastIndex = GameStats.Instance.stepsPerLevel.Count - 1;
        stepsText.text = "Steps Taken: " + GameStats.Instance.stepsPerLevel[lastIndex];
        failsText.text = "Fails Before Win: " + GameStats.Instance.failsPerLevel[lastIndex];
    }

    public void LoadNext()
    {
        int levelsCompleted = GameStats.Instance.stepsPerLevel.Count;

        if (levelsCompleted < 5)
        {
            string nextLevelName = "Level" + (levelsCompleted + 1);
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            SceneManager.LoadScene("FinalSummary");
        }
    }
}