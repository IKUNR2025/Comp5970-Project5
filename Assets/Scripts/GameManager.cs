using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameStarted = false;
    public bool isGameOver = false;
    public Transform player;

    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text finalScoreText;
    public GameObject gameOverPanel;
    public GameObject startMenuPanel;

    [Header("Score")]
    public float scoreMultiplier = 1f;

    private PlayerController playerController;
    private float startZ;
    private int score;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
            startZ = player.position.z;
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        if (startMenuPanel != null)
        {
            startMenuPanel.SetActive(true);
        }

        score = 0;
        UpdateScoreText();
    }

    void Update()
    {
        if (!isGameStarted || isGameOver)
        {
            return;
        }

        if (player != null)
        {
            float distance = player.position.z - startZ;
            score = Mathf.Max(0, Mathf.FloorToInt(distance * scoreMultiplier));
            UpdateScoreText();

            if (player.position.y < -5f)
            {
                GameOver();
            }
        }
    }

    public void StartGame()
    {
        isGameStarted = true;

        if (startMenuPanel != null)
        {
            startMenuPanel.SetActive(false);
        }

        if (playerController != null)
        {
            playerController.StartMoving();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void GameOver()
    {
        if (isGameOver)
        {
            return;
        }

        isGameOver = true;

        if (playerController != null)
        {
            playerController.StopPlayer();
        }

        if (finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + score;
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Debug.Log("Game Over");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}