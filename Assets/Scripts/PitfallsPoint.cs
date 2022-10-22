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
    GameObject[] enemys;

    [SerializeField]
    GameObject[] warps;

    [SerializeField]
    GameObject[] downLifts;

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

    [SerializeField]
    GameManagement GameManagement;

    #endregion

    void Start()
    {
        
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

            GameManagement.GameOver();

            //gameOverText.enabled = true;

            //resultRSButton.SetActive(true);

            //resultGameOverPanel.SetActive(true);

            //resultGameOverIcon.SetActive(true);

            //enemys = GameObject.FindGameObjectsWithTag("Enemy");

            //foreach (var enemy in enemys)
            //{
            //    enemy.GetComponent<EnemyRoundTripAct>().enabled = false; // Enemyのコンポーネントを止める。
            //}

            //enemys = GameObject.FindGameObjectsWithTag("Enemy2");

            //foreach (var enemy in enemys)
            //{
            //    enemy.GetComponent<LoopMoveEnemy>().enabled = false; // Enemyのコンポーネントを止める。
            //}

            //warps = GameObject.FindGameObjectsWithTag("Warp");
            //foreach (var warp in warps)
            //{
            //    warp.SetActive(false); // Warpのコンポーネントを止める。
            //}

            //downLifts = GameObject.FindGameObjectsWithTag("Lift");

            //foreach (var downLift in downLifts)
            //{
            //    downLift.GetComponent<LiftDownMove>().enabled = false; // Liftのコンポーネントを止める。
            //    Destroy(downLift.GetComponent<Rigidbody2D>()); // Liftのコンポーネントを止める。
            //}


            //scoreUI.SetActive(false);
            ////timer.GetComponent<TimerController>().enabled = false;

            //buttonController.SetActive(false);

            //player.GetComponent<PlayerLifeManagement>().SetCountText();

            //scoreTextGameOver.enabled = true;

            //highScoreTextGameOver.enabled = true;
        }
    }
}
