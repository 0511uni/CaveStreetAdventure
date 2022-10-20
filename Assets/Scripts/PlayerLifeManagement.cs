using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// プレイヤーのライフ管理
/// </summary>
public class PlayerLifeManagement : MonoBehaviour
{
    #region//インスペクターで設定する

    [SerializeField]
    GameObject enemy;

    [SerializeField]
    Text scoreText;  //  スコアのUI

    [SerializeField]
    Text scoreTextWin;  //  スコアのUI

    [SerializeField]
    Text scoreTextGameOver;

    public int score; //  スコア
    [SerializeField]
    int score2; //  スコア

    [SerializeField]
    Text highScoreText; //ハイスコアを表示するText

    [SerializeField]
    Text highScoreTextWin; //Winハイスコアを表示するText

    [SerializeField]
    Text highScoreTextGameOver;

    [SerializeField]
    Text gameOverText; // ゲームオーバーUI

    [SerializeField]
    GameObject resultRSButton;

    [SerializeField]
    GameObject resultGameOverPanel;

    [SerializeField]
    GameObject resultGameOverIcon;

    [SerializeField]
    GameObject scoreUI;

    [SerializeField]
    GameObject buttonController;
    #endregion

    #region//プライベート変数 ハイスコアー保存キー
    int highScore; //ハイスコア用変数

    string key = "HIGH SCORE"; //ハイスコアの保存先キー

    bool gameOver;
    #endregion

    void Start()
    {
        score = 10;
        scoreText.text = "Count: " + score.ToString();
        scoreTextWin.enabled = false;
        scoreTextGameOver.enabled = false;
        highScoreTextWin.enabled = false;
        highScoreTextGameOver.enabled = false;
        enemy.GetComponent<EnemyRoundTripAct>().enabled = true;
        gameOverText.enabled = false;
        resultRSButton.SetActive(false);
        resultGameOverPanel.SetActive(false);
        resultGameOverIcon.SetActive(false);

        highScore = PlayerPrefs.GetInt(key, 0);
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    //void Update()
    //{

    //}

    // マイキャラが他のオブジェクトにぶつかった時に呼び出される
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Item"))
        {// ぶつかったオブジェクトが収集アイテムだった場合
            //　その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            //  スコアを加算します
            score += 10;


            //  UI の表示を最新します
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Item10"))
        {
            //　その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            //  スコアを加算します
            score += 100;


            //  UI の表示を最新します
            SetCountText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            score--;
            //  UI の表示を最新します
            SetCountText();
        }


        //  スコアの表示を最新
        scoreText.text = "Score: " + score.ToString();
        // ハイスコアより現在スコアが高い時
        if (score > highScore)
        {

            highScore = score;
            //ハイスコア更新

            PlayerPrefs.SetInt(key, highScore);
            //ハイスコアを保存

            highScoreText.text = "HighScore: " + highScore.ToString();
            //ハイスコアを表示
        }
    }

    // UI の表示を最新する
    public void SetCountText()
    {
        //  スコアの表示を最新
        scoreText.text = "Score: " + score.ToString();//Count: 

        scoreTextGameOver.text = "Score: " + score.ToString();//Count:

        highScoreTextGameOver.text = "High Score: " + highScore.ToString();

        if (score <= 0)
        {//  リザルドの表示を最新
            gameOver = true;
            print("gameovr");

            enemy.GetComponent<EnemyRoundTripAct>().enabled = false; // 敵を止める

            GetComponent<PlayerController>().enabled = false; // 自分のとこのコンポーネントを止める

            gameOverText.enabled = true;

            resultRSButton.SetActive(true);

            resultGameOverPanel.SetActive(true);

            resultGameOverIcon.SetActive(true);

            scoreTextGameOver.enabled = true;

            highScoreTextGameOver.enabled = true;

            scoreUI.SetActive(false);

            buttonController.SetActive(false);
        }
    }

    public void GameClearScore()
    {
        scoreTextWin.text = "Score: " + score.ToString();


        highScoreTextWin.text = "High Score: " + highScore.ToString();

        // ハイスコアより現在スコアが高い時
        if (score > highScore)
        {

            highScore = score;
            //ハイスコア更新

            PlayerPrefs.SetInt(key, highScore);
            //ハイスコアを保存

            highScoreText.text = "HighScore: " + highScore.ToString();
            //ハイスコアを表示

        }
    }
}
