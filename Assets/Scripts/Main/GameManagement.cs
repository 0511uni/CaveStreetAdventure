using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static GameStatus;
using static UnityEngine.EventSystems.EventTrigger;
using Button = UnityEngine.UI.Button;
//using UnityEngine.UIElements;
//using static UnityEditor.Timeline.TimelinePlaybackControls;


/// <summary>
/// ゲーム全体を制御する
/// </summary>
public class GameManagement : MonoBehaviour
{
    #region//インスペクターで設定する

    [SerializeField]
    GameObject player;

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
    GameObject[] winResults;//wins

    [SerializeField]
    GameObject gameOverUI;

    [SerializeField]
    GameObject rankingButton;

    [SerializeField]
    Text resultGameScoreText;

    [SerializeField]
    Text resultGamehighScoreText;

    [SerializeField]
    GameStatus gameStatus;

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

    [SerializeField] Text inputName;

    string timer;

    #endregion

    #region//インスペクターで設定する サウンドSE
    public AudioSource SoundSE;
    public AudioClip WinSE;
    public AudioClip GameOverSE;
    private int inputNum;

    #endregion



    void Start()
    {
        // 最初は非表示
        foreach (var winResult in winResults)
        {
            winResult.SetActive(false);
        }

        titleBackButton.SetActive(false);
        resultRSButton.SetActive(false);
        gameOverUI.SetActive(false);
        pausePanel.SetActive(false);
        resultTimer.enabled = false;
        pauseButton.onClick.AddListener(Pause);
        resumeButton.onClick.AddListener(Resume);
    }

    /// <summary>
    /// ゲームを一時停止する
    /// </summary>
    private void Pause()
    {
        // Time.timeScaleで時間の流れの速さを決める。0だと時間が停止する
        Time.timeScale = 0;
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
    /// RANKING Buttonを押したら実行する
    /// </summary>
    public void RankingStart()
    {
        AddRanking();
        gameStatus.Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Ranking");
    }

    /// <summary>
    /// ランキングを送るボタン
    /// </summary>
    public void RankingNameButton()
    {
        //AddRanking();
        inputName.GetComponent<Text>().enabled = false;
        rankingButton.GetComponent<Button>().enabled = false;
    }

    //public void Add

    /// <summary>
    /// ランキングにデータを生成する
    /// </summary>
    public void AddRanking()
    {

        Debug.Log("RankB");

        string nameValue = inputName.text;

        //// 入力された文字の文字数をコンソール画面に表示する
        //Debug.Log(nameValue.Length);

        ////８文字まで入力できる。それ以上は入力できない
        //if (nameValue.Length < 9)
        //{
        //    nameValue = inputName.text;
        //    Debug.Log(nameValue);
        //}

        timer = resultTimer.text;

        Ranking rank = new Ranking(nameValue, playerLifeManagement.Score, timer);
        gameStatus.rankings.Add(rank);
        gameStatus.rankings.Sort((a, b) => b.Score - a.Score);
    }

    

    /// <summary>
    /// ゲームオーバー実行
    /// </summary>
    public void GameOver()
    {
        Destroy(player.GetComponent<Rigidbody2D>());

        SoundSE.PlayOneShot(GameOverSE);

        titleBackButton.SetActive(true);

        gameOverUI.SetActive(true);

        resultRSButton.SetActive(true);

        resultTimer.enabled = true;

        timerController.enabled = false;

        foreach (var winResult in winResults)
        {
            winResult.SetActive(false);
        }

        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemys)
        {
            // Enemyのコンポーネントを止める。
            enemy.GetComponent<EnemyRoundTripAct>().enabled = false;
        }

        enemys = GameObject.FindGameObjectsWithTag("Enemy2");

        foreach (var enemy in enemys)
        {
            // Enemyのコンポーネントを止める。
            enemy.GetComponent<LoopMoveEnemy>().enabled = false;
        }

        enemys = GameObject.FindGameObjectsWithTag("Enemy3");

        foreach (var enemy in enemys)
        {
            // Enemyのコンポーネントを止める。
            enemy.GetComponent<EnemyDownMove>().enabled = false;
            // EnemyのRigidbodyを止める。
            Destroy(enemy.GetComponent<Rigidbody2D>());  
        }

        warps = GameObject.FindGameObjectsWithTag("Warp");
        foreach (var warp in warps)
        {
            // Warpを止める。
            warp.SetActive(false);
        }

        downLifts = GameObject.FindGameObjectsWithTag("Lift");

        foreach (var downLift in downLifts)
        {
            // Liftのコンポーネントを止める。
            downLift.GetComponent<LiftDownMove>().enabled = false;

            // LiftのRigidbodyを止める。
            Destroy(downLift.GetComponent<Rigidbody2D>());
        }

        scoreUI.SetActive(false);

        buttonController.SetActive(false);
    }

    /// <summary>
    /// ゲームクリア実行
    /// </summary>
    public void GameClear()
    {
        Destroy(player.GetComponent<Rigidbody2D>());

        SoundSE.PlayOneShot(WinSE);

        titleBackButton.SetActive(true);

        resultRSButton.SetActive(true);

        gameOverUI.SetActive(false);

        buttonController.SetActive(false);

        scoreUI.SetActive(false);

        resultTimer.enabled = true;

        timerController.enabled = false;


        foreach (var winResult in winResults)
        {
            winResult.SetActive(true);
        }

        enemys = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var enemy in enemys)
        {
            // Enemyのコンポーネントを止める。
            enemy.GetComponent<EnemyRoundTripAct>().enabled = false;
        }

        enemys = GameObject.FindGameObjectsWithTag("Enemy2");

        foreach (var enemy in enemys)
        {
            // Enemyのコンポーネントを止める。
            enemy.GetComponent<LoopMoveEnemy>().enabled = false;
        }

        warps = GameObject.FindGameObjectsWithTag("Warp");
        foreach (var warp in warps)
        {
            // Warpのコンポーネントを止める。
            warp.SetActive(false);
        }

        downLifts = GameObject.FindGameObjectsWithTag("Lift");

        foreach (var downLift in downLifts)
        {
            // Liftのコンポーネントを止める。
            downLift.GetComponent<LiftDownMove>().enabled = false;

            // Liftのコンポーネントを止める。
            Destroy(downLift.GetComponent<Rigidbody2D>());
        }

        resultGameScoreText.text = "Score: " + playerLifeManagement.Score.ToString();

        if (gameStatus.rankings.Count != 0)
        {
            Ranking ranking = gameStatus.rankings[0];

            resultGamehighScoreText.text = "HighScore: " + ranking.Score.ToString();
        }
        else
        {
            resultGamehighScoreText.text = "HighScore: " + playerLifeManagement.Score.ToString();
        }
    }
}
