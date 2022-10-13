using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Playerの行動制御
/// </summary>
public class PlayerController : MonoBehaviour
{
    //[SerializeField]
    public float speed = 30;

    public float jumppower = 8;
    new
    #region//プライベート変数　SpriteRenderer
        SpriteRenderer renderer;
    Rigidbody2D rbody;
    #endregion

    #region//プライベート変数  bool
    bool pushFlag;
    private bool jumpFlag;
    #endregion

    /// <summary>
    /// 左ボタンコントローラー
    /// </summary>
    public void LButtonDown()
    {
        rbody.AddForce(-transform.right * speed);
        //transform.Translate(-2, 0, 0);

        renderer.flipX = true;
    }

    /// <summary>
    /// 右ボタンコントローラー
    /// </summary>
    public void RButtonDown()
    {
        rbody.AddForce(transform.right * speed);
        //transform.Translate(1, 0, 0);

        renderer.flipX = false;
    }

    /// <summary>
    /// ジャンプ（上）ボタンコントローラー
    /// </summary>
    public void UButtonDown()
    {
        rbody.AddForce(transform.up * speed);
        //transform.Translate(0, 2, 0);

        if (pushFlag == false)
        {
            jumpFlag = true;
            pushFlag = true;
        }
        else
        {
            pushFlag = false;
        }
    }

    /// <summary>
    /// 下ボタンのコントローラー（落下ではなくボタンで制御）
    /// </summary>
    public void DButtonDown()
    {
        rbody.AddForce(-transform.up * speed);
        //transform.Translate(0, -20, 0);
    }

    void Start()
    {
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        renderer.flipX = false;

        rbody = GetComponent<Rigidbody2D>();
    }

    //void Update()
    //{

    //}

    void FixedUpdate()
    {
        if (jumpFlag)
        {
            jumpFlag = false;
            rbody.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
        }
    }
}
