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
    GameObject winText;

    [SerializeField]
    GameObject enemy;

    [SerializeField]
    GameObject resultRSButton;

    [SerializeField]
    GameObject resultGameClearPanel;

    [SerializeField]
    Text scoreTextWin;  //  スコアのUI

    [SerializeField]
    Text highScoreTextWin;  //  スコアのUI

    [SerializeField]
    GameObject scoreUI;

    [SerializeField]
    GameObject buttonController;

    #endregion

    #region//プライベート変数  bool

    bool gameClear = false; //ゲームクリアーしたら操作を無効にする

    #endregion


    void Start()
    {
        winText.SetActive(false);
        resultRSButton.SetActive(false);
        resultGameClearPanel.SetActive(false);
        scoreTextWin.enabled = false;
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

        winText.SetActive(true);

        resultRSButton.SetActive(true);

        resultGameClearPanel.SetActive(true);

        buttonController.SetActive(false);

        scoreUI.SetActive(false);

        scoreTextWin.enabled = true;

        highScoreTextWin.enabled = true;

        enemy.GetComponent<EnemyRoundTripAct>().enabled = false;

        player.GetComponent<PlayerLifeManagement>().GameClearScore();

        player.GetComponent<PlayerLifeManagement>().enabled = false;

    }
}
