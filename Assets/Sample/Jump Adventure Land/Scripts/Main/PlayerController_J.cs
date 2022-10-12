using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // シーン替え

public class PlayerController_J : MonoBehaviour
{
    #region//インスペクターで設定する
    //  // speedを制御する
    public float speed = 15;

    public float jumppower = 8;

    public Text scoreText;  //  スコアのUI

    public Text scoreText2;  //  スコアのUI

    public int score; //  スコア

    public int score2; //  スコア

    public Text highScoreText; //ハイスコアを表示するText

    public Text highScoreText2; //ハイスコアを表示するText
    #endregion

    #region//プライベート変数 ハイスコアー保存キー
    private int highScore; //ハイスコア用変数

    private string key = "HIGH SCORE"; //ハイスコアの保存先キー
    #endregion

    #region//インスペクターで設定する
    public static int highScorepoint = 0;

    public Text winText;  //  リザルトのUI

    public Text gameOverText; // ゲームオーバーUI

    public GameObject retryButton; //GameObject
    #endregion

    #region//プライベート変数  bool
    private bool restart;
    private bool pushFlag;
    private bool jumpFlag;

    private bool gameClear = false; //ゲームクリアーしたら操作を無効にする
    private bool gameOver = false; //ゲームオーバーで操作を無効にする
    #endregion

    #region//インスペクターで設定する resultUI
    public GameObject resultUI;

    public GameObject resultUI2;

    public GameObject resultUI3;

    public GameObject resultUI4;

    public GameObject resultUI5;
    #endregion

    #region//インスペクターで設定する サウンドSE
    public AudioSource SoundSE;
    public AudioClip Se1;
    public AudioClip Se2;
    public AudioClip WinSE;
    public AudioClip GameOverSE;
    #endregion

    #region//プライベート変数　SpriteRenderer
    SpriteRenderer renderer;
    Rigidbody2D rbody;
    #endregion

    #region//タイマーを設定する。
    //[SerializeField]
    //private int minute;
    //[SerializeField]
    //private float seconds;
    ////　前のUpdateの時の秒数
    //private float oldSeconds;
    ////　タイマー表示用テキスト
    //public Text timerText;
    //public Text highScoreTimerText; //ハイスコアタイムを表示するText
    //private float highScoreTimer; //ハイスコアタイム用変数
    //private string key_2 = "HIGH SCORE TIMER"; //ハイスコアタイムの保存先キー
    #endregion




    //　RANKING Buttonを押したら実行する
    public void RankingStart()
    {
        print("b");
        SceneManager.LoadScene("Ranking_Jump Adventure Land");
    }

    public void RSButtonDown()
    {
        #region //編集要素コメント
        if (restart)
        {
            //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //}
        }
        #endregion
    }

    #region //編集要素コメント

    //bool flipFlag = false;

    //bool test = true;

    //private bool isRight = true;
    //private bool isLeft = true;


    //当たった時の処理
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //当たったオブジェクトを消す
    // Destroy(collision.gameObject);
    //}
    #endregion

    public void LButtonDown()
    {
        transform.Translate(-20, 0, 0);

        renderer.flipX = true;

        #region //編集要素コメント
        //transform.localScale = new Vector3(-1, 1, 1);

        ////右を向いているかどうかを、入力方向をみて決める
        //isRight = (h > 0);
        ////localScale.xを、右を向いているかどうかで更新する
        //transform.localScale = new Vector3((isRight ? 2 : -2), 2, 2);

        //flipFlag = !flipFlag;
        //GetComponent<Spritetransform.localScale = new Vector3(-1, 1, 1);>().flipX;
        //= flipFlag;
        //isLeft = false;


        //if (isLeft == true)
        //{

        //}
        //else if (isLeft == false)
        //{
        //    isLeft = true;
        //}



        //if (RButtonDown)
        //{
        //    through;
        //}
        #endregion

    }

    public void RButtonDown()
    {
        transform.Translate(20, 0, 0);

        renderer.flipX = false;

        #region //編集要素コメント
        //transform.localScale = new Vector3(1, 1, 1);


        //// スケール値取り出し
        //Vector3 scale = transform.localScale;
        //if (isRight == true)
        //{
        //    // 右方向に移動中
        //    scale.x = 1; // そのまま（右向き）
        //}
        //else
        //{
        //    // 左方向に移動中
        //    scale.x = -1; // 反転する（左向き）
        //}
        //// 代入し直す
        //transform.localScale = scale;


        //flipFlag = !flipFlag;
        //GetComponent<SpriteRenderer>().flipX = flipFlag;
        //isRight = false;

        //if (isRight == true)
        //{

        //}
        //else if (isRight == false)
        //{
        //    isRight = true;
        //}

        //if (test == true)
        //{
        //    flipFlag = !flipFlag;
        //    GetComponent<SpriteRenderer>().flipX = flipFlag;
        //    test = false;
        //}
        #endregion
    }

