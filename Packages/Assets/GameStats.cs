using UnityEngine;
using System.Collections.Generic;

public class GameStats : MonoBehaviour
{
    public static GameStats Instance;

    public List<int> stepsPerLevel = new List<int>();
    public List<int> failsPerLevel = new List<int>();

    private int currentSteps = 0;
    private int currentFails = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddStep()
    {
        currentSteps++;
    }

    public void RecordFail()
    {
        currentFails++;
    }

    public void LevelCompleted()
    {
        stepsPerLevel.Add(currentSteps);
        failsPerLevel.Add(currentFails);
        currentSteps = 0;
        currentFails = 0;
    }

    public void ResetStats()
    {
        stepsPerLevel.Clear();
        failsPerLevel.Clear();
        currentSteps = 0;
        currentFails = 0;
    }
}
