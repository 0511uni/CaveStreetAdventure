using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 振り返りながら往復する敵の制御
/// </summary>
public class EnemyRoundTripAct : MonoBehaviour
{
    Rigidbody2D rb;

    int direction = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = direction * Vector3.left * 2;
    }

    /// <summary>
    /// コライダー
    /// </summary>
    /// <param name="collision">コライダー</param>
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 当たったコライダーが壁だったら
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction *= -1;
            transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.z);
        }
    }

    /// <summary>
    /// isTriggerの相手に対しての対応
    /// </summary>
    /// <param name="other">isTriggerしてる相手</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        // 相手のタグがBillだったら
        if (other.gameObject.CompareTag("Bill"))
        {
            Destroy(other.gameObject);
            //other.GetComponent<BillAttack>().enabled = false;

            // Enemy自身
            GetComponent<EnemyRoundTripAct>().enabled = false;
            Destroy(GetComponent<Rigidbody2D>());

        }
    }
}