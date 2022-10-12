using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // シーン替え

public class GameManager_J : MonoBehaviour
{

    //　タイトルボタンを押したら実行する
    public void TitleBackBottan()
    {
        print("a");
        SceneManager.LoadScene("Title_Jump Adventure Land");
    }


    //public Text scoreText;  //  スコアのUI
    public Text winText;  //  リザルトのUI
    public Text gameOverText; // ゲームオーバーUI

    private bool gameClear = false; //ゲームクリアーしたら操作を無効にする
    private bool gameOver = false; //ゲームオーバーで操作を無効にする





    #region //編集要素コメント
    //private int score; //  スコア
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        #region //編集要素コメント
        //Screen.SetResolution(720, 1280, true);
        //Screen.SetResolution(Screen.width, (Screen.width / 2) * 3, true);
        #endregion

        winText.text = " ";
        gameOverText.text = "";
        gameOver = false;
    }

    #region //編集要素コメント
    // Update is called once per frame
    void Update()
    {

    }
    #endregion




}
