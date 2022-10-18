using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 降りてくるリフトの動き
/// </summary>
public class LiftDownMove : MonoBehaviour
{
    #region//インスペクターで設定する
    [Header("移動速度")] public float speed;


    [Header("重力")] public float gravity;
    #endregion

    #region//プライベート変数
    private Rigidbody2D rbody = null;
    #endregion

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rbody.velocity = new Vector2(speed, -gravity);
    }
}
