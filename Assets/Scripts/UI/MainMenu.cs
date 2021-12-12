using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Settings()
    {
        throw new NotImplementedException();
    }

    public void Play()
    {
        SceneManager.LoadScene("Level");
    }
}
