using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Scoring")]
    [SerializeField] private int fruitScore = 0;
    [SerializeField] private int timeBonus = 0;

    [Header("Timer")]
    [SerializeField] private float levelTime = 0f;
    [SerializeField] private bool timerRunning = false;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private GameObject resultsPanel;

    [Header("Respawn")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform playerTransform;

    private Vector3 initialSpawnPosition;
    private int finalScore = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        if (spawnPoint != null)
        {
            initialSpawnPosition = spawnPoint.position;
        }

        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
        }

        fruitScore = 0;
        levelTime = 0f;
        UpdateUI();
    }

    private void Update()
    {
        if (timerRunning)
        {
            levelTime += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    public void StartTimer()
    {
        timerRunning = true;
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public void AddFruitScore(int amount)
    {
        fruitScore += amount;
        UpdateUI();
    }

    public void CalculateFinalScore()
    {
        int timeBonusAmount = Mathf.Max(0, 1000 - Mathf.RoundToInt(levelTime * 10));
        finalScore = fruitScore + timeBonusAmount;
    }

    public void FinishLevel()
    {
        StopTimer();
        CalculateFinalScore();

        if (finalScoreText != null)
        {
            finalScoreText.text = $"Final Score: {finalScore}";
        }
    }

    public void RespawnPlayer()
    {
        if (playerTransform != null && spawnPoint != null)
        {
            playerTransform.position = initialSpawnPosition;
        }
    }

    public void RestartLevel()
    {
        fruitScore = 0;
        levelTime = 0f;
        timerRunning = false;
        Time.timeScale = 1f;

        if (resultsPanel != null)
        {
            resultsPanel.SetActive(false);
        }

        RespawnPlayer();
        UpdateUI();
    }

    public void GoToNextLevel(string levelName)
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {fruitScore}";
        }
        UpdateTimerUI();
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(levelTime / 60f);
            int seconds = Mathf.FloorToInt(levelTime % 60f);
            timerText.text = $"Time: {minutes:00}:{seconds:00}";
        }
    }

    public int GetFinalScore()
    {
        return finalScore;
    }

    public float GetLevelTime()
    {
        return levelTime;
    }
}