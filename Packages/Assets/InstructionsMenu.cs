using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsMenu : MonoBehaviour
{
    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}