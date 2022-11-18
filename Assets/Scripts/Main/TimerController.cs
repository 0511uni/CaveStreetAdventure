using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// タイマーコントローラー
/// </summary>
public class TimerController : MonoBehaviour
{
    [SerializeField]
    GameManagement gameManagement;

    [SerializeField]
    int countdownMinutes = 3;

    float countdownSeconds;

    Text timeText;

    void Start()
    {
        timeText = GetComponent<Text>();
        countdownSeconds = countdownMinutes * 60;
    }

    void Update()
    {
        countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, (int)countdownSeconds);
        timeText.text = span.ToString(@"mm\:ss");

        // 0秒になったときの処理 Debug.Log("タイムアウト");
        if (countdownSeconds <= 0)
        {   
            gameManagement.GameOver();
        }
    }
}

