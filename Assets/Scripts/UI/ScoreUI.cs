using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;


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
        scoreText.text = GameManager.Instance.GetCurrentScore().ToString();
    }



}
