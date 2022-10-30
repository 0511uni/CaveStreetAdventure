using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDownMove : MonoBehaviour
{
    #region//インスペクターで設定する


    [Header("移動速度")] public float speed;

    [Header("重力")] public float gravity;

    [Header("画面外でも行動する")] public bool nonVisibleAct;

    #endregion


    #region//プライベート変数
    private Rigidbody2D rbody = null;

    private SpriteRenderer sr = null;

    private bool rightTleftF = false;


    #endregion

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (sr.isVisible || nonVisibleAct)
        {
            int xVector = -5;

            if (rightTleftF)
            {
                xVector = 5;
                transform.localScale = new Vector3(-1, 1, 0);// (-1, 1, 0)
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 0);// (1, 1, 0)
                                                            //renderer.flipX = true;
            }
            rbody.velocity = new Vector2(xVector * speed, -gravity);
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
            GetComponent<EnemyDownMove>().enabled = false;
            Destroy(GetComponent<Rigidbody2D>());

        }
    }
}
