using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        int roundScore = ScoreManager.Instance?.TotalScore ?? 0;
        PlayerPrefs.SetInt("RoundScore", roundScore);

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (roundScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", roundScore);
        }
        PlayerPrefs.Save();
        SceneManager.LoadScene("Endgame");
    }
}
