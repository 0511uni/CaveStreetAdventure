using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pitfalls : MonoBehaviour
{
    #region//インスペクターで設定する resultUI

    public GameObject resultUI;

    public GameObject resultUI3;

    public GameObject resultUI5;
    #endregion

    #region//インスペクターで設定する ゲームオーバー
    public Text gameOverText; // ゲームオーバーUI

    private bool gameOver = false; //ゲームオーバーで操作を無効にする

    public AudioSource SoundSE;

    public AudioClip GameOverSE;
    #endregion



    // Start is called before the first frame update
    void Start()
    {
        gameOverText.text = "";
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        GetComponent<AudioSource>().Play(); // seを鳴らす。 
    }

    //他のオブジェクトにぶつかった時に呼び出される
    void OnCollisionEnter2D(Collision2D other)
    {
        
        // 接触対象はPlayerタグですか？
        if (other.gameObject.CompareTag("Player"))
        {
            gameOver = true;
            print("gameovr");
            //  リザルドの表示を最新
            gameOverText.text = "Game Over!";
            SoundSE.PlayOneShot(GameOverSE);

            //retryButton.SetActive(true);
            //RButtonDown();
            //restart = true;
            resultUI.SetActive(true);
            resultUI3.SetActive(true);
            resultUI5.SetActive(true);

            //GameObject Time = GameObject.Find("TimeText");
            //Time.GetComponent<Timer>().enabled = false;

            GameObject Time = GameObject.Find("TimerText");
            Time.GetComponent<TimerScript>().enabled = false;

            GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy1 in enemy)
            {
                enemy1.GetComponent<Enemy>().enabled = false; // Enemyのコンポーネントを止める。


                #region //編集要素コメント

                //enemy.GetComponent<Enemy_2>().enabled = false; // Enemyのコンポーネントを止める。

                #endregion



            }

            GameObject[] enemy2 = GameObject.FindGameObjectsWithTag("Enemy2");
            foreach (var enemy_02 in enemy2)
            {
                enemy_02.GetComponent<Enemy_2>().enabled = false; // Enemyのコンポーネントを止める。
            }
        }
    }
}
