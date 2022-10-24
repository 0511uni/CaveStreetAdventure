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
    GameObject winText;

    [SerializeField]
    GameObject resultRSButton;

    [SerializeField]
    GameObject resultGameClearPanel;

    [SerializeField]
    Text scoreTextWin;  //  スコアのUI

    [SerializeField]
    GameObject scoreUI;

    [SerializeField]
    GameObject buttonController;

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
    GameObject resultWinIcon;

    [SerializeField]
    GameObject winUI;

    [SerializeField]
    GameObject gameOverUI;

    [SerializeField]
    Text resultGameScoreText;

    [SerializeField]
    Text resultGamehighScoreText;

    [SerializeField]
    GameObject resultScoreText;

    [SerializeField]
    DataCreateSave createSave;

    [SerializeField]
    PlayerLifeManagement playerLifeManagement;

    [SerializeField]
    Text resultTimer;

    [SerializeField]
    TimerController timerController;

    #endregion

    #region//プライベート変数  bool

    //bool gameClear = false; //ゲームクリアーしたら操作を無効にする

    #endregion

    void Start()
    {
        //resultUI.SetActive(false);
        resultRSButton.SetActive(false);
        //resultGameScoreText.enabled = false;
        //resultGamehighScoreText.enabled = false;
        resultScoreText.SetActive(false);
        resultTimer.enabled = false;
        gameOverUI.SetActive(false);
        //winUI.SetActive(false);
    }
    //　タイトルボタンを押したら実行する
    public void TitleBackBottan()
    {
        print("Title");
        SceneManager.LoadScene("TitleMenuScene");
    }

    public void GameOver()
    {
        //resultUI.SetActive(true);

        resultScoreText.SetActive(true);

        winUI.SetActive(false);

        gameOverUI.SetActive(true);

        gameOverText.enabled = true;

        resultRSButton.SetActive(true);

        resultGameOverPanel.SetActive(true);

        resultGameOverIcon.SetActive(true);

        //resultTimer.text = timerController.ToString();

        resultTimer.enabled = true;

        timerController.enabled = false;

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

        buttonController.SetActive(false);

        //resultGameScoreText.enabled = true;

        //resultGamehighScoreText.enabled = true;

        resultGameScoreText.text = "Score: " + playerLifeManagement.score.ToString();
        resultGamehighScoreText.text = "High Score: " + playerLifeManagement.highScore.ToString();

        createSave.score = "Score: " + playerLifeManagement.score.ToString();
        createSave.highScore = "High Score: " + playerLifeManagement.highScore.ToString();


        //SceneManager.LoadScene("");
    }

    public void GameClear()
    {
        resultScoreText.SetActive(true);

        winUI.SetActive(true);

        gameOverUI.SetActive(false);

        winText.SetActive(true);

        resultRSButton.SetActive(true);

        resultGameClearPanel.SetActive(true);

        resultWinIcon.SetActive(true);

        buttonController.SetActive(false);

        scoreUI.SetActive(false);

        resultTimer.enabled = true;

        timerController.enabled = false;

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

        //resultGameScoreText.enabled = true;

        //resultGamehighScoreText.enabled = true;

        resultGameScoreText.text = "Score: " + playerLifeManagement.score.ToString();
        resultGamehighScoreText.text = "High Score: " + playerLifeManagement.highScore.ToString();

        createSave.score = "Score: " + playerLifeManagement.score.ToString();
        createSave.highScore = "High Score: " + playerLifeManagement.highScore.ToString();

    }
}
