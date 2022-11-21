﻿using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using static GameStatus;

public class TweetButton : MonoBehaviour
{
    //[SerializeField]
    //GameObject scoreObject = null; // Textオブジェクト
    [SerializeField]
    Text nameText;

    [SerializeField]
    Text scoreText;

    [SerializeField]
    Text highScoreText;

    [SerializeField]
    GameStatus datSave;

    [SerializeField]
    GameStatus gameStatus;


    //「つぶやく」ボタンを押したときの処理
    public void OnClickTweetButton()
    {
        
        scoreText.text = gameStatus.Score.ToString();

        Ranking rank = gameStatus.rankings[1];
        nameText.text = rank.Name;

        Ranking ranking = gameStatus.rankings[0];
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        highScoreText.text = ranking.Score.ToString();

        //scoreText.text = datSave.Score.ToString();
        //highscoreText.text = PlayerPrefs.GetInt(datSave.key).ToString();

        var text = $"{nameText.text}さんの今回の記録は『{scoreText.text}』点でした! \n" +
            $"High Scoreは、『{ highScoreText.text}』点でした! \n" +
            $"挑戦者求む!!\n"
        + "https://www.google.com/‎ \n";

        
        string[] hashtags = { "tag1", "tag2" };

        Application.OpenURL($"https://twitter.com/intent/tweet?text={UnityWebRequest.EscapeURL(text)}&hashtags={UnityWebRequest.EscapeURL(string.Join(",", hashtags))}");
    }
}

