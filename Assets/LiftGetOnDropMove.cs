using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftGetOnDropMove : MonoBehaviour
{
    #region//インスペクターで設定する
    [SerializeField]
    [Header("移動速度")] float speed;

    [SerializeField]
    [Header("重力")] float gravity;
    #endregion

    #region//プライベート変数
    Rigidbody2D rbody = null;
    #endregion

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
