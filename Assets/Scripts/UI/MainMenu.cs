using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Play()
    {
        SceneManager.LoadScene("Level");
    }
}
