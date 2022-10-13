using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 往復する敵の制御
/// </summary>
public class EnemyRoundTripAct : MonoBehaviour
{

    #region//プライベート変数

    Rigidbody2D rb = null;
    Vector3 pos;
    float delta = 20.0f;

    [SerializeField]
    float speed = 3;
    new SpriteRenderer renderer;

    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        renderer = gameObject.GetComponentInChildren<SpriteRenderer>(); //InChidren
        renderer.flipX = false;

        pos = transform.position;

    }

    
    void Update()
    {
        Vector3 v3 = pos;
        v3.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v3;
    }

    /// <summary>
    /// 当たった時の処理
    /// </summary>
    /// <param name="collision">コライダー</param>
    void OnCollisionEnter2D(Collision2D collision)
    {


        // ぶつかったオブジェクトが壁1だった場合
        if (collision.gameObject.CompareTag("Wall"))
        {
            // 進む向きで左右の向きを変える
            renderer.flipX = true;
        }

        // ぶつかったオブジェクトが壁2だった場合
        if (collision.gameObject.CompareTag("Wall2"))
        {
            // 進む向きで左右の向きを変える
            renderer.flipX = false;
        }

    }

    /// <summary>
    /// トリガーとの接触時に呼ばれるコールバック
    /// </summary>
    /// <param name="hit">当たった</param>
    void OnTriggerEnter2D(Collider2D hit)
    {


        // 接触対象はPlayerタグですか？
        if (hit.CompareTag("Player"))
        {

            // 何らかの処理
        }
    }
}