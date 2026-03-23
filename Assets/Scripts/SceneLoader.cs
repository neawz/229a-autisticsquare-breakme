using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Play()
    {
        Time.timeScale = 1f;
        PausedMenu.GameIsPaused = false;
        SceneManager.LoadScene("Operator");
    }
}
