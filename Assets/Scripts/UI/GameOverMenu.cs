using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(() =>
        {
            Load.LoadCallbackScene(Load.Scene.GameScene);
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            Load.LoadCallbackScene(Load.Scene.MainMenuScene);

        });
    }


    private void Start()
    {
        GameManager.Instance.OnGameOver += GameManager_OnGameOver;
        Hide();
    }

    private void GameManager_OnGameOver(object sender, System.EventArgs e)
    {
        CheckBestScore();
        Show();
        transform.SetAsLastSibling();

    }

    private void CheckBestScore()
    {
        int currentScore = GameManager.Instance.GetCurrentScore();
        int bestScore = PlayerPrefs.GetInt(Dictionary.BEST_SCORE, 0);

        if(currentScore > bestScore) PlayerPrefs.SetInt(Dictionary.BEST_SCORE, currentScore);
    }

    private void Show()
    {
        gameObject.SetActive(true);
        UpdateVisual();
        restartButton.Select();
    }

    private void Hide()
    {
        gameObject.SetActive(false);

    }

    private void UpdateVisual()
    {
        levelText.text = "Your Level: " + GameManager.Instance.GetCurrentLevel();
        scoreText.text = "Your Score: " + GameManager.Instance.GetCurrentScore();
        bestScoreText.text = "Best Score: " + PlayerPrefs.GetInt(Dictionary.BEST_SCORE, 0);
    }
}
