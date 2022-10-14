using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ゲーム全体を制御する
/// </summary>
public class GameManagement : MonoBehaviour
{
    #region//インスペクターで設定する

    public Text winText;  //  リザルトのUI

    #endregion

    #region//プライベート変数  bool

    bool gameClear = false; //ゲームクリアーしたら操作を無効にする
    
    #endregion


    void Start()
    {
        winText.text = " ";
    }

    void Update()
    {
        
    }

    public void GameClear()
    {
        gameClear = true;
        winText.text = "You Win!";
    }
}
