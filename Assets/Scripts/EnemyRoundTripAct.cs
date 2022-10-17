using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 往復する敵の制御
/// </summary>
public class EnemyRoundTripAct : MonoBehaviour
{
    Rigidbody2D rb;

    int direction = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * Vector3.left * 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction *= -1;
            transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
        }
    }

    //#region//プライベート変数

    //Rigidbody2D rb = null;
    //Vector3 pos;

    //[SerializeField]
    //float delta = 1.5f;

    //[SerializeField]
    //float speed = 0.3f;
    //new SpriteRenderer renderer;

    //#endregion

    //void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();

    //    renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
    //    renderer.flipX = false;
    //    pos = transform.position;

    //}

    
    //void Update()
    //{
    //    Vector3 v3 = pos;
    //    v3.x += delta * Mathf.Sin(Time.time * speed);
    //    transform.position = v3;
    //}

    ///// <summary>
    ///// 当たった時の処理
    ///// </summary>
    ///// <param name="collision">コライダー</param>
    //void OnCollisionEnter2D(Collision2D collision)
    //{


    //    // ぶつかったオブジェクトが壁1だった場合
    //    if (collision.gameObject.CompareTag("Wall"))
    //    {
    //        // 進む向きで左右の向きを変える
    //        renderer.flipX = true;
    //    }
    //    else if (collision.gameObject.CompareTag("Wall2"))
    //    {// ぶつかったオブジェクトが壁2だった場合
    //        // 進む向きで左右の向きを変える
    //        renderer.flipX = false;
    //    }

    //    if (collision.gameObject.CompareTag("Step"))
    //    {
    //        //　その収集アイテムを非表示にします
    //        this.gameObject.SetActive(false);
    //    }

    //}

    ///// <summary>
    ///// トリガーとの接触時に呼ばれるコールバック
    ///// </summary>
    ///// <param name="hit">当たった</param>
    //void OnTriggerEnter2D(Collider2D hit)
    //{


    //    // 接触対象はPlayerタグですか？
    //    if (hit.CompareTag("Player"))
    //    {

    //        // 何らかの処理
    //    }
    //}
}