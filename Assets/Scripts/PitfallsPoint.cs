using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// ゲームオーバーポイント
/// </summary>
public class PitfallsPoint : MonoBehaviour
{
    #region//インスペクターで設定する ゲームオーバー
    [SerializeField]
    Text gameOverText; // ゲームオーバーUI

    [SerializeField]
    GameObject enemy;

    [SerializeField]
    GameObject resultRSButton;

    [SerializeField]
    GameObject resultGameOverPanel;

    [SerializeField]
    GameObject resultGameOverIcon;

    [SerializeField]
    GameObject timer;

    #endregion

    void Start()
    {
        gameOverText.enabled = false;
        enemy.GetComponent<EnemyRoundTripAct>().enabled = true;
        resultRSButton.SetActive(false);
        resultGameOverPanel.SetActive(false);
        resultGameOverIcon.SetActive(false);
        timer.GetComponent<TimerController>().enabled = true;
    }

    //void Update()
    //{
        
    //}

    //他のオブジェクトにぶつかった時に呼び出される
    void OnCollisionEnter2D(Collision2D other)
    {

        // 接触対象はPlayerタグですか？
        if (other.gameObject.CompareTag("Player"))
        {
            print("gameovr");
            //  リザルドの表示を最新
            gameOverText.enabled = true;

            resultRSButton.SetActive(true);

            resultGameOverPanel.SetActive(true);

            resultGameOverIcon.SetActive(true);

            enemy.GetComponent<EnemyRoundTripAct>().enabled = false;

            timer.GetComponent<TimerController>().enabled = false;
        }
    }
}
