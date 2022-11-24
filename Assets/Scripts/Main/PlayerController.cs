using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Playerの行動制御
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 10;

    [SerializeField]
    float jumppower = 5;

    [SerializeField]
    GameObject buttonController;

    new
    #region//プライベート変数　SpriteRenderer
        SpriteRenderer renderer;
    Rigidbody2D rbody;
    #endregion

    #region//プライベート変数  bool
    bool pushFlag;
    bool jumpFlag;
    #endregion

    /// <summary>
    /// 左ボタンコントローラー
    /// </summary>
    public void LButtonDown()
    {
        LeftMove();
    }

    void LeftMove()
    {
        //rbody.AddForce(-transform.right * speed);
        rbody.MovePosition(transform.position + Vector3.left);

        renderer.flipX = true;
    }

    /// <summary>
    /// 右ボタンコントローラー
    /// </summary>
    public void RButtonDown()
    {
        RightMove();
    }

    void RightMove()
    {
        //rbody.AddForce(transform.right * speed);
        //ransform.Translate(1, 0, 0);
        rbody.MovePosition(transform.position + Vector3.right);
        renderer.flipX = false;
    }

    /// <summary>
    /// ジャンプ（上）ボタンコントローラー
    /// </summary>
    public void UButtonDown()
    {
        Jump();
    }

    void Jump()
    {
        rbody.AddForce(transform.up * speed);

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
        DownMove();
    }

    void DownMove()
    {
        rbody.MovePosition(transform.position + Vector3.down);
        //rbody.AddForce(-transform.up * speed);
    }

    void Start()
    {
        buttonController.SetActive(true);
        renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        renderer.flipX = false;

        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Dkey");
            RightMove();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Akey");
            LeftMove();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Wkey");
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("SKey");
            DownMove();
        }
    }

    void FixedUpdate()
    {
        
        if (jumpFlag)
        {
            jumpFlag = false;
            rbody.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
        }
    }
}
