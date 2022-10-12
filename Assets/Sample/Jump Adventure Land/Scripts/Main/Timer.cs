using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    // 2.時間経過を示す「time」変数
    public static float time;

	public Text highScoreTimerText; //BestTimeを表示するText
	private float highScoreTimer; //BestTime用変数
	private string key = "HIGH SCORE TIMER"; //BestTimeの保存先キー

    // Use this for initialization
    void Start()
    {
        // 3.ゲーム開始時は「time」は「0」
        time = 0;

		highScoreTimer = PlayerPrefs.GetFloat(key, 0);
		//保存しておいたBestTimeをキーで呼び出し取得し保存されていなければ0になる
        highScoreTimerText.text = "Best Time : " + highScoreTimer.ToString();
		// //BestTimeを表示
        // PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {    
        // 5.経過時間を追加
        time = time + Time.deltaTime;

        // 6.小数点以下を切り捨てる
        int t = Mathf.FloorToInt(time);

        // 7.「Text」Componentを取得して、「uiText」に格納
        Text uiText = GetComponent<Text>();

        // 8.テキストを編集
        uiText.text = "Time : " + t;

		// if (GetComponent<Timer>().enabled) {
		// BestTimeより現在スコアタイムが高い時
		//if (t >= 0 && t >= highScoreTimer) {

  //          highScoreTimer = t;
  //          //BestTime更新

  //          //PlayerPrefs.SetFloat(key, highScoreTimer);
  //          ////BestTimeを保存

  //          highScoreTimerText.text = "Best Time : " + highScoreTimer.ToString();
  //          //BestTimeを表示
  //      }
  //      else if(t <= highScoreTimer){
            
		//	highScoreTimer = t;
		//	//BestTime更新

  //          PlayerPrefs.SetFloat(key, highScoreTimer);
		//	//BestTimeを保存

  //          highScoreTimerText.text = "Best Time : " + highScoreTimer.ToString();
		//	//BestTimeを表示
  //      }else{
  //        return;  
  //      }
		
		// }
    }
}