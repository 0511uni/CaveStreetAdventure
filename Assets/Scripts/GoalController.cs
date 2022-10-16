using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalController : MonoBehaviour
{
    #region//インスペクターで設定する

    [SerializeField]
    Text winText;  //  リザルトのUI

    [SerializeField]
    GameObject enemy;

    [SerializeField]
    GameObject resultRSButton;

    [SerializeField]
    GameObject resultGameClearPanel;

    #endregion

    #region//プライベート変数  bool

    bool gameClear = false; //ゲームクリアーしたら操作を無効にする

    #endregion


    void Start()
    {
        winText.enabled = false;
        enemy.GetComponent<EnemyRoundTripAct>().enabled = true;
        resultRSButton.SetActive(false);
        resultGameClearPanel.SetActive(false);
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

        resultRSButton.SetActive(true);

        resultGameClearPanel.SetActive(true);

        enemy.GetComponent<EnemyRoundTripAct>().enabled = false;
    }
}
