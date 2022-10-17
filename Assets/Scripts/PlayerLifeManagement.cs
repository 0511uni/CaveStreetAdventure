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
    public Text gameOverText;

    public Text scoreText;  //  スコアのUI

    public Text scoreText2;  //  スコアのUI

    public int score; //  スコア

    public int score2; //  スコア

    public Text highScoreText; //ハイスコアを表示するText

    public Text highScoreText2; //ハイスコアを表示するText
    #endregion

    #region//プライベート変数 ハイスコアー保存キー
    private int highScore; //ハイスコア用変数

    private string key = "HIGH SCORE"; //ハイスコアの保存先キー
    
    private bool gameOver;
    #endregion

    void Start()
    {
        score = 10;
        scoreText.text = "Count: " + score.ToString();
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
            score = score + 10;


            //  UI の表示を最新します
            SetCountText();
        }

        // ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Item10"))
        {
            //　その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            //  スコアを加算します
            score = score + 100;


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
    void SetCountText()
    {
        //  スコアの表示を最新
        scoreText.text = "Count: " + score.ToString();

        if (score <= 0)
        {
            gameOver = true;
            print("gameovr");
            //  リザルドの表示を最新
            GetComponent<PlayerController_J>().enabled = false; // 自分のとこのコンポーネントを止める


            gameOverText.text = "Game Over!";
        }
    }
}
