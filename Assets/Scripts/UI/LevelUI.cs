using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI levelText;


    private void Start()
    {
        UpdateVisual();
        GameManager.Instance.OnNewLevel += Instance_OnNewLevel;
    }

    private void Instance_OnNewLevel(object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        levelText.text = GameManager.Instance.GetCurrentLevel().ToString();
    }

}
