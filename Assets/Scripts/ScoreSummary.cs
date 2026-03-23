
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSummary : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI roundScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private Button creditButton;
    void Start()
    {
        roundScoreText.text = $"Round Score: {PlayerPrefs.GetInt("RoundScore", 0)}";
        highScoreText.text = $"High Score: {PlayerPrefs.GetInt("HighScore", 0)}";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Operator");
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene("Credits");
    }

}
