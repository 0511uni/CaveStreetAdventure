using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Timeline.TimelinePlaybackControls;
/// <summary>
/// ゲーム全体を制御する
/// </summary>
public class GameManagement : MonoBehaviour
{
    #region//インスペクターで設定する
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject winText;

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

    #region//インスペクターで設定する ゲームオーバー
    [SerializeField]
    Text gameOverText; // ゲームオーバーUIText

    [SerializeField]
    GameObject[] enemys;

    [SerializeField]
    GameObject[] warps;

    [SerializeField]
    GameObject[] downLifts;

    [SerializeField]
    GameObject resultGameOverPanel;

    [SerializeField]
    GameObject resultGameOverIcon;

    [SerializeField]
    Text scoreTextGameOver;

    [SerializeField]
    Text highScoreTextGameOver;

    #endregion

    //　タイトルボタンを押したら実行する
    public void TitleBackBottan()
    {
        print("Title");
        SceneManager.LoadScene("TitleMenuScene");
    }

    public void GameOver()
    {
        Debug.Log("ゲームオーバーメソッド");

        gameOverText.enabled = true;

        resultRSButton.SetActive(true);

        resultGameOverPanel.SetActive(true);

        resultGameOverIcon.SetActive(true);

        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemys)
        {
            enemy.GetComponent<EnemyRoundTripAct>().enabled = false; // Enemyのコンポーネントを止める。
        }

        enemys = GameObject.FindGameObjectsWithTag("Enemy2");

        foreach (var enemy in enemys)
        {
            enemy.GetComponent<LoopMoveEnemy>().enabled = false; // Enemyのコンポーネントを止める。
        }

        warps = GameObject.FindGameObjectsWithTag("Warp");
        foreach (var warp in warps)
        {
            warp.SetActive(false); // Warpのコンポーネントを止める。
        }

        downLifts = GameObject.FindGameObjectsWithTag("Lift");

        foreach (var downLift in downLifts)
        {
            downLift.GetComponent<LiftDownMove>().enabled = false; // Liftのコンポーネントを止める。
            Destroy(downLift.GetComponent<Rigidbody2D>()); // Liftのコンポーネントを止める。
        }


        scoreUI.SetActive(false);
        //timer.GetComponent<TimerController>().enabled = false;

        buttonController.SetActive(false);

        player.GetComponent<PlayerLifeManagement>().SetCountText();

        scoreTextGameOver.enabled = true;

        highScoreTextGameOver.enabled = true;
    }

    public void GameClear()
    {
        gameClear = true;

        winText.SetActive(true);

        resultRSButton.SetActive(true);

        resultGameClearPanel.SetActive(true);

        buttonController.SetActive(false);

        scoreUI.SetActive(false);

        scoreTextWin.enabled = true;

        highScoreTextWin.enabled = true;

        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemys)
        {
            enemy.GetComponent<EnemyRoundTripAct>().enabled = false; // Enemyのコンポーネントを止める。
        }

        enemys = GameObject.FindGameObjectsWithTag("Enemy2");

        foreach (var enemy in enemys)
        {
            enemy.GetComponent<LoopMoveEnemy>().enabled = false; // Enemyのコンポーネントを止める。
        }

        warps = GameObject.FindGameObjectsWithTag("Warp");
        foreach (var warp in warps)
        {
            warp.SetActive(false); // Warpのコンポーネントを止める。
        }

        downLifts = GameObject.FindGameObjectsWithTag("Lift");

        foreach (var downLift in downLifts)
        {
            downLift.GetComponent<LiftDownMove>().enabled = false; // Liftのコンポーネントを止める。
            Destroy(downLift.GetComponent<Rigidbody2D>()); // Liftのコンポーネントを止める。
        }

        player.GetComponent<PlayerLifeManagement>().GameClearScore();

        player.GetComponent<PlayerLifeManagement>().enabled = false;

    }
}
