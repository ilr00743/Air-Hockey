using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LevelUI : MonoBehaviour
    {
        public void ReturnToMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
