using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timeText;

    private float time = 180f;

    private void Update()
    {
        time -= Time.deltaTime;
        UpdateVisual();
    }

    private void UpdateVisual()
    {

        float timeModified = Mathf.FloorToInt(time);

        timeModified = Mathf.Max(timeModified, 0);

        if (timeModified <= 0) GameManager.Instance.GameOver();

        timeText.text = timeModified.ToString();
    }





}
