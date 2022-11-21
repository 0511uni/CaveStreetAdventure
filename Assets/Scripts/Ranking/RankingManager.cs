//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        for (int i = 0; i < 10; i++)
        {//gameStatus.rankings.Count
            int num = i + 1;
            Ranking ranking = gameStatus.rankings[i];
            if (num == 10)
            {
                displayField.text += $"　{num}.\t\t　{ranking.Name}さん\n" +
                $"\t\t\tScore：{ranking.Score}\t{ranking.Timer}\n\n";
                return;
            }
            displayField.text += $"　{num}.\t\t\t　{ranking.Name}さん\n" +
                $"\t\t\tScore：{ranking.Score}\t{ranking.Timer}\n\n";
        }
    }

    public void RoadButton() => gameStatus.Load();

    public void SaveButton() => gameStatus.Save();

    public void ClearPanel() => gameStatus.rankings.Clear();

    public void TitleBackButton() => UnityEngine.SceneManagement.SceneManager.LoadScene("TitleMenuScene");
}
