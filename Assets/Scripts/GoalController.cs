using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalController : MonoBehaviour
{
    #region//インスペクターで設定する

    public Text winText;  //  リザルトのUI

    public GameObject enemy;

    #endregion

    #region//プライベート変数  bool

    bool gameClear = false; //ゲームクリアーしたら操作を無効にする

    #endregion


    void Start()
    {
        winText.enabled = false;
        enemy.GetComponent<EnemyRoundTripAct>().enabled = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            {
                GameClear();
            }
        }
    }

    void GameClear()
    {
        gameClear = true;

        winText.enabled = true;
        enemy.GetComponent<EnemyRoundTripAct>().enabled = false;
    }
}
