using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SettingsUI : MonoBehaviour
    {
        public void ReturnToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
