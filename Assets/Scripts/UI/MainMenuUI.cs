using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private OptionsMenu optionsMenu;

    private void Awake()
    {
        Time.timeScale = 1.0f;

        startGameButton.onClick.AddListener(() =>
        {
            Load.LoadCallbackScene(Load.Scene.GameScene);
        });

        optionsButton.onClick.AddListener(() =>
        {
            optionsMenu.Show();
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    private void Start()
    {
        SelectFirstButton();
        optionsMenu.OnPanelHide += OptionsMenu_OnPanelHide;
    }

    private void OptionsMenu_OnPanelHide(object sender, System.EventArgs e)
    {
        SelectFirstButton();
    }

    private void SelectFirstButton()
    {
        startGameButton.Select();
    }

}
