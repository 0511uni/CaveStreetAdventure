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
    Text gameOverText; // ゲームオーバーUIText

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject enemy;

    [SerializeField]
    GameObject resultRSButton;

    [SerializeField]
    GameObject resultGameOverPanel;

    [SerializeField]
    GameObject resultGameOverIcon;

    [SerializeField]
    Text scoreTextGameOver;

    [SerializeField]
    Text highScoreTextGameOver;


    [SerializeField]
    GameObject scoreUI;

    [SerializeField]
    GameObject buttonController;

    #endregion

    void Start()
    {
        
        
        enemy.GetComponent<EnemyRoundTripAct>().enabled = true;
        
        scoreUI.SetActive(true);
        //timer.GetComponent<TimerController>().enabled = true;
        scoreTextGameOver.enabled = false;
        highScoreTextGameOver.enabled = false;
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

            scoreUI.SetActive(false);
            //timer.GetComponent<TimerController>().enabled = false;

            buttonController.SetActive(false);

            player.GetComponent<PlayerLifeManagement>().SetCountText();

            scoreTextGameOver.enabled = true;

            highScoreTextGameOver.enabled = true;
        }
    }
}
