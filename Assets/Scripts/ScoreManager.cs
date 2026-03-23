using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        scoreText = GameObject.Find("ScoreText")?.GetComponent<TextMeshProUGUI>();
        totalScore = 0;
        if (scoreText != null)
        {
            scoreText.text = $"Score: {totalScore}";
        }
    }
}
