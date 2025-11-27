using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int hearts = 3;
    public int score = 0;
    public float timeRemaining = 60f;
    public bool isGameOver = false;

    public Transform respawnPoint;
    private GameObject player;

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
    }

    void Update()
    {
        if (!isGameOver)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                isGameOver = true;
                Debug.Log("Time's up! Player loses.");
                SceneManager.LoadScene("GameEnd");
            }
        }
    }

    public void RegisterPlayer(GameObject playerObj)
    {
        player = playerObj;
    }

    public void RespawnPlayer()
    {
        hearts--;
        Debug.Log("Heart lost! Hearts left: " + hearts);

        if (hearts <= 0)
        {
            isGameOver = true;
            Debug.Log("Game Over! Loading Restart scene...");
            SceneManager.LoadScene("GameEnd");
            // Game over logic
        }
        else if (player != null && respawnPoint != null)
        {
            player.transform.position = respawnPoint.position;
        }
    }

    // private void TriggerGameOver()
    // {
    //     isGameOver = true;
    //     Debug.Log("Game Over! Loading Restart scene...");
    //     SceneManager.LoadScene("Restart");
    // }

    public void AddFruitScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }

    public void FinishLevel()
    {
        Debug.Log("Level Complete!");
        SceneManager.LoadScene("Victory");
    }
}
