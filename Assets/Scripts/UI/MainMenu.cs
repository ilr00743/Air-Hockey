using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }
}
