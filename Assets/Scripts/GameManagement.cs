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

    //[SerializeField]
    //Text highScoreTextWin;  //  スコアのUI

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
    Text resultGameScoreText;

    [SerializeField]
    Text resultGamehighScoreText;

    [SerializeField]
    DataCreateSave createSave;

    [SerializeField]
    PlayerLifeManagement playerLifeManagement;

    #endregion

    #region//プライベート変数  bool

    //bool gameClear = false; //ゲームクリアーしたら操作を無効にする

    #endregion

    void Start()
    {
        winText.SetActive(false);
        resultRSButton.SetActive(false);
        resultGameClearPanel.SetActive(false);
        resultGameScoreText.enabled = false;
        resultWinIcon.SetActive(false);
        resultGamehighScoreText.enabled = false;
        gameOverText.enabled = false;
        resultGameOverPanel.SetActive(false);
        resultGameOverIcon.SetActive(false);
    }
    //　タイトルボタンを押したら実行する
    public void TitleBackBottan()
    {
        print("Title");
        SceneManager.LoadScene("TitleMenuScene");
    }

    public void GameOver()
    {
        //Debug.Log("ゲームオーバーメソッド");

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

        buttonController.SetActive(false);

        resultGameScoreText.enabled = true;

        resultGamehighScoreText.enabled = true;

        resultGameScoreText.text = "Score: " + playerLifeManagement.score.ToString();
        resultGamehighScoreText.text = "High Score: " + playerLifeManagement.highScore.ToString();

        createSave.score += "Score: " + playerLifeManagement.score.ToString();
        createSave.highScore = "High Score: " + playerLifeManagement.highScore.ToString();


        //SceneManager.LoadScene("DataCreateSub");
    }

    public void GameClear()
    {
        //gameClear = true;

        winText.SetActive(true);

        resultRSButton.SetActive(true);

        resultGameClearPanel.SetActive(true);

        resultWinIcon.SetActive(true);

        buttonController.SetActive(false);

        scoreUI.SetActive(false);

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

        resultGameScoreText.enabled = true;

        resultGamehighScoreText.enabled = true;

        resultGameScoreText.text = "Score: " + playerLifeManagement.score.ToString();
        resultGamehighScoreText.text = "High Score: " + playerLifeManagement.highScore.ToString();

        createSave.score = "Score: " + playerLifeManagement.score.ToString();
        createSave.highScore = "High Score: " + playerLifeManagement.highScore.ToString();

    }
}
