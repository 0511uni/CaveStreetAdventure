using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region//他の機能追加編集用
    //[Header("移動速度")] public float speed = 1;


    //[Header("重力")] public float gravity;
    ////[Header("接触判定")] public EnemyCollisionCheck checkCollision;
    //[Header("画面外でも行動する")] public bool nonVisibleAct;
    #endregion

    #region//プライベート変数

    private Rigidbody2D rb = null;
    Vector3 pos;
    float delta = 20.0f; //2
    float speed = 3.0f;

    SpriteRenderer renderer;

    #region//他の機能追加編集用
    //private SpriteRenderer sr = null;

    ////private ObjectCollision oc = null; //New !
    ////private BoxCollider2D col = null; //New !

    ////private float deadTimer = 0.0f;

    //private bool rightTleftF = false;


    //////private bool isDead = false; //New !
    ////bool flipFlag = false;
    #endregion

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        #region//他の機能追加編集用
        ////rb.gravityScale = 10;
        ////rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        //sr = GetComponent<SpriteRenderer>();
        #endregion

        renderer = gameObject.GetComponentInChildren<SpriteRenderer>(); //InChidren
        renderer.flipX = false;

        pos = transform.position;

        #region//他の機能追加編集用
        //oc = GetComponent<ObjectCollision>(); //New !
        //col = GetComponent<BoxCollider2D>(); //New !
        #endregion
    }

    void Update()
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }

    #region // 他の機能追加編集用
    void FixedUpdate()
    {
        //renderer.flipX = false;
        ////rb.velocity = new Vector2(speed, 0);


        //////{
        //if (sr.isVisible || nonVisibleAct)
        //{



        //    //if (checkCollision.isOn)
        //    //{
        //    //    rightTleftF = !rightTleftF;
        //    //}

        //    int xVector = -1;

        //    if (rightTleftF)
        //    //{
        //    //    xVector = 1;
        //    //    transform.localScale = new Vector3(-56, 53, 0);// (-1, 1, 0)
        //    //}
        //    ////else
        //    {
        //        transform.localScale = new Vector3(56, 53, 0);// (1, 1, 0)
        //        renderer.flipX = true;
        //    }
        //    rb.velocity = new Vector2(xVector * speed, -gravity);
        //}

    }
    ////else
    ////{//New !
    //    //if (!isDead)
    //    //{
    //    //    rb.velocity = new Vector2(0, -gravity);
    //    //    isDead = true;
    //    //    //col.enabled = false;
    //    //}
    //        //else
    //        //{
    //        //    transform.Rotate(new Vector3(0, 0, 5));
    //        //    if (deadTimer > 3.0f)
    //        //    {
    //        //        Destroy(this.gameObject);
    //        //    }
    //        //    else
    //        //    {
    //        //        deadTimer += Time.deltaTime;
    //        //    }
    //        //}
    // }
    //}
    //}
    #endregion

    //当たった時の処理
    void OnCollisionEnter2D(Collision2D collision)
    {
        #region // 他の機能追加編集用
        ////speed = -speed; // 向きを反転させる
        #endregion


        // ぶつかったオブジェクトが収集アイテムだった場合
        if (collision.gameObject.CompareTag("Wall"))
        {
            //// 進む向きで左右の向きを変える
            renderer.flipX = true;
        }

        // ぶつかったオブジェクトが収集アイテムだった場合
        if (collision.gameObject.CompareTag("Wall2"))
        {
            //// 進む向きで左右の向きを変える
            renderer.flipX = false;
        }

        #region // 他の機能追加編集用

        //int xVector = -1;

        //if (rightTleftF)
        ////{
        ////    xVector = 1;
        ////    transform.localScale = new Vector3(-56, 53, 0);// (-1, 1, 0)
        ////}
        //////else
        //{
        //    transform.localScale = new Vector3(-56, -53, 0);// (1, 1, 0)
        //    renderer.flipX = true;
        //}
        //rb.velocity = new Vector2(xVector * speed, -gravity);

        ////if (!oc.playerStepOn) //New !
        ////当たったオブジェクトを消す
        ////Destroy(this.gameObject);
       
        #endregion
    }

    // トリガーとの接触時に呼ばれるコールバック
    void OnTriggerEnter2D(Collider2D hit)
    {
        

        // 接触対象はPlayerタグですか？
        if (hit.CompareTag("Player"))
        {
            
            // 何らかの処理
        }
    }
}
