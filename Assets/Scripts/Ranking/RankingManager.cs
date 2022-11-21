//using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
//using UnityEngine.SocialPlatforms.Impl;
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
        gameStatus.rankings.Sort((a, b) => b.Score - a.Score);

        int counter = Mathf.Min(10, gameStatus.rankings.Count);
        for (int i = 0; i < counter; i++)
        {//gameStatus.rankings.Count

            Ranking ranking = gameStatus.rankings[i];
            //if (i + 1 == 10)
            //{
            //    displayField.text += $"　{i + 1}.\t\t　{ranking.Name}さん\n" +
            //    $"\t\t\tScore：{ranking.Score}\t{ranking.Timer}\n\n";
            //    return;
            //}
            displayField.text += $"{(i + 1),2}{ranking.Name,10}さん\n" +
                $"{"Score:", 20}{ranking.Score, 2}{ranking.Timer,15}\n\n";
            //displayField.text += $"　{i + 1}.\t\t\t　{ranking.Name}さん\n" +
            //    $"\t\t\tScore：{ranking.Score}\t{ranking.Timer}\n\n";
        }
    }

    public void RoadButton() => gameStatus.Load();

    public void SaveButton() => gameStatus.Save();

    public void ClearPanel() => gameStatus.rankings.Clear();

    public void TitleBackButton() => UnityEngine.SceneManagement.SceneManager.LoadScene("TitleMenuScene");
}
