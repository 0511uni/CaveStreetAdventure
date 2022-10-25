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
    int minute;

    public float seconds;

    //　前のUpdateの時の秒数
    float oldSeconds;

    float timeOut;

    [SerializeField]
    Text highScoreTimerText; //ハイスコアタイムを表示するText

    [SerializeField]
    Text resultTimer;

    [SerializeField]
    GameObject scoreUI;

    [SerializeField]
    GameManagement gameManagement;

    //　タイマー表示用テキスト
    Text timerText;

    float highScoreTimer; //ハイスコアタイム用変数

    string Timekey = "BEST TIMER"; //ハイスコアタイムの保存先キー

    void Start()
    {
        minute = 00;
        seconds = 60f;
        oldSeconds = 0f;
        timeOut = 0f;
        timerText = GetComponentInChildren<Text>();

        highScoreTimer = PlayerPrefs.GetInt(Timekey, (int)highScoreTimer);
        
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        highScoreTimerText.text = "Timer:" + minute.ToString("00") + "00:00" + ((int)seconds).ToString("60").ToString();

        scoreUI.SetActive(true);
    }

    void Update()
    {
        seconds -= Time.deltaTime;
        if (seconds >= 60f)
        {
            minute++;
            seconds -= 60f;
        }
        //　値が変わった時だけテキストUIを更新
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = minute.ToString("00") + ":" + seconds.ToString("00");
        }
        oldSeconds = seconds;

        if (seconds <= timeOut)
        {
            Debug.Log("timeOut");
            resultTimer.text = minute.ToString("00") + ":" + seconds.ToString("00");
            gameManagement.GameOver();
        }

        //// ハイスコアタイムより現在スコアタイムが高い時
        //if (highScoreTimer < seconds || seconds <= 50f)
        //{

        //    // highScoreTimer = minute;
        //    highScoreTimer = seconds;
        //    //ハイスコア更新

        //    PlayerPrefs.SetInt(Timekey, (int)highScoreTimer);
        //    //ハイスコアを保存

        //    highScoreTimerText.text = "Timer: " + minute.ToString("00") + ":" + ((int)seconds).ToString("00").ToString();
        //    //ハイスコアを表示
        //}
        //else
        //{
        //    highScoreTimerText.text = "Timer: " + minute.ToString("00") + ":" + ((int)seconds).ToString("00").ToString();
        //    //ハイスコアを表示
        //}
    }
}
