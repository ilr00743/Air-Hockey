using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsUI : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
