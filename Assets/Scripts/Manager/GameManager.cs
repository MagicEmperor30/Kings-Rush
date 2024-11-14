using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private float startTime = 5f;

    private bool gameOver = false;
    private float timeLeft;

    public bool GameOver => gameOver; // Read-only property

    private void Start()
    {
        timeLeft = startTime;
    }

    private void Update()
    {
        if (gameOver) return;

        DecreaseTime();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            scoreManager.SaveScore();
            SceneManager.LoadScene(0);
        }
    }

    public void IncreaseTime(float increaseTimeAmount)
    {
        timeLeft += increaseTimeAmount;
    }

    private void DecreaseTime()
    {
        timeLeft -= Time.deltaTime;
        timeText.text = timeLeft.ToString("F1");

        if (timeLeft <= 0)
        {
            HandleGameOver();
        }
    }

    private void HandleGameOver()
    {
        gameOver = true;
        playerController.enabled = false;
        gameOverText.SetActive(true);
        Time.timeScale = 0.1f;
        scoreManager.SaveScore();
    }
}
