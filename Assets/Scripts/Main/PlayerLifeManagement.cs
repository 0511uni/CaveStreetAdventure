using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static GameStatus;

/// <summary>
/// プレイヤーのライフ管理
/// </summary>
public class PlayerLifeManagement : MonoBehaviour
{
    #region//インスペクターで設定する

    [SerializeField]
    Text scoreText;  //  スコアのUI

    public int score; //  スコア

    public int highScore; //ハイスコア用変数

    [SerializeField]
    Text highScoreText; //ハイスコアを表示するText

    [SerializeField]
    GameManagement gameManagement;

    [SerializeField]
    PlayerShotAttackController playerShotAttackController;

    [SerializeField]
    GameObject shotButton;

    [SerializeField]
    GameStatus gameStatus;

    public int itemNam;

    public GameObject[] items;

    string timer;

    #endregion

    #region//インスペクターで設定する サウンドSE
    public AudioSource SoundSE;
    public AudioClip Se1;
    public AudioClip Se2;
    #endregion

    #region//プライベート変数 ハイスコアー保存キー

    string key = "HIGH SCORE"; //ハイスコアの保存先キー

    //bool gameOver;
    #endregion

    /// <summary>
    /// アイテム制御のプロパティ
    /// </summary>
    public int Items
    {
        get => itemNam;
        set
        {
            if (value < 0 || value > items.Length)
            {
                return;
            }

            itemNam = value;

            for (int i = 0; i < items.Length; i++)
            {
                items[i].SetActive(i < value);
            }
        }
    }

    /// <summary>
    /// スコア制御するプロパティ
    /// </summary>
    public int Score
    {
        get => score;
        set
        {
            if (value <= 0)
            {
                score = 0;
                return;
            }

            score = value;
        }
    }

    void Start()
    {
        Score = 10;
        scoreText.text = "Score: " + Score.ToString();
        //highScore = PlayerPrefs.GetInt(key, 0);

        //gameStatus.rankings.Sort((a, b) => b.Score - a.Score);//ダミー用

        Ranking ranking;
        if (gameStatus.rankings.Count != 0)
        {
            ranking = gameStatus.rankings[0];
            //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
            highScoreText.text = "HighScore: " + ranking.Score.ToString();
        }
        else
        {
            ranking = null;
            //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
            highScoreText.text = "HighScore: " + Score.ToString();
        }

        foreach (var item in items)
        {
            item.SetActive(false);
        }

    }

    /// <summary>
    /// マイキャラが他のオブジェクトにぶつかった時に呼び出される
    /// </summary>
    /// <param name="other">タグの相手</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        // ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Item"))
        {
            //　その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            //  スコアを加算します
            Score++;

            //  スコアを加算時のSE
            SoundSE.PlayOneShot(Se1);

            //  UI の表示を最新します
            SetCountText();

            Items++;
        }
        else if (other.gameObject.CompareTag("Item10"))
        {
            //　その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            //  スコアを加算します
            Score += 20;
            print("ビックだ");

            //  スコアを加算時のSE
            SoundSE.PlayOneShot(Se1);

            //  UI の表示を最新します
            SetCountText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Score--;

            SoundSE.PlayOneShot(Se2); //SE
            //  UI の表示を最新します
            SetCountText();
        }
        else if
         (other.gameObject.CompareTag("Enemy2"))
        {
            Score -= 10;

            SoundSE.PlayOneShot(Se2); //SE
            //  UI の表示を最新します
            SetCountText();
        }
        else if
         (other.gameObject.CompareTag("Enemy3"))
        {
            Score -= 20;

            SoundSE.PlayOneShot(Se2); //SE

            //  UI の表示を最新します
            SetCountText();
        }
    }

    // UI の表示を最新する
    public void SetCountText()
    {
        Debug.Log("setcount");

        //  スコアの表示を最新
        scoreText.text = "Score: " + Score.ToString();

        // ランカーがいれば
        if (gameStatus.rankings.Count != 0)
        {
            Ranking ranking = gameStatus.rankings[0];

            //ハイスコアを表示
            highScoreText.text = "HighScore: " + ranking.Score.ToString();
            
            //ランカーがスコアより高得点になったら
            if (Score > ranking.Score)
            {
                // そのスコアーをランカーに代入
                ranking.Score = Score;

                // スクリプタブルオブジェクトの保存
                gameStatus.Save();

                //ハイスコアを表示
                highScoreText.text = "HighScore: " + ranking.Score.ToString();
            }
        }
        // ランカーがいないときは
        else
        {
            highScoreText.text = "HighScore: " + Score.ToString();
        }

        //スコアゼロ以下になったらゲームオーバーが呼ばれる。
        if (Score <= 0) gameManagement.GameOver();
    }
}
