using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ChangeSoundVolume()
    {
        throw new NotImplementedException();
    }
    
    public void ChangeMusicVolume()
    {
        throw new NotImplementedException();
    }
}
