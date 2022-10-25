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
}