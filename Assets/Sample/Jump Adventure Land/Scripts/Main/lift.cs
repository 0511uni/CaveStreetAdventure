using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lift : MonoBehaviour
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
        rbody = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        rbody.velocity = new Vector2(speed, -gravity);


    }
}
