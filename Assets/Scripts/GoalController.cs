using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GoalController : MonoBehaviour
{
    #region//インスペクターで設定する
    [SerializeField]
    GameObject player;

    [SerializeField]
    Text winText;  //  リザルトのUI

    [SerializeField]
    GameObject enemy;

    [SerializeField]
    GameObject resultRSButton;

    [SerializeField]
    GameObject resultGameClearPanel;

    [SerializeField]
    Text scoreText2;  //  スコアのUI

    [SerializeField]
    Text highScoreText2; //ハイスコアを表示するText

    [SerializeField]
    GameObject timer;

    #endregion

    #region//プライベート変数  bool

    bool gameClear = false; //ゲームクリアーしたら操作を無効にする

    #endregion


    void Start()
    {
        winText.enabled = false;
        enemy.GetComponent<EnemyRoundTripAct>().enabled = true;
        resultRSButton.SetActive(false);
        resultGameClearPanel.SetActive(false);
        timer.GetComponent<TimerController>().enabled = true;
        scoreText2.enabled = false;
        highScoreText2.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            {
                GameClear();
            }
        }
    }

    void GameClear()
    {
        gameClear = true;

        winText.enabled = true;

        resultRSButton.SetActive(true);

        resultGameClearPanel.SetActive(true);

        enemy.GetComponent<EnemyRoundTripAct>().enabled = false;

        timer.GetComponent<TimerController>().enabled = false;

        player.GetComponent<PlayerLifeManagement>().GameClearScore();

        scoreText2.enabled = true;

        highScoreText2.enabled = true;
    }
}
