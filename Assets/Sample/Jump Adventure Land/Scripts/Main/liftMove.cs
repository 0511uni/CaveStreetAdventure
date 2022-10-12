using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftMove : MonoBehaviour
{



    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;


    [Header("重力")] public float gravity;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rbody = null;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //当たった時の処理
    void OnCollisionEnter2D(Collision2D collision)
    {
        

        // ぶつかったオブジェクトが収集アイテムだった場合
        if (collision.gameObject.CompareTag("Player"))
        {
            rbody = GetComponent<Rigidbody2D>();
            rbody.velocity = new Vector2(speed, -gravity);
        }

        
    }
}
