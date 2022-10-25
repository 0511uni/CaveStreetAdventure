using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 一定の距離を往復する敵のコントロール
/// </summary>
public class LoopMoveEnemy : MonoBehaviour
{
    #region//プライベート変数

    Rigidbody2D rb = null;
    Vector3 pos;

    [SerializeField]
    float delta = 1.5f;

    [SerializeField]
    float speed = 0.3f;

    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        pos = transform.position;
    }


    void Update()
    {
        Vector3 v3 = pos;
        v3.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v3;
    }
}
