using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int pointsPerHit = 10;
    [SerializeField] private int totalScore;
    public int TotalScore => totalScore;
 
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        totalScore = 0;
        scoreText.text = $"Score: {totalScore}";
    }
 
    public void AddScore()
    {
        totalScore += pointsPerHit;
        scoreText.text = $"Score: {totalScore}";
    }
}
