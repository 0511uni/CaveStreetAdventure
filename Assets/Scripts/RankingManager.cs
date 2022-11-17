using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static GameStatus;
//using static System.Net.Mime.MediaTypeNames;

public class RankingManager : MonoBehaviour
{
    [SerializeField]
    Text displayField;

    [SerializeField]
    GameStatus gameStatus;

    void Start()
    {
        ShowRanking();
    }

    public void OnClickRankingPush()
    {
        ShowRanking();
    }

    private void ShowRanking()
    {
        displayField.text = "";

        gameStatus.rankings.Sort((a, b) => b.score - a.score);

        foreach (var ranking in gameStatus.rankings)
        {
            displayField.text += ranking.name + "さん\n" +
                "Score：" + ranking.score.ToString() + "\n\n";
        }
    }

    public void RoadButton()
    {
        gameStatus.Load();
    }

    public void SaveButton()
    {
        gameStatus.Save();
    }

    public void ClearPanel()
    {
        Debug.Log("クリア");
        gameStatus.rankings.Clear();
    }

    public void TitleBackButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleMenuScene");
    }
}