    public void UButtonDown()
    {
        transform.Translate(0, 20, 0);

        if (pushFlag == false)
        {
            jumpFlag = true;
            pushFlag = true;
        }
        else
        {
            pushFlag = false;
        }
    }

    public void DButtonDown()
    {
        transform.Translate(0, -20, 0);
    }


    // Start is called before the first frame update
    void Start()
    {
        score = 10;
        scoreText.text = "Count: " + score.ToString();
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>(); //InChidren
        renderer.flipX = false;

        rbody = GetComponent<Rigidbody2D>();

        winText.text = " ";
        gameOverText.text = "";
        gameOver = false;

        //restart = false;
        retryButton.SetActive(false);

        highScore = PlayerPrefs.GetInt(key, 0);
        //保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        highScoreText.text = "High Score: " + highScore.ToString();
        //AudioSourceコンポーネントを取得し、変数に格納
        SoundSE = this.gameObject.GetComponent<AudioSource>();


        //minute = 0;
        //seconds = 0f;
        //oldSeconds = 0f;
        //timerText = GetComponentInChildren<Text>();

        //highScoreTimer = PlayerPrefs.GetInt(key_2, 0);
        ////保存しておいたハイスコアをキーで呼び出し取得し保存されていなければ0になる
        //highScoreTimerText.text = "Timer: " + minute.ToString("00") + ":" + ((int)seconds).ToString("00").ToString();

        resultUI.SetActive(false);
        resultUI2.SetActive(false);
        resultUI3.SetActive(false);
        resultUI4.SetActive(false);
        resultUI5.SetActive(false);


        #region //編集要素コメント
        //DontDestroyOnLoad(this);
        //ハイスコアを表示
        // PlayerPrefs.DeleteAll();
        // // ハイスコアデータリセット
        // //  DontDestroyOnLoad(this);
        // // // DontDestroyOnLoadを使うことで、Sceneを切り替えてもGameObjectが破棄されなくなります。
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(score);
        GetComponent<AudioSource>().Play(); // seを鳴らす。

        #region //編集要素コメント

        //seconds += Time.deltaTime;
        //if (seconds >= 60f)
        //{
        //    minute++;
        //    seconds = seconds - 60;
        //}
        ////　値が変わった時だけテキストUIを更新
        //if ((int)seconds != (int)oldSeconds)
        //{
        //    timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        //}
        //oldSeconds = seconds;

        //// ハイスコアタイムより現在スコアタイムが高い時
        //if (seconds >= highScoreTimer)
        //{

        //    // highScoreTimer = minute;
        //    highScoreTimer = seconds;
        //    //ハイスコア更新

        //    PlayerPrefs.SetFloat(key_2, highScoreTimer);
        //    //ハイスコアを保存

        //    highScoreTimerText.text = "Timer: " + minute.ToString("00") + ":" + ((int)seconds).ToString("00").ToString();
        //    //ハイスコアを表示
        //}
        #endregion
    }


    void FixedUpdate()
    {
        if (jumpFlag)
        {
            jumpFlag = false;
            rbody.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
        }

        #region //編集要素コメント

        //////左右キーの入力
        //float h = Input.GetAxis("Horizontal");
        ////rigidbody2D.AddForce(Vector2.right * h * 300f);

        ////右を向いていて、左の入力があったとき、もしくは左を向いていて、右の入力があったとき
        //if ((h > 0 && !isRight) || (h < 0 && isRight))
        //{
        //    //右を向いているかどうかを、入力方向をみて決める
        //    isRight = (h > 0);
        //    //localScale.xを、右を向いているかどうかで更新する
        //    transform.localScale = new Vector3((isRight ? 2 : -2), 2, 2);
        //}

        #endregion
    }

    #region // 他の機能追加編集用
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    // ぶつかったオブジェクトが収集アイテムだった場合
    //    if (other.gameObject.CompareTag("Item"))
    //    {
    //        //　その収集アイテムを非表示にします
    //        other.gameObject.SetActive(false);

    //        //  スコアを加算します
    //        score = score + 1;


    //        ////  UI の表示を最新します
    //        SetCountText();
    //    }

    //    // ハイスコアより現在スコアが高い時
    //    if (score > highScore)
    //    {

    //        highScore = score;
    //        //ハイスコア更新

