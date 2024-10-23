using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private Button resumeGameButton;
    [SerializeField] private Button restartGameButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button mainMenuButton;

    [SerializeField] private OptionsMenu optionsMenu;



    private void Awake()
    {
        resumeGameButton.onClick.AddListener(() =>
        {
            Hide();
            GameManager.Instance.TogglePauseGame();
        });

        restartGameButton.onClick.AddListener(() =>
        {
            Load.LoadCallbackScene(Load.Scene.GameScene);
        });

        optionsButton.onClick.AddListener(() =>
        {
            optionsMenu.Show();
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            Load.LoadCallbackScene(Load.Scene.MainMenuScene);
        });
    }

    private void Start()
    {
        GameManager.Instance.OnGamePaused += GameManager_OnGamePaused;
        optionsMenu.OnPanelHide += OptionsMenu_OnPanelHide;
        Hide();
    }

    private void OptionsMenu_OnPanelHide(object sender, System.EventArgs e)
    {
        SelectFirstButton();
    }

    private void GameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        Show();
        transform.SetAsLastSibling();
    }

    private void Show()
    {
        gameObject.SetActive(true);
        SelectFirstButton();
    }
    private void Hide()
    {
        gameObject.SetActive(false);

    }

    private void SelectFirstButton()
    {
        resumeGameButton.Select();
    }

}
