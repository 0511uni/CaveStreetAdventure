using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
public class TimerScript : MonoBehaviour {

    [SerializeField]
    private int minute;
    [SerializeField]
    private float seconds;
    //　前のUpdateの時の秒数
    private float oldSeconds;
    //　タイマー表示用テキスト
    private Text timerText;
    public Text highScoreTimerText; //ハイスコアタイムを表示するText
    private float highScoreTimer; //ハイスコアタイム用変数
    private string key = "BEST TIMER"; //ハイスコアタイムの保存先キー



    void Start()
    {

        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;
        timerText = GetComponentInChildren<Text>();

        highScoreTimer = PlayerPrefs.GetFloat(key, highScoreTimer);
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        highScoreTimerText.text = "Timer: " + minute.ToString("00") + ":" + ((int)seconds).ToString("00").ToString();
    }

    void Update()
    {
        

            seconds += Time.deltaTime;
        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }
        //　値が変わった時だけテキストUIを更新
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;

        // ハイスコアタイムより現在スコアタイムが高い時
        if(seconds > highScoreTimer) {

            // highScoreTimer = minute;
            highScoreTimer = seconds;
            //ハイスコア更新

            PlayerPrefs.SetFloat(key, highScoreTimer);
            //ハイスコアを保存

            highScoreTimerText.text = "Timer: " + minute.ToString("00") + ":" + ((int)seconds).ToString("00").ToString();
            //ハイスコアを表示
        }
        else
        {
            highScoreTimerText.text = "Timer: " + minute.ToString("00") + ":" + ((int)seconds).ToString("00").ToString();
            //ハイスコアを表示
        }
    }
}

