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
    Text scoreText2;  //  スコアのUI

    [SerializeField]
    int score; //  スコア
    [SerializeField]
    int score2; //  スコア

    [SerializeField]
    Text highScoreText; //ハイスコアを表示するText

    [SerializeField]
    Text highScoreText2; //ハイスコアを表示するText

    [SerializeField]
    Text gameOverText; // ゲームオーバーUI

    [SerializeField]
    GameObject resultRSButton;

    [SerializeField]
    GameObject resultGameOverPanel;

    [SerializeField]
    GameObject resultGameOverIcon;
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
        scoreText2.enabled = false;
        highScoreText2.enabled = false;
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
        // ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Item"))
        {
            //　その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            //  スコアを加算します
            score += 10;


            //  UI の表示を最新します
            SetCountText();
        }

        // ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Item10"))
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
            {
                score -= 1;


                //  UI の表示を最新します
                SetCountText();
            }
        }

        //  スコアの表示を最新
        scoreText.text = "Count: " + score.ToString();
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
        scoreText.text = "Count: " + score.ToString();

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
        }
    }

    public void GameClearScore()
    {
        scoreText2.text = "Count: " + score.ToString();


        highScoreText2.text = "High Score: " + highScore.ToString();

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
