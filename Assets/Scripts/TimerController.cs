using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    //[SerializeField]
    //GameObject timer;

    [SerializeField]
    int minute;

    [SerializeField]
    float seconds;

    //　前のUpdateの時の秒数
    float oldSeconds;

    [SerializeField]
    GameObject enemy;

    [SerializeField]
    Text highScoreTimerText; //ハイスコアタイムを表示するText

    [SerializeField]
    Text gameOverText; // ゲームオーバーUI

    [SerializeField]
    GameObject resultRSButton;

    [SerializeField]
    GameObject resultGameOverPanel;

    [SerializeField]
    GameObject resultGameOverIcon;

    bool gameOver;

    //　タイマー表示用テキスト
    Text timerText;

    float highScoreTimer; //ハイスコアタイム用変数

    string Timekey = "BEST TIMER"; //ハイスコアタイムの保存先キー

    void Start()
    {
        minute = 00;
        seconds = 60f;
        oldSeconds = 0f;
        timerText = GetComponentInChildren<Text>();

        highScoreTimer = PlayerPrefs.GetFloat(Timekey, highScoreTimer);
        
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        highScoreTimerText.text = "Timer: 00:00" + minute.ToString("00") + ":" + ((int)seconds).ToString("00").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        seconds -= Time.deltaTime;
        if (seconds >= 60f)
        {
            minute++;
            seconds -= 60;
        }
        //　値が変わった時だけテキストUIを更新
        if (seconds != oldSeconds)
        {
            timerText.text = minute.ToString("00") + ":" + seconds.ToString("00");
        }
        oldSeconds = seconds;

        if (seconds <= 0f)
        {
            //  リザルドの表示を最新
            gameOver = true;
            print("gameovr");

            GetComponent<TimerController>().enabled = false;

            enemy.GetComponent<EnemyRoundTripAct>().enabled = false; // 敵を止める

            GetComponent<TimerController>().enabled = false; // 自分のとこのコンポーネントを止める

            gameOverText.enabled = true;

            resultRSButton.SetActive(true);

            resultGameOverPanel.SetActive(true);

            resultGameOverIcon.SetActive(true);
        }

        // ハイスコアタイムより現在スコアタイムが高い時
        if (highScoreTimer < seconds || seconds <= 50f)
        {

            // highScoreTimer = minute;
            highScoreTimer = seconds;
            //ハイスコア更新

            PlayerPrefs.SetFloat(Timekey, highScoreTimer);
            //ハイスコアを保存

            highScoreTimerText.text = "Timer: " + minute.ToString("00") + ":" + seconds.ToString("00").ToString();
            //ハイスコアを表示
        }
        else
        {
            highScoreTimerText.text = "Timer: " + minute.ToString("00") + ":" + seconds.ToString("00").ToString();
            //ハイスコアを表示
        }
    }
}