    //        PlayerPrefs.SetInt(key, highScore);
    //        //ハイスコアを保存

    //        highScoreText.text = "HighScore: " + highScore.ToString();
    //        //ハイスコアを表示
    //    }
    //}


    //void OnCollisionEnter2D(Collision2D col)
    //{
    //    //EnemyにぶつかるとEnemyカウント-1
    //    if (col.gameObject.tag == "Enemy")
    //    {
    //        score -= 1;

    //        //SetCountText(); //  UI の表示を最新します
    //    }
    //}
    #endregion

    // マイキャラが他のオブジェクトにぶつかった時に呼び出される
    void OnCollisionEnter2D(Collision2D other)
    {
        // ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Item"))
        {
            //　その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            //  スコアを加算します
            score = score + 10;

            //  スコアを加算時のSE
            SoundSE.PlayOneShot(Se1);


            //  UI の表示を最新します
            SetCountText();
        }

        // ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Item10"))
        {
            //　その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            //  スコアを加算します
            score = score + 100;

            //  スコアを加算時のSE
            SoundSE.PlayOneShot(Se1);


            //  UI の表示を最新します
            SetCountText();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            {
                score -= 1;

                SoundSE.PlayOneShot(Se2); //SE

                //  UI の表示を最新します
                SetCountText();
            }
        }

        if (other.gameObject.CompareTag("Enemy2"))
        {
            {
                score -= 5;

                SoundSE.PlayOneShot(Se2); //SE

                //  UI の表示を最新します
                SetCountText();
            }
        }

        if (other.gameObject.CompareTag("Enemy3"))
        {
            {
                score -= 10;

                SoundSE.PlayOneShot(Se2); //SE

                //  UI の表示を最新します
                SetCountText();
            }
        }

        //  スコアの表示を最新
        scoreText.text = "Count: " + score.ToString();
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

        if (other.gameObject.CompareTag("Goal"))
        {
            {
                GameClear();
            }
        }
    }

    // UI の表示を最新する
    void SetCountText()
    {
        //  スコアの表示を最新
        scoreText.text = "Count: " + score.ToString();

        if (score <= 0)
        {
            gameOver = true;
            print("gameovr");
            //  リザルドの表示を最新
            GetComponent<PlayerController_J>().enabled = false; // 自分のとこのコンポーネントを止める


            gameOverText.text = "Game Over!";
            SoundSE.PlayOneShot(GameOverSE);


            #region //編集要素コメント

            //retryButton.SetActive(true);
            //RButtonDown();
            //restart = true;

            #endregion

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

            #region //編集要素コメント
            //GameObject[] enemy3 = GameObject.FindGameObjectsWithTag("Enemy3");
            //foreach (var enemy_3 in enemy3)
            //{
            //    enemy_3.GetComponent<Enemy_2>().enabled = false; // Enemyのコンポーネントを止める。
            //}
            #endregion
        }
    }

    void GameClear()
    {
        if (!gameClear)
        {
            GetComponent<PlayerController_J>().enabled = false; // 自分のとこのコンポーネントを止める





            winText.text = "You Win!";
            SoundSE.PlayOneShot(WinSE);

            #region //編集要素コメント

            //RButtonDown();
            //restart = true;

            #endregion

            retryButton.SetActive(true);
            resultUI.SetActive(true);
            resultUI2.SetActive(true);
            resultUI4.SetActive(true);

            //GameObject Time = GameObject.Find("TimeText");
            //Time.GetComponent<Timer>().enabled = false;

            GameObject Time = GameObject.Find("TimerText");
            Time.GetComponent<TimerScript>().enabled = false;

            scoreText2.text = "Count: " + score.ToString();


            highScoreText2.text = "High Score: " + highScore.ToString();

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


            #region //編集要素コメント

            //GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            //foreach (var enemy in enemys)
            //{
            //    enemy.GetComponent<Enemy>().enabled = false; // Enemyのコンポーネントを止める。
            //    //enemy.GetComponent<Enemy_2>().enabled = false; // Enemyのコンポーネントを止める。
            //}

            //GameObject[] enemys2 = GameObject.FindGameObjectsWithTag("Enemy2");
            //foreach (var enemy in enemys2)
            //{
            //    enemy.GetComponent<Enemy>().enabled = false; // Enemyのコンポーネントを止める。
            //}

            //GameObject[] enemys3 = GameObject.FindGameObjectsWithTag("Enemy3");
            //foreach (var enemy in enemys3)
            //{
            //    enemy.GetComponent<Enemy_2>().enabled = false; // Enemyのコンポーネントを止める。
            //}

            #endregion


        }
    }

    public void OnRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


