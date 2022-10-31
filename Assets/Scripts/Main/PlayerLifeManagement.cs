using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

    public int itemNam;
    
    public GameObject[] items;

    #endregion

    #region//プライベート変数 ハイスコアー保存キー

    string key = "HIGH SCORE"; //ハイスコアの保存先キー

    //bool gameOver;
    #endregion

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

    void Start()
    {
        score = 10;
        scoreText.text = "Count: " + score.ToString();
        highScore = PlayerPrefs.GetInt(key, 0);
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        highScoreText.text = "High Score: " + highScore.ToString();

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

        if (other.gameObject.CompareTag("Item"))
        {// ぶつかったオブジェクトが収集アイテムだった場合
            //　その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            //  スコアを加算します
            score += 1;


            //  UI の表示を最新します
            SetCountText();

            //shotButton.SetActive(true);

            Items++;
            //itemNam++;
            //ShowItem(itemNam);

            //itemNam--;
            //ShowItem(itemNam);
        }
        else if (other.gameObject.CompareTag("Item10"))
        {
            //　その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            //  スコアを加算します
            score += 20;
            print("ビックだ");

            //  UI の表示を最新します
            SetCountText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            score--;
            //  UI の表示を最新します
            SetCountText();
        }
        else if
         (other.gameObject.CompareTag("Enemy2"))
        {
            score -= 10;
            //  UI の表示を最新します
            SetCountText();
        }
        else if
         (other.gameObject.CompareTag("Enemy3"))
        {
            score -= 20;
            //  UI の表示を最新します
            SetCountText();
        }
    }

    // UI の表示を最新する
    public void SetCountText()
    {
        Debug.Log("setcount");
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
        else if (score <= 0)
        {
            gameManagement.GameOver();
        }
    }

    //public void ShowItem(int namber)
    //{
    //    foreach (GameObject item in items)
    //    {
    //        item.SetActive(false);
    //    }

    //    for (int i = 0; i < namber; i++)
    //    {
    //        items[i].SetActive(true);
    //    }       
    //}
}
