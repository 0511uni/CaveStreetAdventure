using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : MonoBehaviour
{

    #region//インスペクターで設定する


    [Header("移動速度")] public float speed;

    [Header("重力")] public float gravity;
    
    [Header("画面外でも行動する")] public bool nonVisibleAct;

    #region // 他の機能追加編集用
    ////[Header("接触判定")] public EnemyCollisionCheck checkCollision;
    #endregion



    #endregion


    #region//プライベート変数
    private Rigidbody2D rbody = null;
    
    private SpriteRenderer sr = null;

    private bool rightTleftF = false;

    //public bool moveStatus = true;

    //private Vector2 transVec;

    #region // 他の機能追加編集用

    //Vector3 pos;
    //float delta = 20.0f; //2
    //float speed = 3.0f;

    ////private ObjectCollision oc = null;
    ////private BoxCollider2D col = null;

    ////private float deadTimer = 0.0f;

    //SpriteRenderer renderer;
    //////private bool isDead = false;
    ////bool flipFlag = false;
    #endregion

    #endregion


    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();

        #region // 他の機能追加編集用
        ////rb.gravityScale = 10;
        ////rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        #endregion

        sr = GetComponent<SpriteRenderer>();

        //transVec = transObj.transform.position;

        //moveStatus = true;

        #region // 他の機能追加編集用
        //renderer = gameObject.GetComponentInChildren<SpriteRenderer>(); //InChidren
        //renderer.flipX = false;

        //pos = transform.position;

        //oc = GetComponent<ObjectCollision>();
        //col = GetComponent<BoxCollider2D>();
        ////rb.gravityScale = 10;
        ////rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        #endregion

    }

    #region // 他の機能追加編集用

    //void Update()
    //{
    //    //Vector3 v = pos;
    //    //v.x += delta * Mathf.Sin(Time.time * speed);
    //    //transform.position = v;
    //}
    
    #endregion


    void FixedUpdate()
    {
        #region // 他の機能追加編集用
        //renderer.flipX = false;
        //rb.velocity = new Vector2(speed, 0);



        //////{
        #endregion



        if (sr.isVisible || nonVisibleAct)
        {


            #region // 他の機能追加編集用

            //    //if (checkCollision.isOn)
            //    //{
            //    //    rightTleftF = !rightTleftF;
            //    //}
            //renderer.flipX = false;
            //rb.velocity = new Vector2(speed, 0);



            //////{
            #endregion

            int xVector = -1;

            if (rightTleftF)
            {
            xVector = 1;
            transform.localScale = new Vector3(-56, 53, 0);// (-1, 1, 0)
            }
            else
            {
            transform.localScale = new Vector3(56, 53, 0);// (1, 1, 0)
            //renderer.flipX = true;
            }
            rbody.velocity = new Vector2(xVector * speed, -gravity);
        }   

    }

    #region // 他の機能追加編集用
    ////else
    ////{
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

    #region // 他の機能追加編集用
    //当たった時の処理
    void OnCollisionEnter2D(Collision2D collision)
    {
        ////speed = -speed; // 向きを反転させる



        //// ぶつかったオブジェクトが収集アイテムだった場合
        //if (collision.gameObject.CompareTag("Wall"))
        //{
        //    //// 進む向きで左右の向きを変える
        //    renderer.flipX = true;
        //}

        //// ぶつかったオブジェクトが収集アイテムだった場合
        //if (collision.gameObject.CompareTag("Wall2"))
        //{
        //    //// 進む向きで左右の向きを変える
        //    renderer.flipX = false;
        //}

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
    }
    #endregion



    // トリガーとの接触時に呼ばれるコールバック
    void OnTriggerEnter2D(Collider2D hit)
    {


        // 接触対象はPlayerタグですか？
        if (hit.CompareTag("Player"))
        {

            // 何らかの処理
        }
        //else if (hit.CompareTag("Warp"))
        //{
        //    transObj.moveStatus = false; // 左右移動のみ
        //    obj.transform.position = transVec;
        //}
    }
}
