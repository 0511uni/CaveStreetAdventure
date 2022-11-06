using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
//using UnityEngine.UIElements;
//using static UnityEditor.Timeline.TimelinePlaybackControls;
/// <summary>
/// ゲーム全体を制御する
/// </summary>
public class GameManagement : MonoBehaviour
{
    #region//インスペクターで設定する

    [SerializeField]
    GameObject resultRSButton;

    [SerializeField]
    GameObject scoreUI;

    [SerializeField]
    GameObject buttonController;

    [SerializeField]
    GameObject[] enemys;

    [SerializeField]
    GameObject[] warps;

    [SerializeField]
    GameObject[] downLifts;

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

    [SerializeField] GameObject pausePanel;

    [SerializeField] GameObject titleBackButton;

    [SerializeField] Button pauseButton;

    [SerializeField] Button resumeButton;

    #endregion

    #region//インスペクターで設定する サウンドSE
    public AudioSource SoundSE;
    public AudioClip WinSE;
    public AudioClip GameOverSE;
    #endregion

    void Start()
    {
        titleBackButton.SetActive(false);
        resultRSButton.SetActive(false);
        resultScoreText.SetActive(false);
        resultTimer.enabled = false;
        gameOverUI.SetActive(false);
        winUI.SetActive(false);
        pausePanel.SetActive(false);// 最初は非表示
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
    }

    /// <summary>
    /// ゲームを一時停止する
    /// </summary>
    private void Pause()
    {
        Time.timeScale = 0; // Time.timeScaleで時間の流れの速さを決める。0だと時間が停止する
        pausePanel.SetActive(true);
        titleBackButton.SetActive(true);
    }

    /// <summary>
    /// ゲームを再開する
    /// </summary>
    private void Resume()
    {
        Time.timeScale = 1; // また時間が流れるようにする
        pausePanel.SetActive(false);
        titleBackButton.SetActive(false);
    }

    /// <summary>
    /// タイトルボタン実行する
    /// </summary>
    public void TitleBackBottan()
    {
        print("Title");
        Resume();
        SceneManager.LoadScene("TitleMenuScene");
    }

    /// <summary>
    /// ゲームオーバー実行
    /// </summary>
    public void GameOver()
    {
        SoundSE.PlayOneShot(GameOverSE);

        titleBackButton.SetActive(true);

        resultScoreText.SetActive(true);

        winUI.SetActive(false);

        gameOverUI.SetActive(true);

        resultRSButton.SetActive(true);

        resultTimer.enabled = true;

        timerController.enabled = false;

        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemys)
        {
            enemy.GetComponent<EnemyRoundTripAct>().enabled = false; // Enemyのコンポーネントを止める。
            //enemy.GetComponent<EnemyDownMove>().enabled = false; // Enemyのコンポーネントを止める。
            //Destroy(enemy.GetComponent<Rigidbody2D>());// EnemyのRigidbodyを止める。
        }

        //enemys = GameObject.FindGameObjectsWithTag("Enemy");

        //foreach (var enemy2 in enemys)
        //{

        //    enemy2.GetComponent<EnemyDownMove>().enabled = false; // Enemyのコンポーネントを止める。
        //    Destroy(enemy2.GetComponent<Rigidbody2D>());// EnemyのRigidbodyを止める。
        //}

        enemys = GameObject.FindGameObjectsWithTag("Enemy2");

        foreach (var enemy in enemys)
        {
            enemy.GetComponent<LoopMoveEnemy>().enabled = false; // Enemyのコンポーネントを止める。
        }

        enemys = GameObject.FindGameObjectsWithTag("Enemy3");

        foreach (var enemy in enemys)
        {
            enemy.GetComponent<EnemyDownMove>().enabled = false; // Enemyのコンポーネントを止める。
            Destroy(enemy.GetComponent<Rigidbody2D>());// EnemyのRigidbodyを止める。
        }

        warps = GameObject.FindGameObjectsWithTag("Warp");
        foreach (var warp in warps)
        {
            warp.SetActive(false); // Warpを止める。
            //warp.GetComponent<WarpPoint>().enabled = false;
        }

        downLifts = GameObject.FindGameObjectsWithTag("Lift");

        foreach (var downLift in downLifts)
        {
            downLift.GetComponent<LiftDownMove>().enabled = false; // Liftのコンポーネントを止める。
            Destroy(downLift.GetComponent<Rigidbody2D>()); // LiftのRigidbodyを止める。
        }

        scoreUI.SetActive(false);

        buttonController.SetActive(false);

        resultGameScoreText.text = "Score: " + playerLifeManagement.score.ToString();
        resultGamehighScoreText.text = "High Score: " + playerLifeManagement.highScore.ToString();

        createSave.score = "Score: " + playerLifeManagement.score.ToString();
        createSave.highScore = "High Score: " + playerLifeManagement.highScore.ToString();
    }

    /// <summary>
    /// ゲームクリア実行
    /// </summary>
    public void GameClear()
    {
        SoundSE.PlayOneShot(WinSE);

        titleBackButton.SetActive(true);

        resultScoreText.SetActive(true);

        winUI.SetActive(true);

        gameOverUI.SetActive(false);

        resultRSButton.SetActive(true);

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

        resultGameScoreText.text = "Score: " + playerLifeManagement.score.ToString();
        resultGamehighScoreText.text = "High Score: " + playerLifeManagement.highScore.ToString();

        createSave.score = "Score: " + playerLifeManagement.score.ToString();
        createSave.highScore = "High Score: " + playerLifeManagement.highScore.ToString();
    }
}
