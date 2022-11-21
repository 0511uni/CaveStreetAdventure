//using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static GameStatus;
//using static System.Net.Mime.MediaTypeNames;

/// <summary>
/// Rankingを制御・表示する
/// </summary>
public class RankingManager : MonoBehaviour
{
    [SerializeField]
    Text displayField;

    [SerializeField]
    GameStatus gameStatus;

    [SerializeField]
    Text rankingNumber;

    void Start()
    {
        displayField.text = "";
        ShowRanking();
    }

    public void OnClickRankingPush() => ShowRanking();

    void ShowRanking()
    {
        gameStatus.rankings.Sort((a, b) => b.Score - a.Score);//ダミー用

        int counter = Mathf.Min(10, gameStatus.rankings.Count);
        for (int i = 0; i < counter; i++)
        {
            Ranking ranking = gameStatus.rankings[i];
            
            displayField.text += $"{(i + 1),3}{".",1}{ranking.Name,16}さん\n" +
                $"{"Score:", 23}{ranking.Score, 4}{ranking.Timer,12}\n\n";
        }
    }

    public void RoadButton() => gameStatus.Load();

    public void SaveButton() => gameStatus.Save();

    public void ClearPanel() => gameStatus.rankings.Clear();

    public void TitleBackButton() => UnityEngine.SceneManagement.SceneManager.LoadScene("TitleMenuScene");
}
