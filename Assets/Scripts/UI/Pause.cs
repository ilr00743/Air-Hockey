using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
